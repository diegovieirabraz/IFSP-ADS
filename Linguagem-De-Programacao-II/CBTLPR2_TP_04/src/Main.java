import javax.swing.*;
import java.awt.*;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.math.BigDecimal;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class Main {
    // Ajuste a string de conexão para o seu SQL Server.
    private static final String DB_URL = "jdbc:sqlserver://localhost;databaseName=aulajava;encrypt=false";
    private static final String DB_USER = "sa";
    private static final String DB_PASSWORD = "22446688";

    private JFrame frame;
    private JTextField searchField;
    private JTextField nameField;
    private JTextField salaryField;
    private JTextField cargoField;
    private JButton prevButton;
    private JButton nextButton;

    private final List<Funcionario> results = new ArrayList<>();
    private int currentIndex = -1;
    private Connection connection;

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new Main().start());
    }

    private void start() {
        frame = new JFrame("TRABALHO PRATICO 04");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setResizable(false);
        frame.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                closeConnection();
            }
        });

        initComponents();

        frame.pack();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }

    private void initComponents() {
        searchField = new JTextField(15);

        JButton searchButton = new JButton("Pesquisar");
        searchButton.addActionListener(e -> performSearch());

        JPanel searchPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        searchPanel.add(new JLabel("Nome:"));
        searchPanel.add(searchField);
        searchPanel.add(searchButton);

        nameField = createDisplayField();
        salaryField = createDisplayField();
        cargoField = createDisplayField();

        JPanel detailsPanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(4, 6, 4, 6);
        gbc.anchor = GridBagConstraints.LINE_START;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.weightx = 0;

        addRow(detailsPanel, gbc, 0, "Nome:", nameField);
        addRow(detailsPanel, gbc, 1, "Salário:", salaryField);
        addRow(detailsPanel, gbc, 2, "Cargo:", cargoField);

        prevButton = new JButton("Anterior");
        nextButton = new JButton("Próximo");
        prevButton.addActionListener(e -> showPrevious());
        nextButton.addActionListener(e -> showNext());

        JPanel navPanel = new JPanel(new GridLayout(1, 2));
        navPanel.add(prevButton);
        navPanel.add(nextButton);

        frame.getContentPane().setLayout(new BorderLayout());
        frame.add(searchPanel, BorderLayout.NORTH);
        frame.add(detailsPanel, BorderLayout.CENTER);
        frame.add(navPanel, BorderLayout.SOUTH);

        updateNavigationButtons();
    }

    private JTextField createDisplayField() {
        JTextField field = new JTextField(20);
        field.setEditable(false);
        return field;
    }

    private void addRow(JPanel panel, GridBagConstraints gbc, int row, String label, JTextField field) {
        gbc.gridx = 0;
        gbc.gridy = row;
        panel.add(new JLabel(label), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        panel.add(field, gbc);
        gbc.weightx = 0;
    }

    private void performSearch() {
        String filter = searchField.getText().trim();

        results.clear();
        currentIndex = -1;
        clearDisplay();
        updateNavigationButtons();

        String sql =
                "SELECT f.cod_func, f.nome_func, f.sal_func, c.ds_cargo "
                        + "FROM tbfuncs f "
                        + "JOIN tbcargos c ON c.cod_cargo = f.cod_cargo "
                        + "WHERE f.nome_func LIKE ? "
                        + "ORDER BY f.cod_func";

        try (PreparedStatement stmt = getConnection().prepareStatement(sql)) {
            stmt.setString(1, "%" + filter + "%");

            try (ResultSet rs = stmt.executeQuery()) {
                while (rs.next()) {
                    Funcionario f = new Funcionario(
                            rs.getInt("cod_func"),
                            rs.getString("nome_func"),
                            rs.getBigDecimal("sal_func"),
                            rs.getString("ds_cargo")
                    );
                    results.add(f);
                }
            }

            if (results.isEmpty()) {
                JOptionPane.showMessageDialog(frame, "Nenhum registro encontrado.", "Aviso",
                        JOptionPane.INFORMATION_MESSAGE);
                return;
            }

            currentIndex = 0;
            showCurrent();
        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(frame,
                    "Erro ao consultar o banco:\n" + ex.getMessage(),
                    "Erro", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void showCurrent() {
        if (currentIndex < 0 || currentIndex >= results.size()) {
            clearDisplay();
            updateNavigationButtons();
            return;
        }

        Funcionario f = results.get(currentIndex);
        nameField.setText(f.getNome());
        salaryField.setText(f.getSalario().toPlainString());
        cargoField.setText(f.getCargo());
        updateNavigationButtons();
    }

    private void showNext() {
        if (currentIndex + 1 < results.size()) {
            currentIndex++;
            showCurrent();
        }
    }

    private void showPrevious() {
        if (currentIndex - 1 >= 0) {
            currentIndex--;
            showCurrent();
        }
    }

    private void clearDisplay() {
        nameField.setText("");
        salaryField.setText("");
        cargoField.setText("");
    }

    private void updateNavigationButtons() {
        boolean hasData = !results.isEmpty();
        prevButton.setEnabled(hasData && currentIndex > 0);
        nextButton.setEnabled(hasData && currentIndex < results.size() - 1);
    }

    private Connection getConnection() throws SQLException {
        if (connection == null || connection.isClosed()) {
            connection = DriverManager.getConnection(DB_URL, DB_USER, DB_PASSWORD);
        }
        return connection;
    }

    private void closeConnection() {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException ignored) {
            }
        }
    }

    private static class Funcionario {
        private final int codigo;
        private final String nome;
        private final BigDecimal salario;
        private final String cargo;

        Funcionario(int codigo, String nome, BigDecimal salario, String cargo) {
            this.codigo = codigo;
            this.nome = nome;
            this.salario = salario;
            this.cargo = cargo;
        }

        public int getCodigo() {
            return codigo;
        }

        public String getNome() {
            return nome;
        }

        public BigDecimal getSalario() {
            return salario;
        }

        public String getCargo() {
            return cargo;
        }
    }
}

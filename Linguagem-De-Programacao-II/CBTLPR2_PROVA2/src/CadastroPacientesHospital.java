import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

//Diego Vieira Braz

public class CadastroPacientesHospital {


    private static final String URL = "jdbc:sqlserver://localhost:1433;databaseName=hospital;encrypt=true;trustServerCertificate=true;";
    private static final String USER = "sa";
    private static final String PASS = "22446688";

    public static void main(String[] args) {
        JFrame frame = new JFrame("Cadastro de Pacientes - Hospital");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(600, 400);


        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(7, 2, 10, 10));
        panel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        JLabel lblNome = new JLabel("Nome:");
        JTextField txtNome = new JTextField();

        JLabel lblIdade = new JLabel("Idade:");
        JTextField txtIdade = new JTextField();

        JLabel lblPeso = new JLabel("Peso (kg):");
        JTextField txtPeso = new JTextField();

        JLabel lblAltura = new JLabel("Altura (m):");
        JTextField txtAltura = new JTextField();

        panel.add(lblNome);
        panel.add(txtNome);
        panel.add(lblIdade);
        panel.add(txtIdade);
        panel.add(lblPeso);
        panel.add(txtPeso);
        panel.add(lblAltura);
        panel.add(txtAltura);

        JButton btnIncluir = new JButton("Incluir");
        JButton btnLimpar = new JButton("Limpar");
        JButton btnPesquisar = new JButton("Pesquisar (Nome)");
        JButton btnApresentar = new JButton("Apresenta Dados");
        JButton btnCreditos = new JButton("Créditos");
        JButton btnSair = new JButton("Sair");


        panel.add(btnIncluir);
        panel.add(btnLimpar);
        panel.add(btnPesquisar);
        panel.add(btnApresentar);
        panel.add(btnCreditos);
        panel.add(btnSair);

        frame.add(panel);
        frame.setVisible(true);

        btnIncluir.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Validação básica de campos vazios
                if (txtNome.getText().isEmpty() || txtIdade.getText().isEmpty() ||
                        txtPeso.getText().isEmpty() || txtAltura.getText().isEmpty()) {
                    JOptionPane.showMessageDialog(frame, "Todos os campos são obrigatórios!", "Aviso", JOptionPane.WARNING_MESSAGE);
                    return;
                }

                try {
                    String nome = txtNome.getText();
                    int idade = Integer.parseInt(txtIdade.getText());
                    float peso = Float.parseFloat(txtPeso.getText().replace(",", "."));
                    float altura = Float.parseFloat(txtAltura.getText().replace(",", "."));

                    try (Connection connection = DriverManager.getConnection(URL, USER, PASS)) {
                        String query = "INSERT INTO pacientes (nome, idade, peso, altura) VALUES (?, ?, ?, ?)";
                        PreparedStatement preparedStatement = connection.prepareStatement(query);
                        preparedStatement.setString(1, nome);
                        preparedStatement.setInt(2, idade);
                        preparedStatement.setFloat(3, peso);
                        preparedStatement.setFloat(4, altura);

                        int rowsInserted = preparedStatement.executeUpdate();
                        if (rowsInserted > 0) {
                            JOptionPane.showMessageDialog(frame, "Paciente cadastrado com sucesso!");
                            // Limpar campos após incluir
                            txtNome.setText("");
                            txtIdade.setText("");
                            txtPeso.setText("");
                            txtAltura.setText("");
                        }
                    } catch (SQLException ex) {
                        JOptionPane.showMessageDialog(frame, "Erro de Banco de Dados: " + ex.getMessage());
                    }

                } catch (NumberFormatException ex) {
                    JOptionPane.showMessageDialog(frame, "Erro de Formato: Certifique-se que Idade, Peso e Altura são números válidos.\nUse ponto ou vírgula para decimais.", "Erro", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        btnPesquisar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String nomePesquisa = txtNome.getText();
                if (nomePesquisa.isEmpty()) {
                    JOptionPane.showMessageDialog(frame, "Digite um nome (ou parte dele) no campo 'Nome' para pesquisar.");
                    return;
                }

                try (Connection connection = DriverManager.getConnection(URL, USER, PASS)) {
                    String query = "SELECT * FROM pacientes WHERE nome LIKE ?";
                    PreparedStatement preparedStatement = connection.prepareStatement(query);
                    preparedStatement.setString(1, "%" + nomePesquisa + "%");

                    ResultSet resultSet = preparedStatement.executeQuery();
                    exibirResultados(resultSet, frame, "Resultado da Pesquisa");

                } catch (SQLException ex) {
                    JOptionPane.showMessageDialog(frame, "Erro ao pesquisar: " + ex.getMessage());
                }
            }
        });

        btnApresentar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try (Connection connection = DriverManager.getConnection(URL, USER, PASS)) {
                    String query = "SELECT * FROM pacientes";
                    PreparedStatement preparedStatement = connection.prepareStatement(query);
                    ResultSet resultSet = preparedStatement.executeQuery();

                    exibirResultados(resultSet, frame, "Todos os Pacientes");

                } catch (SQLException ex) {
                    JOptionPane.showMessageDialog(frame, "Erro ao buscar dados: " + ex.getMessage());
                }
            }
        });

        btnLimpar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                txtNome.setText("");
                txtIdade.setText("");
                txtPeso.setText("");
                txtAltura.setText("");
                txtNome.requestFocus();
            }
        });

        btnCreditos.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String mensagem = "Trabalho realizado por:\n\n" +
                        "1. Diego Vieira Braz\n" ;

                JOptionPane.showMessageDialog(frame, mensagem, "Créditos", JOptionPane.INFORMATION_MESSAGE);
            }
        });

        btnSair.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.exit(0);
            }
        });
    }


    private static void exibirResultados(ResultSet resultSet, JFrame frame, String titulo) throws SQLException {
        StringBuilder result = new StringBuilder();
        boolean encontrou = false;

        while (resultSet.next()) {
            encontrou = true;
            int id = resultSet.getInt("id");
            String nome = resultSet.getString("nome");
            int idade = resultSet.getInt("idade");
            float peso = resultSet.getFloat("peso");
            float altura = resultSet.getFloat("altura");

            result.append(String.format("ID: %d | Nome: %s | Idade: %d | Peso: %.2f | Altura: %.2f\n",
                    id, nome, idade, peso, altura));
            result.append("-------------------------------------------------------------\n");
        }

        if (!encontrou) {
            JOptionPane.showMessageDialog(frame, "Nenhum registro encontrado.", titulo, JOptionPane.INFORMATION_MESSAGE);
        } else {
            JTextArea textArea = new JTextArea(result.toString());
            textArea.setEditable(false);
            JScrollPane scrollPane = new JScrollPane(textArea);
            scrollPane.setPreferredSize(new Dimension(450, 300));
            JOptionPane.showMessageDialog(frame, scrollPane, titulo, JOptionPane.INFORMATION_MESSAGE);
        }
    }
}
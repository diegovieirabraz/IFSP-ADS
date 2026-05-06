import javax.swing.*;
import java.awt.*;

public class FormPessoaCombo extends JFrame {

    private JTextField txtNumero;
    private JTextField txtNome;
    private JComboBox<String> comboSexo;
    private JTextField txtIdade;

    private Pessoa umaPessoa;

    public FormPessoaCombo() {
        super("FormPessoa - Versão JComboBox");

        txtNumero = new JTextField(5);
        txtNumero.setEditable(false);

        txtNome = new JTextField(20);
        comboSexo = new JComboBox<>(new String[]{"Selecione", "M", "F"});
        txtIdade = new JTextField(5);

        JButton btnOk = new JButton("OK");
        JButton btnMostrar = new JButton("Mostrar");

        JPanel painel = new JPanel(new GridLayout(4, 2, 5, 5));
        painel.add(new JLabel("Número:"));
        painel.add(txtNumero);

        painel.add(new JLabel("Nome:"));
        painel.add(txtNome);

        painel.add(new JLabel("Sexo:"));
        painel.add(comboSexo);

        painel.add(new JLabel("Idade:"));
        painel.add(txtIdade);

        JPanel painelBotoes = new JPanel(new FlowLayout());
        painelBotoes.add(btnOk);
        painelBotoes.add(btnMostrar);

        setLayout(new BorderLayout(5, 5));
        add(painel, BorderLayout.CENTER);
        add(painelBotoes, BorderLayout.SOUTH);

        btnOk.addActionListener(e -> salvarPessoa());
        btnMostrar.addActionListener(e -> mostrarPessoa());

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setLocationRelativeTo(null);
    }

    private void salvarPessoa() {
        String nome = txtNome.getText().trim();
        String idadeStr = txtIdade.getText().trim();
        String sexoStr = (String) comboSexo.getSelectedItem();

        if (nome.isEmpty() || idadeStr.isEmpty() || "Selecione".equals(sexoStr)) {
            JOptionPane.showMessageDialog(this,
                    "Nome, Sexo e Idade são obrigatórios.",
                    "Validação",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        int idade;
        try {
            idade = Integer.parseInt(idadeStr);
        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this,
                    "Idade deve ser um número inteiro.",
                    "Validação",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        Pessoa.setKp();

        if (umaPessoa == null) {
            umaPessoa = new Pessoa(nome, sexoStr.charAt(0), idade);
        } else {
            umaPessoa.setNome(nome);
            umaPessoa.setSexo(sexoStr.charAt(0));
            umaPessoa.setIdade(idade);
        }

        txtNumero.setText(String.valueOf(Pessoa.getKp()));
        JOptionPane.showMessageDialog(this, "Dados salvos em UmaPessoa.");
    }

    private void mostrarPessoa() {
        if (umaPessoa == null) {
            JOptionPane.showMessageDialog(this,
                    "Nenhuma pessoa cadastrada ainda.",
                    "Informação",
                    JOptionPane.INFORMATION_MESSAGE);
            return;
        }

        String msg = "Número (kp): " + Pessoa.getKp() +
                "\nNome: " + umaPessoa.getNome() +
                "\nSexo: " + umaPessoa.getSexo() +
                "\nIdade: " + umaPessoa.getIdade();

        JOptionPane.showMessageDialog(this, msg, "Dados de UmaPessoa",
                JOptionPane.INFORMATION_MESSAGE);
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new FormPessoaCombo().setVisible(true));
    }
}

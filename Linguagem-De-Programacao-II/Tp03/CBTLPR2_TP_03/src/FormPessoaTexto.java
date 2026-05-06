import javax.swing.*;
import java.awt.*;

public class FormPessoaTexto extends JFrame {

    private JTextField txtNumero;
    private JTextField txtNome;
    private JTextField txtSexo;
    private JTextField txtIdade;

    private Pessoa umaPessoa;

    public FormPessoaTexto() {
        super("FormPessoa - Versão TextField");

        txtNumero = new JTextField(5);
        txtNumero.setEditable(false);

        txtNome = new JTextField(20);
        txtSexo = new JTextField(2);
        txtIdade = new JTextField(5);

        JButton btnOk = new JButton("OK");
        JButton btnMostrar = new JButton("Mostrar");

        JPanel painel = new JPanel(new GridLayout(4, 2, 5, 5));
        painel.add(new JLabel("Número:"));
        painel.add(txtNumero);

        painel.add(new JLabel("Nome:"));
        painel.add(txtNome);

        painel.add(new JLabel("Sexo (M/F):"));
        painel.add(txtSexo);

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
        String sexoStr = txtSexo.getText().trim().toUpperCase();
        String idadeStr = txtIdade.getText().trim();

        if (nome.isEmpty() || sexoStr.isEmpty() || idadeStr.isEmpty()) {
            JOptionPane.showMessageDialog(this,
                    "Todos os campos (Nome, Sexo, Idade) são obrigatórios.",
                    "Validação",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        if (!(sexoStr.equals("M") || sexoStr.equals("F"))) {
            JOptionPane.showMessageDialog(this,
                    "Sexo deve ser 'M' ou 'F'.",
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

        // Incrementa o contador kp
        Pessoa.setKp();

        // Cria ou atualiza a instância de Pessoa
        if (umaPessoa == null) {
            umaPessoa = new Pessoa(nome, sexoStr.charAt(0), idade);
        } else {
            umaPessoa.setNome(nome);
            umaPessoa.setSexo(sexoStr.charAt(0));
            umaPessoa.setIdade(idade);
        }

        // Atualiza o campo Número com o valor de kp
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
        SwingUtilities.invokeLater(() -> new FormPessoaTexto().setVisible(true));
    }
}

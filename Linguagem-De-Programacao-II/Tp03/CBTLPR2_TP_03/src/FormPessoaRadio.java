import javax.swing.*;
import java.awt.*;

public class FormPessoaRadio extends JFrame {

    private JTextField txtNumero;
    private JTextField txtNome;
    private JRadioButton rbMasculino;
    private JRadioButton rbFeminino;
    private JTextField txtIdade;

    private Pessoa umaPessoa;

    public FormPessoaRadio() {
        super("FormPessoa ");

        txtNumero = new JTextField(5);
        txtNumero.setEditable(false);

        txtNome = new JTextField(20);
        txtIdade = new JTextField(5);

        rbMasculino = new JRadioButton("M");
        rbFeminino = new JRadioButton("F");
        ButtonGroup grupoSexo = new ButtonGroup();
        grupoSexo.add(rbMasculino);
        grupoSexo.add(rbFeminino);

        JPanel painelSexo = new JPanel(new FlowLayout(FlowLayout.LEFT));
        painelSexo.add(rbMasculino);
        painelSexo.add(rbFeminino);

        JButton btnOk = new JButton("OK");
        JButton btnMostrar = new JButton("Mostrar");

        JPanel painel = new JPanel(new GridLayout(4, 2, 5, 5));
        painel.add(new JLabel("Número:"));
        painel.add(txtNumero);

        painel.add(new JLabel("Nome:"));
        painel.add(txtNome);

        painel.add(new JLabel("Sexo:"));
        painel.add(painelSexo);

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

        if (nome.isEmpty() || idadeStr.isEmpty()) {
            JOptionPane.showMessageDialog(this,
                    "Nome e Idade são obrigatórios.",
                    "Validação",
                    JOptionPane.WARNING_MESSAGE);
            return;
        }

        char sexo;
        if (rbMasculino.isSelected()) {
            sexo = 'M';
        } else if (rbFeminino.isSelected()) {
            sexo = 'F';
        } else {
            JOptionPane.showMessageDialog(this,
                    "Selecione o sexo (M ou F).",
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
            umaPessoa = new Pessoa(nome, sexo, idade);
        } else {
            umaPessoa.setNome(nome);
            umaPessoa.setSexo(sexo);
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
        SwingUtilities.invokeLater(() -> new FormPessoaRadio().setVisible(true));
    }
}

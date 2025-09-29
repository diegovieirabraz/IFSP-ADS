import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;


/*Diego Vieira Braz  Prontuário: 3029719

*/
public class FormularioAluno extends JFrame {

    private List<Aluno> listaAlunos;

    private JTextField txtNome;
    private JTextField txtIdade;
    private JTextField txtEndereco;

    public FormularioAluno() {

        setTitle("TP02-LP214"); // [cite: 25]
        setSize(400, 180); // [cite: 38]
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        setLayout(new BorderLayout(10, 10));

        listaAlunos = new ArrayList<>();

        JPanel painelSuperior = new JPanel(new GridLayout(3, 2, 10, 10));

        painelSuperior.add(new JLabel("Nome:")); // [cite: 24]
        txtNome = new JTextField();
        painelSuperior.add(txtNome);

        painelSuperior.add(new JLabel("Idade:")); // [cite: 26]
        txtIdade = new JTextField();
        painelSuperior.add(txtIdade);

        painelSuperior.add(new JLabel("Endereço:")); // [cite: 33]
        txtEndereco = new JTextField();
        painelSuperior.add(txtEndereco);

        JPanel painelInferior = new JPanel(new GridLayout(1, 4, 10, 0));

        JButton btnOk = new JButton("Ok");
        JButton btnLimpar = new JButton("Limpar");
        JButton btnMostrar = new JButton("Mostrar");
        JButton btnSair = new JButton("Sair");

        painelInferior.add(btnOk);
        painelInferior.add(btnLimpar);
        painelInferior.add(btnMostrar);
        painelInferior.add(btnSair);

        add(painelSuperior, BorderLayout.CENTER);
        add(painelInferior, BorderLayout.SOUTH);

        btnOk.addActionListener(e -> {
            try {
                String nome = txtNome.getText();
                int idade = Integer.parseInt(txtIdade.getText());
                String endereco = txtEndereco.getText();

                if (nome.trim().isEmpty() || endereco.trim().isEmpty()) {
                    JOptionPane.showMessageDialog(this, "Nome e Endereço não podem ser vazios.", "Erro", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                Aluno novoAluno = new Aluno(nome, idade, endereco);
                listaAlunos.add(novoAluno);

                JOptionPane.showMessageDialog(this, "Aluno cadastrado com sucesso!");
                limparCampos(); // Limpa os campos após o cadastro

            } catch (NumberFormatException ex) {
                JOptionPane.showMessageDialog(this, "Por favor, insira um valor numérico para a idade.", "Erro de Formato", JOptionPane.ERROR_MESSAGE);
            }
        });

        btnLimpar.addActionListener(e -> limparCampos());

        btnMostrar.addActionListener(e -> {
            if (listaAlunos.isEmpty()) {
                JOptionPane.showMessageDialog(this, "Nenhum aluno cadastrado.", "Resultado", JOptionPane.INFORMATION_MESSAGE);
                return;
            }

            StringBuilder mensagem = new StringBuilder();
            for (Aluno aluno : listaAlunos) {
                mensagem.append("Id: ").append(aluno.getUuid()).append(" Nome: ").append(aluno.getNome()).append("\n");
            }

            JOptionPane.showMessageDialog(this, mensagem.toString(), "Resultado", JOptionPane.INFORMATION_MESSAGE);
        });

        btnSair.addActionListener(e -> System.exit(0));
    }

    private void limparCampos() {
        txtNome.setText("");
        txtIdade.setText("");
        txtEndereco.setText("");
    }

    public static void main(String[] args) {

        SwingUtilities.invokeLater(() -> {
            FormularioAluno formulario = new FormularioAluno();
            formulario.setVisible(true);
        });
    }
}
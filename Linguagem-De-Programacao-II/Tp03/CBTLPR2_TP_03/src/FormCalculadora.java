import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class FormCalculadora extends JFrame {

    private JTextField txtValor1;
    private JTextField txtValor2;
    private JTextField txtResultado;

    private Double memoria; // "memória" da calculadora

    public FormCalculadora() {
        super("Calculadora Simples");

        txtValor1 = new JTextField(10);
        txtValor2 = new JTextField(10);
        txtResultado = new JTextField(10);
        txtResultado.setEditable(false);

        JButton btnSomar = new JButton("+");
        JButton btnSubtrair = new JButton("-");
        JButton btnMultiplicar = new JButton("*");
        JButton btnDividir = new JButton("/");
        JButton btnClear = new JButton("C");

        JPanel painelCampos = new JPanel(new GridLayout(3, 2, 5, 5));
        painelCampos.add(new JLabel("Valor 1:"));
        painelCampos.add(txtValor1);
        painelCampos.add(new JLabel("Valor 2:"));
        painelCampos.add(txtValor2);
        painelCampos.add(new JLabel("Resultado:"));
        painelCampos.add(txtResultado);

        JPanel painelBotoes = new JPanel(new FlowLayout());
        painelBotoes.add(btnSomar);
        painelBotoes.add(btnSubtrair);
        painelBotoes.add(btnMultiplicar);
        painelBotoes.add(btnDividir);
        painelBotoes.add(btnClear);

        setLayout(new BorderLayout(5, 5));
        add(painelCampos, BorderLayout.CENTER);
        add(painelBotoes, BorderLayout.SOUTH);

        // Listeners dos botões
        btnSomar.addActionListener(e -> calcular('+'));
        btnSubtrair.addActionListener(e -> calcular('-'));
        btnMultiplicar.addActionListener(e -> calcular('*'));
        btnDividir.addActionListener(e -> calcular('/'));
        btnClear.addActionListener(e -> limpar());

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setLocationRelativeTo(null);
    }

    private void calcular(char operacao) {
        double v1 = 0;
        double v2 = 0;
        double resultado = 0;

        try {
            v1 = Double.parseDouble(txtValor1.getText().trim());
            v2 = Double.parseDouble(txtValor2.getText().trim());

            switch (operacao) {
                case '+':
                    resultado = v1 + v2;
                    break;
                case '-':
                    resultado = v1 - v2;
                    break;
                case '*':
                    resultado = v1 * v2;
                    break;
                case '/':
                    if (v2 == 0) {
                        throw new ArithmeticException("Divisão por zero");
                    }
                    resultado = v1 / v2;
                    break;
            }

            txtResultado.setText(String.valueOf(resultado));
            memoria = resultado;
        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this,
                    "Digite valores numéricos válidos.",
                    "Erro de Formato",
                    JOptionPane.ERROR_MESSAGE);
        } catch (ArithmeticException ex) {
            JOptionPane.showMessageDialog(this,
                    "Erro: " + ex.getMessage(),
                    "Erro de Cálculo",
                    JOptionPane.ERROR_MESSAGE);
        } finally {
            // Poderia fazer qualquer ajuste final aqui
            // Exemplo: selecionar o resultado se não estiver vazio
            if (txtResultado.getText() != null && !txtResultado.getText().isEmpty()) {
                txtResultado.requestFocus();
            }
        }
    }

    private void limpar() {
        txtValor1.setText("");
        txtValor2.setText("");
        txtResultado.setText("");
        memoria = null; // limpa memória da calculadora
        txtValor1.requestFocus();
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new FormCalculadora().setVisible(true));
    }
}

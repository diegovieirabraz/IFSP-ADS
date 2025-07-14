import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class Main {

    public static void main(String[] args) {
        try (PrintWriter writer = new PrintWriter(new FileWriter("resultado_exercicio_3.txt"))) {

            ConsultaAgendada p1 = new ConsultaAgendada(10, 30, 0, 5, 8, 2024, "Carlos Pereira", "Dr. Mendes");

            writer.println("--- DADOS INICIAIS DE P1 ---");
            exibirConsulta(p1, writer);

            System.out.println("### Por favor, insira os dados para a consulta P2 no console. ###");
            ConsultaAgendada p2 = new ConsultaAgendada();

            writer.println("--- DADOS INICIAIS DE P2 ---");
            exibirConsulta(p2, writer);

            System.out.println("\n### Por favor, altere os dados da consulta P1 no console. ###");
            p1.setData();
            p1.setHora();
            p1.setNomePaciente();
            p1.setNomeMedico();

            writer.println("--- DADOS DE P1 APÓS ALTERAÇÃO ---");
            exibirConsulta(p1, writer);

            writer.println("\nQuantidade final de consultas agendadas: " + ConsultaAgendada.getAmostra());

            System.out.println("\nExecução concluída. O resultado foi salvo no arquivo 'resultado_exercicio_3.txt'");

        } catch (IOException e) {
            System.err.println("Ocorreu um erro ao escrever no arquivo: " + e.getMessage());
        }
    }

    public static void exibirConsulta(ConsultaAgendada consulta, PrintWriter writer) {
        writer.println("Paciente: " + consulta.getNomePaciente());
        writer.println("Médico: " + consulta.getNomeMedico());
        writer.println("Data: " + consulta.getData());
        writer.println("Hora: " + consulta.getHora());
        writer.println();
    }
}
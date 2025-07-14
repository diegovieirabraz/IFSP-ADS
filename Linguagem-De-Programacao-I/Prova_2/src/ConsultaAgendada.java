import java.util.Scanner;

public class ConsultaAgendada {
    private Data data;
    private Hora hora;
    private String nomePaciente;
    private String nomeMedico;
    private static int quantidade = 0;

    public ConsultaAgendada() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("\n--- Agendando Nova Consulta (Entrada Manual) ---");

        this.data = new Data();
        this.hora = new Hora();

        System.out.print("Digite o nome do Paciente: ");
        this.nomePaciente = scanner.nextLine();

        System.out.print("Digite o nome do Médico: ");
        this.nomeMedico = scanner.nextLine();

        quantidade++;
    }

    public ConsultaAgendada(int h, int mi, int s, int d, int m, int a, String p, String med) {
        this.data = new Data(d, m, a);
        this.hora = new Hora(h, mi, s);
        this.nomePaciente = p;
        this.nomeMedico = med;
        quantidade++;
    }

    public ConsultaAgendada(Data d, Hora h, String p, String m) {
        this.data = d;
        this.hora = h;
        this.nomePaciente = p;
        this.nomeMedico = m;
        quantidade++;
    }

    public void setData() {
        this.data.setData();
    }

    public void setHora() {
        this.hora.setHora();
    }

    public void setNomePaciente() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Digite o novo nome do Paciente: ");
        this.nomePaciente = scanner.nextLine();
    }

    public void setNomeMedico() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Digite o novo nome do Médico: ");
        this.nomeMedico = scanner.nextLine();
    }

    public void setData(int a, int b, int c) {
        this.data.setData(a, b, c);
    }

    public void setHora(int a, int b, int c) {
        this.hora.setHora(a, b, c);
    }

    public void setNomePaciente(String p) {
        this.nomePaciente = p;
    }

    public void setNomeMedico(String m) {
        this.nomeMedico = m;
    }

    public String getData() {
        return this.data.getDataFormatada();
    }

    public String getHora() {
        return this.hora.getHoraFormatada();
    }

    public String getNomePaciente() {
        return this.nomePaciente;
    }

    public String getNomeMedico() {
        return this.nomeMedico;
    }

    public static int getAmostra() {
        return quantidade;
    }
}
import java.util.Scanner;

public class Hora {
    private int hora;
    private int minuto;
    private int segundo;

    public Hora(int h, int m, int s) {
        this.setHora(h, m, s);
    }

    public Hora() {
        this.setHora();
    }

    public void setHora(int h, int m, int s) {
        this.hora = (h >= 0 && h <= 23) ? h : 0;
        this.minuto = (m >= 0 && m <= 59) ? m : 0;
        this.segundo = (s >= 0 && s <= 59) ? s : 0;
    }

    public void setHora() {
        Scanner scanner = new Scanner(System.in);
        int h, m, s;

        System.out.println("--- Inserir Nova Hora ---");
        do {
            System.out.print("Digite a hora (0-23): ");
            h = scanner.nextInt();
        } while (h < 0 || h > 23);

        do {
            System.out.print("Digite o minuto (0-59): ");
            m = scanner.nextInt();
        } while (m < 0 || m > 59);

        do {
            System.out.print("Digite o segundo (0-59): ");
            s = scanner.nextInt();
        } while (s < 0 || s > 59);

        this.setHora(h, m, s);
    }

    public String getHoraFormatada() {
        return String.format("%02d:%02d:%02d", this.hora, this.minuto, this.segundo);
    }

    public int getHora() {
        return hora;
    }

    public int getMinuto() {
        return minuto;
    }

    public int getSegundo() {
        return segundo;
    }
}
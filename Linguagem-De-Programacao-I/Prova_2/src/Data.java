import java.util.Scanner;

public class Data {
    private int dia;
    private int mes;
    private int ano;

    public Data(int d, int m, int a) {
        this.setData(d, m, a);
    }

    public Data() {
        this.setData();
    }

    public void setData(int d, int m, int a) {
        if (a > 0) {
            this.ano = a;
        } else {
            this.ano = 1900;
        }
        if (m >= 1 && m <= 12) {
            this.mes = m;
        } else {
            this.mes = 1;
        }
        if (d >= 1 && d <= diasNoMes()) {
            this.dia = d;
        } else {
            this.dia = 1;
        }
    }

    public void setData() {
        Scanner scanner = new Scanner(System.in);
        int d, m, a;

        System.out.println("--- Inserir Nova Data ---");
        do {
            System.out.print("Digite o ano (ex: 2025): ");
            a = scanner.nextInt();
        } while (a <= 0);
        this.ano = a;

        do {
            System.out.print("Digite o mês (1-12): ");
            m = scanner.nextInt();
        } while (m < 1 || m > 12);
        this.mes = m;

        int ultimoDia = diasNoMes();
        do {
            System.out.print("Digite o dia (1-" + ultimoDia + "): ");
            d = scanner.nextInt();
        } while (d < 1 || d > ultimoDia);
        this.dia = d;
    }

    public String getDataFormatada() {
        return String.format("%02d/%02d/%02d", this.dia, this.mes, this.ano % 100);
    }

    public int getDia() {
        return dia;
    }

    public int getMes() {
        return mes;
    }

    public int getAno() {
        return ano;
    }

    private boolean isBissexto() {
        return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);
    }

    private int diasNoMes() {
        switch (this.mes) {
            case 4: case 6: case 9: case 11:
                return 30;
            case 2:
                return isBissexto() ? 29 : 28;
            default:
                return 31;
        }
    }
}
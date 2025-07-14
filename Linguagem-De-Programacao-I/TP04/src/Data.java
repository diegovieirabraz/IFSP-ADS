import java.text.DateFormat;
import java.util.Date;
import java.util.Scanner;
/*
Turma:ADS371
Nome: Diego Vieira Braz
*/
public class Data {
    private int dia, mes, ano;
    private static final String[] MESES = {
            "", "janeiro", "fevereiro", "março", "abril", "maio", "junho",
            "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"
    };
    private Scanner scanner = new Scanner(System.in);

    public Data() {
        System.out.println("Digite a data:");
        entraAno();
        entraMes();
        entraDia();
    }

    public Data(int d, int m, int a) {
        if (validaData(d, m, a)) {
            dia = d; mes = m; ano = a;
        } else {
            throw new IllegalArgumentException("Data inválida: " + d + "/" + m + "/" + a);
        }
    }

    public void entraDia() {
        while (true) {
            System.out.print("Digite o dia (1-31): ");
            int d = scanner.nextInt();
            if (validaDia(d, mes, ano)) { dia = d; break; }
            System.out.println("Dia inválido! Digite novamente.");
        }
    }

    public void entraMes() {
        while (true) {
            System.out.print("Digite o mês (1-12): ");
            int m = scanner.nextInt();
            if (validaMes(m)) { mes = m; break; }
            System.out.println("Mês inválido! Digite novamente.");
        }
    }

    public void entraAno() {
        while (true) {
            System.out.print("Digite o ano: ");
            int a = scanner.nextInt();
            if (validaAno(a)) { ano = a; break; }
            System.out.println("Ano inválido! Digite novamente.");
        }
    }

    public String mostra1() { return String.format("%02d/%02d/%04d", dia, mes, ano); }
    public String mostra2() { return String.format("%02d de %s de %d", dia, MESES[mes], ano); }
    public boolean bissexto() { return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0); }
    public int diasTranscorridos() {
        int[] diasPorMes = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        if (bissexto()) diasPorMes[2] = 29;
        int total = dia;
        for (int i = 1; i < mes; i++) total += diasPorMes[i];
        return total;
    }
    public void apresentaDataAtual() {
        Date dataAtual = new Date();
        DateFormat formatoCompleto = DateFormat.getDateInstance(DateFormat.FULL);
        System.out.println("Data atual: " + formatoCompleto.format(dataAtual));
    }
    private boolean validaData(int d, int m, int a) {
        return validaAno(a) && validaMes(m) && validaDia(d, m, a);
    }
    private boolean validaAno(int a) { return a > 0 && a <= 9999; }
    private boolean validaMes(int m) { return m >= 1 && m <= 12; }
    private boolean validaDia(int d, int m, int a) {
        int[] diasPorMes = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        if (bissexto()) diasPorMes[2] = 29;
        return m >= 1 && m <= 12 && d >= 1 && d <= diasPorMes[m];
    }
}

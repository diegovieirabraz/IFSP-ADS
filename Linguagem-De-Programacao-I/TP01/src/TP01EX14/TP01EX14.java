package TP01EX14;
import java.util.Scanner;

public class TP01EX14 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite o raio da esfera (r): ");
        double r = scanner.nextDouble();

        System.out.print("Digite a aresta do cubo (a): ");
        double a = scanner.nextDouble();

        double volumeCubo = Math.pow(a, 3);
        double volumeEsfera = (4.0 / 3.0) * Math.PI * Math.pow(r, 3);
        double volumeLivre = volumeCubo - volumeEsfera;

        System.out.printf("O volume livre do ambiente é: %.2f\n", volumeLivre);

        scanner.close();
    }

}

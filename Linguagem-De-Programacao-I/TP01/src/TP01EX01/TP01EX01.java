package TP01EX01;
import java.util.Scanner;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.

*/

public class TP01EX01 {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.println("Digite o valor da base do retangulo: ");
        double base = sc.nextDouble();
        System.out.println("Digite o valor da altura do retangulo: ");
        double altura = sc.nextDouble();

        double area = base * altura;

        System.out.printf("Area: %.2f", area);

        sc.close();
    }
}

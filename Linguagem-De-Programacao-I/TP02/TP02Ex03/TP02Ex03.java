package TP02Ex03;
import java.util.Scanner;
/*
3.
Entrar via teclado com “N” valores quaisquer. O valor “N” (que representa a quantidade de números) será digitado, deverá ser positivo, porém menor que vinte.
Caso a quantidade não satisfaça a restrição, enviar mensagem de erro e solicitar o valor novamente. Após a digitação dos “N” valores, exibir:
a.O maior valor;
b.O menor valor;
c.A soma dos valores;
d.A média aritmética dos valores;
e.A porcentagem de valores que são positivos;
f.A porcentagem de valores negativos;
Após exibir os dados, perguntar ao usuário de deseja ou não uma nova execução do programa.
Consistir a resposta no sentido de aceitar somente “S” ou “N” e encerrar o programa em função dessa resposta.
 */
public class TP02Ex03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        char repetir;
        do {
            int N;

            do {
                System.out.print("Digite a quantidade de números (1 a 19): ");
                N = scanner.nextInt();

                if (N <= 0 || N >= 20) {
                    System.out.println("Erro: o valor deve ser positivo e menor que 20.");
                }
            } while (N <= 0 || N >= 20);

            int[] valores = new int[N];
            int soma = 0;
            int maior = Integer.MIN_VALUE;
            int menor = Integer.MAX_VALUE;
            int positivos = 0;
            int negativos = 0;

            for (int i = 0; i < N; i++) {
                System.out.print("Digite o " + (i + 1) + "º valor: ");
                int valor = scanner.nextInt();
                valores[i] = valor;
                soma += valor;

                if (valor > maior) maior = valor;
                if (valor < menor) menor = valor;
                if (valor > 0) positivos++;
                else if (valor < 0) negativos++;
            }

            double media = soma / (double) N;
            double porcentagemPositivos = (positivos / (double) N) * 100;
            double porcentagemNegativos = (negativos / (double) N) * 100;

            System.out.println("\n--- Resultados ---");
            System.out.println("Maior valor: " + maior);
            System.out.println("Menor valor: " + menor);
            System.out.println("Soma dos valores: " + soma);
            System.out.printf("Média aritmética: %.2f\n", media);
            System.out.printf("%% de valores positivos: %.2f%%\n", porcentagemPositivos);
            System.out.printf("%% de valores negativos: %.2f%%\n", porcentagemNegativos);

            do {
                System.out.print("\nDeseja executar novamente? (S/N): ");
                repetir = scanner.next().toUpperCase().charAt(0);

                if (repetir != 'S' && repetir != 'N') {
                    System.out.println("Resposta inválida. Digite apenas 'S' ou 'N'.");
                }
            } while (repetir != 'S' && repetir != 'N');

        } while (repetir == 'S');

        System.out.println("Programa finalizado.");
        scanner.close();
    }
}

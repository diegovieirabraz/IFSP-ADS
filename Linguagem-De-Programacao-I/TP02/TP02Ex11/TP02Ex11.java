package TP02Ex11;
import java.util.Scanner;
/*
11.Entrar com uma matriz de ordem MxM, onde a ordem também será escolhida pelo usuário,
sendo que no máximo será de ordem 10 e quadrática.
Após a digitação dos elementos, calcular e exibir determinante da matriz.
 */
public class TP02Ex11 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int n;

        do {
            System.out.print("Digite a ordem da matriz quadrada (até 10): ");
            n = scanner.nextInt();
            if (n <= 0 || n > 10) {
                System.out.println("Ordem inválida! Digite um valor entre 1 e 10.");
            }
        } while (n <= 0 || n > 10);

        double[][] matriz = new double[n][n];
        double[][] temp = new double[n][n];

        // Entrada dos valores
        System.out.println("\nDigite os elementos da matriz:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print("Elemento [" + i + "][" + j + "]: ");
                matriz[i][j] = scanner.nextDouble();
                temp[i][j] = matriz[i][j];
            }
        }

        System.out.println("\n--- Matriz Original ---");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.printf("%.2f\t", matriz[i][j]);
            }
            System.out.println();
        }

        double det = 1;
        for (int i = 0; i < n; i++) {
            // Se o pivô for 0, tentar trocar com linha abaixo
            if (temp[i][i] == 0) {
                boolean trocou = false;
                for (int k = i + 1; k < n; k++) {
                    if (temp[k][i] != 0) {
                        for (int j = 0; j < n; j++) {
                            double aux = temp[i][j];
                            temp[i][j] = temp[k][j];
                            temp[k][j] = aux;
                        }
                        det *= -1; // troca de linha inverte sinal
                        trocou = true;
                        break;
                    }
                }
                if (!trocou) {
                    System.out.println("\nDeterminante da matriz: 0 (linha dependente ou nula)");
                    return;
                }
            }

            det *= temp[i][i];

            for (int j = i + 1; j < n; j++) {
                double fator = temp[j][i] / temp[i][i];
                for (int k = i; k < n; k++) {
                    temp[j][k] -= fator * temp[i][k];
                }
            }
        }

        System.out.printf("\nDeterminante da matriz: %.2f\n", det);
        scanner.close();
    }
}

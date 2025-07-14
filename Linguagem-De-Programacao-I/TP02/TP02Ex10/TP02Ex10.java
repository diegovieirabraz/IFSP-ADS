package TP02Ex10;

import java.util.Scanner;

/*10. Entrar com uma matriz de ordem MxM, onde a ordem também será escolhida pelo usuário,
sendo que no máximo será de ordem 10 e quadrática. Após a digitação dos elementos,
calcular e exibir a matriz inversa. Exibir as matrizes na tela, sob a forma matricial (linhas x
colunas).
 */
public class TP02Ex10 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n;

        // Solicita a ordem da matriz (até 10)
        do {
            System.out.print("Digite a ordem da matriz quadrada (até 10): ");
            n = scanner.nextInt();
            if (n <= 0 || n > 10) {
                System.out.println("Ordem inválida. Digite um valor entre 1 e 10.");
            }
        } while (n <= 0 || n > 10);

        double[][] matriz = new double[n][n];
        double[][] identidade = new double[n][n];

        // Leitura da matriz
        System.out.println("\nDigite os elementos da matriz:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print("Elemento [" + i + "][" + j + "]: ");
                matriz[i][j] = scanner.nextDouble();
            }
        }

        for (int i = 0; i < n; i++) {
            identidade[i][i] = 1;
        }

        for (int i = 0; i < n; i++) {
            double pivo = matriz[i][i];
            if (pivo == 0) {
                System.out.println("\nA matriz não é invertível .");
                return;
            }

            for (int j = 0; j < n; j++) {
                matriz[i][j] /= pivo;
                identidade[i][j] /= pivo;
            }

            for (int k = 0; k < n; k++) {
                if (k != i) {
                    double fator = matriz[k][i];
                    for (int j = 0; j < n; j++) {
                        matriz[k][j] -= fator * matriz[i][j];
                        identidade[k][j] -= fator * identidade[i][j];
                    }
                }
            }
        }

        System.out.println("\n--- Matriz Original ---");
        imprimirMatriz(matriz);

        System.out.println("\n--- Matriz Inversa ---");
        imprimirMatriz(identidade);

        scanner.close();
    }

    public static void imprimirMatriz(double[][] matriz) {
        for (double[] linha : matriz) {
            for (double valor : linha) {
                System.out.printf("%.2f\t", valor);
            }
            System.out.println();
        }
    }
}

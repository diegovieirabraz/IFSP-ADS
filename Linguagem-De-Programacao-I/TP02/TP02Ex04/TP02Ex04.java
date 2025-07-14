package TP02Ex04;

import java.util.Scanner;

/*
4. Armazenar seis valores em uma matriz de ordem 2x3. Apresentar os valores na tela.
*/
public class TP02Ex04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[][] matriz = new int[2][3];

        System.out.println("Digite 6 valores para preencher a matriz 2x3:");
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++) {
                System.out.print("Valor para posição [" + i + "][" + j + "]: ");
                matriz[i][j] = scanner.nextInt();
            }
        }

        System.out.println("\n--- Matriz 2x3 ---");
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++) {
                System.out.print(matriz[i][j] + "\t");
            }
            System.out.println();
        }
        scanner.close();
    }
}

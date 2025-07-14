package TP01EX17;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/

import java.util.Scanner;
public class TP01EX17
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor de X: ");
		double x = sc.nextDouble();
		System.out.println("Digite o valor de Y: ");
		double y = sc.nextDouble();
		
		double calculo = Math.pow(x, y);
		System.out.printf("Resultado de x^y: %.2f\n", calculo);

		sc.close();
	}
}
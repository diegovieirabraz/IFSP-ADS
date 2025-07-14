package TP01EX10;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/

import java.util.Scanner;
public class TP01EX10
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da temperatura em celsius: ");
		double c = sc.nextDouble();
	
	    double f = c*1.8 + 32;
		
		System.out.printf("Graus em Fahrenheit: F° %.0f", f);
		
		sc.close();
	}
}
package TP01EX09;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX09
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite a resistencia do circuito: ");
		double resistencia = sc.nextDouble();
		System.out.println("Digite o valor da corrente elétrica do circuito: ");
		double corrente = sc.nextDouble();
	
	    double tensao = resistencia*corrente;
		
		System.out.printf("Tensão: %.2f", tensao);
		
		sc.close();
	}
}
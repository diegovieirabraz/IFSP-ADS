package TP01EX13;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX13
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da velocidade inicial: ");
		double velocidadeI = sc.nextDouble();
		System.out.println("Digite o valor da aceleração: ");
		double a = sc.nextDouble();
		System.out.println("Digite o valor do tempo do percurso: ");
		double t = sc.nextDouble();

		
	    double vFinal = (velocidadeI + a*t)*3.6;
		
		System.out.printf("Velocidade Final: %.2f", vFinal);
		
		sc.close();
	}
}
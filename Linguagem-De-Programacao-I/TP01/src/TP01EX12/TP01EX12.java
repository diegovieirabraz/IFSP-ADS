package TP01EX12;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX12
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da altura: ");
		double h = sc.nextDouble();
		System.out.println("Digite o valor do raio: ");
		double r = sc.nextDouble();
		
	    double volume = (Math.PI*Math.pow(r,2)*h)/3;
		
		System.out.printf("Volume do cone: %.2f", volume);
		
		sc.close();
	}
}
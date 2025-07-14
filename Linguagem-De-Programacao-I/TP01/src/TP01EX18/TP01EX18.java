package TP01EX18;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX18
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor do produto01: ");
		double prod1 = sc.nextDouble();
		System.out.println("Digite o valor do produto02: ");
		double prod2 = sc.nextDouble();
		System.out.println("Digite o valor do produto03: ");
		double prod3 = sc.nextDouble();
		System.out.println("Digite o valor do produto04: ");
		double prod4 = sc.nextDouble();
		System.out.println("Digite o valor do produto05: ");
		double prod5 = sc.nextDouble();
		
		System.out.println("Digite o valor do pagamento: ");
		double pagamento = sc.nextDouble();
		
		double somaValorProd = prod1 + prod2 + prod3 + prod4 + prod5;
		
		double troco = pagamento - somaValorProd;
		System.out.printf("Troco a ser dado: %.2f", troco);

		sc.close();
	}
}
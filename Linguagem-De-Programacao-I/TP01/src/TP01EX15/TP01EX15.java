package TP01EX15;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX15
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da cotação do dolar: ");
		double cotacao = sc.nextDouble();
		System.out.println("Digite a quantidade de dolares: ");
		double dolares = sc.nextDouble();
		
	    double reais = dolares*cotacao;
		
		System.out.printf("Valor em reais R$%.2f", reais);
		
		sc.close();
	}
}
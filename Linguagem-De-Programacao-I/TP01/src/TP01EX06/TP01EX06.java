package TP01EX06;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.
*/
import java.util.Scanner;
public class TP01EX06
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor 1: ");
		double val1 = sc.nextDouble();
		System.out.println("Digite o valor 2: ");
		double val2 = sc.nextDouble();
		System.out.println("Digite o valor 3: ");
		double val3 = sc.nextDouble();
		System.out.println("Digite o valor 4: ");
		double val4 = sc.nextDouble();
	
	    double media = (val1 + val2 + val3 + val4)/4;
		
		System.out.printf("Media: %.2f", media);
		
		sc.close();
	}
}
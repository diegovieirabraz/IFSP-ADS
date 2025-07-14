package TP01EX03;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.
*/
import java.util.Scanner;
public class TP01EX03
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da diagonal do quadrado: ");
		double diagonal = sc.nextDouble();
		
		double area = (diagonal*diagonal)/2;
		
		System.out.printf("Area: %.2f", area);
		
		sc.close();
	}
}
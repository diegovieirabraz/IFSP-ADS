package TP01EX08;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.
*/
import java.util.Scanner;
public class TP01EX08
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite a distancia em milhas maritimas: ");
		double milhas = sc.nextDouble();
	
	    double quilometros = (milhas*1852)/1000;
		
		System.out.printf("Milhas em quilometros: %.2f", quilometros);
		
		sc.close();
	}
}
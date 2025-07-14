package TP01EX05;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.
*/
import java.util.Scanner;
public class TP01EX05
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor do diametro da esfera: ");
		double diametro = sc.nextDouble();
	
	    double raio = diametro/2;
	    
		double volume = (4 * Math.PI * Math.pow(raio, 3))/3;
		
		System.out.printf("Area: %.2f", volume);
		
		sc.close();
	}
}
/*

Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

1. Entrar via teclado com a base e a altura de um retângulo, calcular e exibir sua
área.
*/
import java.util.Scanner;
public class TP01EX02
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor da aresta do quadrado: ");
		double aresta = sc.nextDouble();
		
		double area = aresta*aresta;
		
		System.out.printf("Area: %.2f", area);
		
		sc.close();
	}
}
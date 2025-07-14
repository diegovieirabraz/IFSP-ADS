package TP01EX11;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX11
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor do diametro: ");
		double diametro = sc.nextDouble();
	
	    double r = diametro/2;
	    
	    double area = Math.PI*Math.pow(r, 2);
		
		System.out.printf("Area do circulo: %.2f", area);
		
		sc.close();
	}
}
package TP01EX16;
/*
Turma:ADS371
Nome: Adriano Júnior de Souza Almeida
Nome: Diego Vieira Braz 

9. Calcular e exibir a tensão de um determinado circuito eletrônico a partir dos
valores da resistência e corrente elétrica que serão digitados. Utilize a lei de Ohm.
*/
import java.util.Scanner;
public class TP01EX16
{
	public static void main(String[] args) {
	    
	    Scanner sc = new Scanner(System.in);
	    
		System.out.println("Digite o valor do angulo em graus: ");
		double graus = sc.nextDouble();
		
		double radians = Math.toRadians(graus);
	    
	    double sin = Math.sin(radians);
		double cos = Math.cos(radians);
		double tan = Math.tan(radians);
		double sec = 1/cos;
		
		System.out.printf("Seno: %.2f\n", sin);
		System.out.printf("Cos: %.2f\n", cos);
		System.out.printf("Tan: %.2f\n", tan);
		System.out.printf("Sec: %.2f\n", sec);
		
		sc.close();
	}
}
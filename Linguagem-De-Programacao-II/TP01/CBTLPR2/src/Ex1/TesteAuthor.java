package Ex1;

/*
    Nome: Diego Vieira Braz Prontuario: 3029719

    Exercicio 01

    Uma classe chamada Author é desenhada para servir de
    modelo para autores de livros, veja abaixo:
*/

public class TesteAuthor {
    public static void main(String[] args) {
        Author a1 = new Author("Diego Vieira Braz", "diego@vieira.com.br", 'M');
        System.out.println("Testando contrutor e toString =\n" + a1);

         a1.setEmail("diego@braz@braz.com.br");

        System.out.println("Testando os gets e o set " + a1.getName() + "\n" + a1.getEmail() + "\n" + a1.getGender());
    }
}

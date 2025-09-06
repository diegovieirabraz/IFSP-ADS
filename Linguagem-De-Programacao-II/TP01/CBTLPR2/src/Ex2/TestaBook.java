package Ex2;
import Ex1.Author;
/*
    Nome: Diego Vieira Braz Prontuario: 3029719

    Exercicio 02

    Um livro pode ser escrito por um ou muitos autores, por esta razão a classe Book
    deve ter um array de autores, conforme o modelo abaixo:
 */

public class TestaBook {
    public static void main(String[] args) {

        Author[] authors = new Author[2];
        authors[0] = new Author("Autor 01", "autor01@somewhere.com.br", 'm');
        authors[1] = new Author("Autor 02", "autor02@nowhere.com.br", 'm');

        Book b1 = new Book("Gods Americans",authors, 100.00, 10 );


        System.out.println(b1);
    }

}

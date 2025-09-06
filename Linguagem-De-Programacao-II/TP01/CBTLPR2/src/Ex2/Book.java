package Ex2;
import Ex1.Author;

import java.util.Arrays;
/*
    Nome: Diego Vieira Braz Prontuario: 3029719

    Exercicio 02

    Um livro pode ser escrito por um ou muitos autores, por esta razão a classe Book
    deve ter um array de autores, conforme o modelo abaixo:
 */
public class Book {

    private String name;
    private Author[] authors;
    private Double price;
    private int qty;

    public Book(String name, Author[] authors, Double price, int qty) {
        this.name = name;
        this.authors = authors;
        this.price = price;
        this.qty = qty;
    }

    public String getName() {
        return name;
    }

    public Author[] getAuthors() {
        return authors;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public int getQty() {
        return qty;
    }

    public void setQty(int qty) {
        this.qty = qty;
    }

    public String getAuthoeNames()
    {
        StringBuilder name = new StringBuilder();
        for(int i = 0; i < authors.length; i ++){
            name.append("autor ").append(i).append(" = ");
            name.append(authors[i].getName());
            if(i < authors.length - 1){
                name.append(",");
            }
        }
        return name.toString();
    }

    @Override
    public String toString() {
        return "Ex2.Book{" +
                "name='" + name + '\'' +
                ", authors=" + Arrays.toString(authors) +
                ", price=" + price +
                ", qty=" + qty +
                '}';
    }






































}

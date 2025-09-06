package Ex1;

/*
    Nome: Diego Vieira Braz Prontuario: 3029719

    Exercicio 01

    Uma classe chamada Author é desenhada para servir de
    modelo para autores de livros, veja abaixo:
*/

public class Author {

    private String name;
    private String email;
    private  char gender;

    public Author(String name, String email, char gender) {
        this.name = name;
        this.email = email;
        this.gender = gender;
    }

    public String getName() {
        return name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public char getGender() {
        return gender;
    }

    @Override
    public String toString() {
        return "Ex1.Author{" +
                "name='" + name + '\'' +
                ", email='" + email + '\'' +
                ", gender=" + gender +
                '}';
    }

}

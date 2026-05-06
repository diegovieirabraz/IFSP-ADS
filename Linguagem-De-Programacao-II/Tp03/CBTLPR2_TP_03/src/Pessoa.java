public class Pessoa {
    // Contador estático de pessoas "setadas"
    private static int kp = 0;

    private String nome;
    private char sexo;
    private int idade;

    public Pessoa() {
    }

    public Pessoa(String nome, char sexo, int idade) {
        setKp();
        this.nome = nome;
        this.sexo = sexo;
        this.idade = idade;
    }

    // Incrementa o contador de pessoas
    public static void setKp() {
        kp++;
    }

    public static int getKp() {
        return kp;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setSexo(char sexo) {
        this.sexo = sexo;
    }

    public void setIdade(int idade) {
        this.idade = idade;
    }

    public String getNome() {
        return nome;
    }

    public char getSexo() {
        return sexo;
    }

    public int getIdade() {
        return idade;
    }
}

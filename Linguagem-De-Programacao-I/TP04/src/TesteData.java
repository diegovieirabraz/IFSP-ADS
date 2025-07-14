/*
Turma:ADS371
Nome: Diego Vieira Braz
*/
public class TesteData {
    public static void main(String[] args) {
        Data data1 = new Data();
        System.out.println("Data digitada: " + data1.mostra1());
        System.out.println("Data por extenso: " + data1.mostra2());
        System.out.println("Ano bissexto? " + (data1.bissexto() ? "Sim" : "Não"));
        System.out.println("Dias transcorridos: " + data1.diasTranscorridos());
        data1.apresentaDataAtual();

        Data data2 = new Data(29, 2, 2024);
        System.out.println("\nData criada: " + data2.mostra1());
    }
}

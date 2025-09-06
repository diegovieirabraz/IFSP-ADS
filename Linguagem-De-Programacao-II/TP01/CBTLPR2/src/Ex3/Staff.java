package Ex3;
/*
       Nome: Diego Vieira Braz Prontuario: 3029719

       Exercicio 03

       Implemente o sistema representado pelo diagrama abaixo.
       Obrigatório implementar uma classe de testes para todos os métodos das classes Staff e Student.
*/

public class Staff extends  Person{

    private String school;
    private double pay;

    public Staff(String name, String address, String school, double pay) {
        super(name, address);
        this.school = school;
        this.pay = pay;
    }

    public String getSchool() {
        return school;
    }

    public void setSchool(String school) {
        this.school = school;
    }

    public double getPay() {
        return pay;
    }

    public void setPay(double pay) {
        this.pay = pay;
    }

    @Override
    public String toString() {
        return "Staff{" +
                "school='" + school + '\'' +
                ", pay=" + pay +
                '}';
    }
}

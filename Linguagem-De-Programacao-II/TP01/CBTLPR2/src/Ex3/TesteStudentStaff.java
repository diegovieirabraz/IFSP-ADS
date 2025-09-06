package Ex3;
/*
       Nome: Diego Vieira Braz Prontuario: 3029719

       Exercicio 03

       Implemente o sistema representado pelo diagrama abaixo.
       Obrigatório implementar uma classe de testes para todos os métodos das classes Staff e Student.
*/

public class TesteStudentStaff {
    public static void main(String[] args) {
        Student student = new Student("Diego Vieira", "Rua: São Paulo,14","TI", 27, 100.00);

        student.setAddress("Avenida Brasil, 99");

        System.out.println("Teste getNome: " + student.getName());
        System.out.println("Teste getAddress: " + student.getAddress());

        student.setProgram("Artes Cenicas");
        student.setYear(28);
        student.setFee(120);
        System.out.println("Program: " + student.getProgram());
        System.out.println("Year: " + student.getYear());
        System.out.println("Fee: " + student.getFee());

        Staff staff = new Staff("Maria Oliveira", "Praça da Sé, 789", "IFSP", 4500.00);

        System.out.println(staff);

        System.out.println("Name: " + staff.getName());
        System.out.println("Address: " + staff.getAddress());
        System.out.println("School: " + staff.getSchool());
        System.out.println("Pay: " + staff.getPay());

        System.out.println("\n3. Testando todos os Setters:");
        staff.setAddress("Alameda dos Anjos, 101");
        staff.setSchool("IFSP Campus Cubatão");
        staff.setPay(4750.50);
        System.out.println("Valores alterados: " + staff);
    }

}

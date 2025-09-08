using MVC_Cursos;

static void Main(string[] args)
{
    Escola escola = new Escola();
    int opcao = -1;
    while (opcao != 0)
    {
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar curso");
        Console.WriteLine("2. Pesquisar curso");
        Console.WriteLine("3. Remover curso");
      

        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                // Implementação para adicionar curso
                break;
            case 2:
                // Implementação para pesquisar curso
                break;
                // continue para as demais opções
        }
    }
}

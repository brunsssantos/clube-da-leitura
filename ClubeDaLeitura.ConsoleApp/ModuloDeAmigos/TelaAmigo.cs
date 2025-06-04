namespace ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;

public class TelaAmigo
{
    public char ApresentarMenu()
    {
        Console.WriteLine("Clube da Leitura");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastrar amigos");
        Console.WriteLine("2 - Editar amigo");
        Console.WriteLine("3 - Excluir amigo");
        Console.WriteLine("4 - Visualizar amigos");
        Console.WriteLine("5 - Visualizar empréstimos de um amigo");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;




    }
}

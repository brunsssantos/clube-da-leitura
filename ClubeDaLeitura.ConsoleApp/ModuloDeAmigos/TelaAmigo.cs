using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;

public class TelaAmigo : TelaBase
{
    public TelaAmigo(RepositorioAmigo repositorio) : base("Amigo", repositorio)
    {
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Amigos\n");

        Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}",
            "Id", "Nome", "Responsável", "Telefone");

        EntidadeBase[] amigos = repositorio.SelecionarRegistros();

        foreach (Amigo a in amigos)
        {
            if (a == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}",
                a.id, a.Nome, a.NomeResponsavel, a.Telefone);
        }

        Console.ReadLine();
    }

    protected override EntidadeBase ObterDados()
    {
        Console.Write("Digite o nome do amigo: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o nome do responsável: ");
        string nomeResponsavel = Console.ReadLine();

        Console.Write("Digite o telefone ((XX) XXXXX-XXXX): ");
        string telefone = Console.ReadLine();

        Amigo amigo = new Amigo();
        amigo.Nome = nome;
        amigo.NomeResponsavel = nomeResponsavel;
        amigo.Telefone = telefone;

        return amigo;
    }
}

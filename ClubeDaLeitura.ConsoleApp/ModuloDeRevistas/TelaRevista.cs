using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

public class TelaRevista : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
        : base("Revista", repositorioRevista)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Revistas\n");
        Console.WriteLine("{0,-10} | {1,-30} | {2,-10} | {3,-20} | {4,-20} | {5,-20}",
            "Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status");

        EntidadeBase[] revistas = repositorio.SelecionarRegistros();

        for (int i = 0; i < revistas.Length; i++)  
        {
            Revista r = (Revista)revistas[i];
            if (r == null)
                continue;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-10} | {3,-20} | {4,-20} | {5,-20}",
                r.id, r.Titulo, r.NumeroEdicao, r.Ano, r.Caixa.Etiqueta, r.Status);
        }

        Console.ReadLine();
    }

    private void VisualizarCaixas()
    {
       
        Console.WriteLine("Visualização de Caixas\n");

        Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo");

        EntidadeBase[] caixas = repositorioCaixa.SelecionarRegistros();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = (Caixa)caixas[i];

            if (c == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                c.id, c.Etiqueta, c.Cor, c.DiasEmprestimo);
        }

        Console.ReadLine();
    }

    protected override EntidadeBase ObterDados()
    {
        Console.Write("Digite o título da revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o número da edição: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o ano de publicação: ");
        int ano = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nCaixas disponíveis:");
        VisualizarCaixas();

        Console.Write("Digite o ID da caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idCaixa);

        Revista revista = new Revista(titulo, numeroEdicao, ano, caixaSelecionada);

        return revista;
    }
}

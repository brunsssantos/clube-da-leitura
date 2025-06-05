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
        Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-5} | {4,-15} | {5,-10}",
            "Id", "Título", "Edição", "Ano", "Caixa", "Status");

        EntidadeBase[] revistas = repositorio.SelecionarRegistros();

        foreach (Revista r in revistas)
        {
            if (r == null)
                continue;

            Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-5} | {4,-15} | {5,-10}",
                r.id, r.titulo, r.numeroEdicao, r.ano, r.caixa.etiqueta, r.status);
        }

        Console.ReadLine();
    }

    private void VisualizarCaixas()
    {
        EntidadeBase[] caixas = repositorioCaixa.SelecionarRegistros();

        foreach (Caixa caixa in caixas)
        {
            if (caixa == null)
                continue;

            Console.WriteLine($"ID: {caixa.id} | Etiqueta: {caixa.etiqueta} | Cor: {caixa.cor}");
        }
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

        Revista revista = new Revista();
        revista.titulo = titulo;
        revista.numeroEdicao = numeroEdicao;
        revista.ano = ano;
        revista.caixa = caixaSelecionada;
        revista.status = "Disponível";

        return revista;
    }
}

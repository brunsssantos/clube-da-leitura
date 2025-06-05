using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

public class TelaCaixa : TelaBase
{
    public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa", repositorio)
    {
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Caixas\n");

        Console.WriteLine("{0, -10} | {1, -20} | {2, -10} | {3, -15}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo");

        EntidadeBase[] caixas = repositorio.SelecionarRegistros();

        foreach (Caixa c in caixas)
        {
            if (c == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -10} | {3, -15}",
                c.id, c.etiqueta, c.cor, c.diasEmprestimo);
        }

        Console.ReadLine();
    }

    protected override EntidadeBase ObterDados()
    {
        Console.Write("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa (ex: Azul, Vermelha ou #FF0000): ");
        string cor = Console.ReadLine();

        Console.Write("Digite os dias de empréstimo (padrão 7): ");
        int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa caixa = new Caixa();
        caixa.etiqueta = etiqueta;
        caixa.cor = cor;
        caixa.diasEmprestimo = diasEmprestimo;

        return caixa;
    }

}

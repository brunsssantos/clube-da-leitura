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

        Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo");

        EntidadeBase[] caixas = repositorio.SelecionarRegistros();

        for (int i = 0; i < caixas.Length; i ++)
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
        Console.Write("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa (ex: Azul, Vermelha ou #FF0000): ");
        string cor = Console.ReadLine();

        Console.Write("Digite os dias de empréstimo (padrão 7): ");
        int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo);
        caixa.Etiqueta = etiqueta;
        caixa.Cor = cor;
        caixa.DiasEmprestimo = diasEmprestimo;
        return caixa;
    }

}

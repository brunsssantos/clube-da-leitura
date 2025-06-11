using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeEmprestimos;

public class TelaEmprestimo : TelaBase
{
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorio, RepositorioAmigo repoAmigo, RepositorioRevista repoRevista)
        : base("Empréstimo", repositorio)
    {
        this.repositorioAmigo = repoAmigo;
        this.repositorioRevista = repoRevista;
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Empréstimos\n");

        Console.WriteLine("{0,-10} | {1,-15} | {2,-20} | {3,-15} | {4,-15} | {5,-10}",
            "Id", "Amigo", "Revista", "Empréstimo", "Devolução", "Status");

        EntidadeBase[] emprestimos = repositorio.SelecionarRegistros();

        foreach (Emprestimo e in emprestimos)
        {
            if (e == null)
                continue;

            Console.WriteLine("{0,-10} | {1,-15} | {2,-20} | {3,-15} | {4,-15} | {5,-10}",
                e.id, e.amigo.Nome, e.revista.titulo,
                e.dataEmprestimo.ToShortDateString(),
                e.dataDevolucao.ToShortDateString(),
                e.status);
        }

        Console.ReadLine();
    }

    protected override EntidadeBase ObterDados()
    {
        Console.WriteLine("Lista de Amigos:");
        foreach (Amigo a in repositorioAmigo.SelecionarRegistros())
            if (a != null)
                Console.WriteLine($"ID: {a.id} - {a.Nome}");

        Console.Write("Informe o ID do amigo: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());
        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

        Console.WriteLine("Lista de Revistas Disponíveis:");
        foreach (Revista r in repositorioRevista.SelecionarRegistros())
            if (r != null && r.status == "Disponível")
                Console.WriteLine($"ID: {r.id} - {r.titulo}");

        Console.Write("Informe o ID da revista: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());
        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(idRevista);

        DateTime dataEmprestimo = DateTime.Now;
        
        int dias = revistaSelecionada.caixa.DiasEmprestimo;
        DateTime dataDevolucao = dataEmprestimo.AddDays(dias);

        revistaSelecionada.status = "Emprestada";

        Emprestimo emprestimo = new Emprestimo();
        emprestimo.amigo = amigoSelecionado;
        emprestimo.revista = revistaSelecionada;
        emprestimo.dataEmprestimo = dataEmprestimo;
        emprestimo.dataDevolucao = dataDevolucao;
        emprestimo.status = "Aberto";

        return emprestimo;
    }
}

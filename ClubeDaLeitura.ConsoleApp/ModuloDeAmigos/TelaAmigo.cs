using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;

public class TelaAmigo : TelaBase
{
    public TelaAmigo(RepositorioAmigo repositorio) : base("Amigo", repositorio)
    {
    }

    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.WriteLine();

        Amigo novoRegistro = (Amigo)ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(erros);
            Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("\nDigite ENTER para contnuar...");
            Console.ReadLine();


            CadastrarRegistro();
            return;
        }

        EntidadeBase [] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Amigo amigoRegistrado = (Amigo)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (amigoRegistrado.Nome == novoRegistro.Nome || amigoRegistrado.Telefone == novoRegistro.Telefone)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                Console.ResetColor();

                Console.WriteLine("\nDigite ENTER para contnuar...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }
        }

        repositorio.CadastrarRegistro(novoRegistro);

        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso");
        Console.ReadLine();
    }

    public override void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine($"Edição de {nomeEntidade}");
        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine($"Digite o id do {nomeEntidade} que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Amigo registroAtualizado = (Amigo)ObterDados();

        string erros = registroAtualizado.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(erros);
            Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("\nDigite ENTER para contnuar...");
            Console.ReadLine();


            EditarRegistros();
            return;
        }

        EntidadeBase[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Amigo amigoRegistrado = (Amigo)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (amigoRegistrado.id != idSelecionado && (amigoRegistrado.Nome == registroAtualizado.Nome || amigoRegistrado.Telefone == registroAtualizado.Telefone))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                Console.ResetColor();

                Console.WriteLine("\nDigite ENTER para contnuar...");
                Console.ReadLine();

                EditarRegistros();

                return;
            }


            repositorio.EditarRegistro(idSelecionado, registroAtualizado);

        Console.WriteLine($"\n{nomeEntidade} editado com sucesso");
        Console.ReadLine();
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Amigos\n");

        Console.WriteLine();

        Console.WriteLine("{0, -10} | {1, -30} | {2, -30} | {3, -20}",
            "Id", "Nome", "Responsável", "Telefone");

        EntidadeBase[] amigos = repositorio.SelecionarRegistros();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = (Amigo)amigos[i];

            if (a == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -30} | {2, -30} | {3, -20}",
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

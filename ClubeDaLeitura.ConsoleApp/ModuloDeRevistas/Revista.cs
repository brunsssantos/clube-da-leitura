using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

public class Revista : EntidadeBase
{
    public string Titulo {  get; set; }
    public int NumeroEdicao { get; set; }
    public int Ano { get; set; }
    public string Status { get; set; }
    public Caixa Caixa { get; set; }

    public Revista(string titulo, int numeroEdicao, int ano, Caixa caixa)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        Ano = ano;
        Status = "Disponível";
        Caixa = caixa;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Revista revistaAtualizada = (Revista)registroAtualizado;

        this.Titulo = revistaAtualizada.Titulo;
        this.NumeroEdicao = revistaAtualizada.NumeroEdicao;
        this.Ano = revistaAtualizada.Ano;
        this.Caixa = revistaAtualizada.Caixa;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 100)
            erros += "Título deve ter entre 2 e 100 caracteres.\n";

        if (NumeroEdicao <= 0)
            erros += "Número da edição deve ser maior que zero.\n";

        if (Ano < DateTime.MinValue.Year || Ano > DateTime.Now.Year)
            erros += "Ano inválido.\n";

        if (Caixa == null)
            erros += "A revista precisa estar associada a uma caixa.\n";

        return erros;
    }
}

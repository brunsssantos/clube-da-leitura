using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

public class Revista : EntidadeBase
{
    public string titulo;
    public int numeroEdicao;
    public int ano;
    public string status;
    public Caixa caixa;
    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Revista revistaAtualizada = (Revista)registroAtualizado;

        this.titulo = revistaAtualizada.titulo;
        this.numeroEdicao = revistaAtualizada.numeroEdicao;
        this.ano = revistaAtualizada.ano;
        this.status = revistaAtualizada.status;
        this.caixa = revistaAtualizada.caixa;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo) || titulo.Length < 2 || titulo.Length > 100)
            erros += "Título deve ter entre 2 e 100 caracteres.\n";

        if (numeroEdicao <= 0)
            erros += "Número da edição deve ser maior que zero.\n";

        if (ano < 1900 || ano > DateTime.Now.Year)
            erros += "Ano inválido.\n";

        if (caixa == null)
            erros += "A revista precisa estar associada a uma caixa.\n";

        return erros;
    }
}

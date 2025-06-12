using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeEmprestimos;

public class Emprestimo : EntidadeBase
{
    public Amigo amigo;
    public Revista revista;
    public DateTime dataEmprestimo;
    public DateTime dataDevolucao;
    public string status;
    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)registroAtualizado;

        this.amigo = emprestimoAtualizado.amigo;
        this.revista = emprestimoAtualizado.revista;
        this.dataEmprestimo = emprestimoAtualizado.dataEmprestimo;
        this.dataDevolucao = emprestimoAtualizado.dataDevolucao;
        this.status = emprestimoAtualizado.status;
    }

    public override string Validar()
    {
        string erros = "";

        if (amigo == null)
            erros += "Amigo é obrigatório.\n";

        if (revista == null || revista.Status != "Disponível")
            erros += "A revista deve estar disponível.\n";

        return erros;
    }
}

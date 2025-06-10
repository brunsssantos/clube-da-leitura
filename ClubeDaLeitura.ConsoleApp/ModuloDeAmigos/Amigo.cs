using System.Text.RegularExpressions;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; }
    public string NomeResponsavel { get; set; }
    public string Telefone { get; set; }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Amigo amigoAtualizado = (Amigo)registroAtualizado;

        this.Nome = amigoAtualizado.Nome;
        this.NomeResponsavel = amigoAtualizado.NomeResponsavel;
        this.Telefone = amigoAtualizado.Telefone;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' deve ter entre 3 e 100 caracteres.\n";

        if (string.IsNullOrWhiteSpace(NomeResponsavel) || NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
            erros += "O campo 'Nome do Responsável' deve ter entre 3 e 100 caracteres.\n";

        string padraoTelefone = @"^\(\d{2}\)\s\d{4,5}-\d{4}$";
        if (!Regex.IsMatch(Telefone, padraoTelefone))
            erros += "Telefone inválido. Formato esperado: (XX) XXXXX-XXXX\n";

        return erros;
    }
}


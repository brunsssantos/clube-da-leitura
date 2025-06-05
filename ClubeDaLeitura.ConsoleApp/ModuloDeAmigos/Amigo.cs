using System.Text.RegularExpressions;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;

public class Amigo : EntidadeBase
{
    public string nome;
    public string nomeResponsavel;
    public string telefone;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Amigo amigoAtualizado = (Amigo)registroAtualizado;

        this.nome = amigoAtualizado.nome;
        this.nomeResponsavel = amigoAtualizado.nomeResponsavel;
        this.telefone = amigoAtualizado.telefone;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3 || nome.Length > 100)
            erros += "O campo 'Nome' deve ter entre 3 e 100 caracteres.\n";

        if (string.IsNullOrWhiteSpace(nomeResponsavel) || nomeResponsavel.Length < 3 || nomeResponsavel.Length > 100)
            erros += "O campo 'Responsável' deve ter entre 3 e 100 caracteres.\n";

        string padraoTelefone = @"^\(\d{2}\)\s\d{4,5}-\d{4}$";
        if (!Regex.IsMatch(telefone, padraoTelefone))
            erros += "Telefone inválido. Formato esperado: (XX) XXXXX-XXXX\n";

        return erros;
    }
}


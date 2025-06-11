using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

public class Caixa : EntidadeBase
{
    public string Etiqueta { get; set; }
    public string Cor { get; set; }
    public int DiasEmprestimo { get; set; }

    public Caixa(string etiqueta, string cor)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = 7;
    }
    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Caixa caixaAtualizada = (Caixa)registroAtualizado;

        this.Etiqueta = caixaAtualizada.Etiqueta;
        this.Cor = caixaAtualizada.Cor;
        this.DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
            erros += "Etiqueta é obrigatória e deve ter no máximo 50 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Cor))
            erros += "A cor da caixa é obrigatória.\n";

        if (DiasEmprestimo <= 0)
            erros += "Dias de empréstimo deve ser maior que 0.\n";

        return erros;
    }
}

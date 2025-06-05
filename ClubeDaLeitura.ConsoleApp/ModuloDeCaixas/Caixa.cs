using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;

public class Caixa : EntidadeBase
{
    public string etiqueta;
    public string cor;
    public int diasEmprestimo;
    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Caixa caixaAtualizada = (Caixa)registroAtualizado;

        this.etiqueta = caixaAtualizada.etiqueta;
        this.cor = caixaAtualizada.cor;
        this.diasEmprestimo = caixaAtualizada.diasEmprestimo;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(etiqueta) || etiqueta.Length > 50)
            erros += "Etiqueta é obrigatória e deve ter no máximo 50 caracteres.\n";

        if (string.IsNullOrWhiteSpace(cor))
            erros += "A cor da caixa é obrigatória.\n";

        if (diasEmprestimo <= 0)
            erros += "Dias de empréstimo deve ser maior que 0.\n";

        return erros;
    }
}

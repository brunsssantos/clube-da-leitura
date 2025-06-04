﻿using ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;
    public TelaPrincipal()
    {
    }
    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|           Clube da Leitura           |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Amigos");
        Console.WriteLine("2 - Controle de Caixas");
        Console.WriteLine("3 - Controle de Revistas");
        Console.WriteLine("4 - Controle de Empréstimos");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Escolha uma das opções");
        opcaoEscolhida = Console.ReadLine()[0];

    }

    public TelaBase ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaAmigos;

        else if (opcaoEscolhida == '2')
            return telaCaixas;

        else if (opcaoEscolhida == '3')
            return telaRevistas;

        else if (opcaoEscolhida == '4')
            return telaEmprestimos;

        return null;
    }
}

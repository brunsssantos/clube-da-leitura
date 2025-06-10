# Clube da Leitura

## Introdução

O **Clube da Leitura** é um sistema de cadastro e controle de empréstimos de revistas, feito em **C#** para execução no **console**, utilizando os princípios da **Programação Orientada a Objetos (POO)**.

Você poderá gerenciar amigos, caixas organizadoras, revistas e os empréstimos realizados entre eles, com regras de negócio integradas e estrutura em camadas.

---

## Como Usar

1. Ao executar o programa, será exibido o **menu principal** com as opções:
   - Controle de Amigos
   - Controle de Caixas
   - Controle de Revistas
   - Controle de Empréstimos
   - Sair

2. Dentro de cada módulo, o sistema permite:
   - Cadastrar
   - Visualizar
   - Editar
   - Excluir registros (respeitando as regras de negócio)

3. Funcionalidade de empréstimos:
   - Só permite um empréstimo ativo por amigo
   - A devolução é calculada automaticamente com base na "caixa"
   - O status da revista é atualizado automaticamente

---

## Estrutura do Código

- Projeto organizado em **camadas separadas**:
  - `Compartilhado` → Código base reutilizável (repositorios e telas genéricas)
  - `ModuloDeAmigos` → Cadastro e gestão de amigos
  - `ModuloDeCaixas` → Cadastro de caixas organizadoras
  - `ModuloDeRevistas` → Cadastro e controle de revistas
  - `ModuloDeEmprestimos` → Empréstimos e devoluções

  ## Tecnologias Utilizadas: 
[![Tecnologias](https://skillicons.dev/icons?i=git,github,cs,dotnet,visualstudio,)](https://skillicons.dev)
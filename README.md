# Antivirus Status Checker

Um projeto Proof-of-Concept (POC) desenvolvido em C# para consultar e exibir o status dos antivírus instalados em um sistema Windows utilizando WMI.

## Sumário

- [Visão Geral](#visão-geral)
- [Recursos](#recursos)
- [Pré-requisitos](#pré-requisitos)
- [Como Executar](#como-executar)
- [Estrutura do Projeto](#estrutura-do-projeto)

## Visão Geral

O **Antivirus Status Checker** é uma ferramenta simples que utiliza o Windows Management Instrumentation (WMI) para consultar informações sobre antivírus instalados no sistema. O projeto lê dados do namespace `\\.\root\SecurityCenter2` e interpreta o estado do antivírus, informando se a proteção em tempo real está habilitada, pausada ou expirada, além do status das assinaturas (banco de vírus).

## Recursos

- Consulta e exibição do status dos antivírus instalados.
- Interpretação dos estados de proteção em tempo real:
  - Habilitada
  - Pausada/Suspensa
  - Expirada (desatualizada ou licença expirada)
  - Desabilitada
- Verificação do status das assinaturas:
  - Atualizadas
  - Desatualizadas
- Exibição dos resultados no console, utilizando a sobrecarga do método `ToString()` em um objeto de dados.

## Pré-requisitos

- **Sistema Operacional:** Windows
- **.NET Framework / .NET Core:** Projeto compatível com as versões modernas do .NET.
- **Permissões:** O usuário deve ter permissões adequadas para acessar o namespace `SecurityCenter2` via WMI.

## Como Executar

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/seu-usuario/AntivirusStatusChecker.git
   cd AntivirusStatusChecker
   ```

2. **Abra o projeto em seu IDE (Visual Studio, VS Code, etc.).**

3. **Compile o projeto:**

   No Visual Studio, abra a solução e clique em "Build".  
   Ou, utilizando a CLI do .NET:

   ```bash
   dotnet build
   ```

4. **Execute o projeto:**

   ```bash
   dotnet run
   ```

   Os resultados serão exibidos no console com informações formatadas sobre cada antivírus encontrado.

## Estrutura do Projeto

A seguir, uma visão geral dos principais componentes do projeto:

- **`AVStatusChecker`**  
  Classe responsável por realizar a consulta via WMI e interpretar os estados dos antivírus.

- **`AntivirusInfo`**  
  Classe que armazena os dados de cada antivírus, como nome, status da proteção em tempo real e status do banco de vírus. Conta com um método `ToString()` sobrescrito para exibição formatada dos dados.

- **Consulta WMI:**  
  O projeto utiliza a query `SELECT * FROM AntiVirusProduct` no namespace `\\.\root\SecurityCenter2` para obter os dados necessários.

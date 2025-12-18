# **XpertEducation - Aplicação de Gestão Educacional com APIs, CQRS, DDD e Testes**

## **1. Apresentação**

Bem-vindo ao repositório do projeto **XpertEducation**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo 3 **Arquitetura, Modelagem e Qualidade de Software**.
O objetivo principal desenvolver uma aplicação de Gestão Educacional que permite aos gerenciar Cursos e Aulas e os Alunos matricular em cursos, realizar pagamentos, realizar aulas e concluir curso para obter certificado.
<!-- [
  Descreva livremente mais detalhes do seu projeto aqui.
] -->

### **Autor(es)**
- **Victor Higaki**

## **2. Proposta do Projeto**

O projeto consiste em:

- **Aplicação MVC:** Interface web para interação com a Gestão de Mini Loja Virtual.
- **API RESTful:** Exposição dos recursos da Gestão de Mini Loja Virtual para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, diferenciando administradores e usuários comuns.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server / SQLite
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:

- src/
  - XpertEducation.WebApps.Api/ - API
  - XpertEducation.GestaoConteudo.Application/
  - XpertEducation.GestaoConteudo.Data/
  - XpertEducation.GestaoConteudo.Domain/
  - XpertEducation.GestaoConteudo.Application.Tests/
  - XpertEducation.GestaoConteudo.Data.Tests/
  - XpertEducation.GestaoConteudo.Domain.Tests/
  - XpertEducation.GestaoAlunos.Application/
  - XpertEducation.GestaoAlunos.Data/
  - XpertEducation.GestaoAlunos.Domain/
  - XpertEducation.GestaoAlunos.Application.Tests/
  - XpertEducation.GestaoAlunos.Data.Tests/
  - XpertEducation.GestaoAlunos.Domain.Tests/
  - XpertEducation.PagamentoFaturamento.AntiCorruption/
  - XpertEducation.PagamentoFaturamento.Business/
  - XpertEducation.PagamentoFaturamento.Data/
  - XpertEducation.PagamentoFaturamento.AntiCorruption.Tests/
  - XpertEducation.PagamentoFaturamento.Business.Tests/
  - XpertEducation.PagamentoFaturamento.Data.Tests/
- README.md - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

#EDITAR 
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.
- **Autenticação e Autorização:** Diferenciação entre alunos comuns e administradores.
- **Testes Unitários:"" Documentação e garantia de funcionamento do sistema.
- **CQRS:** Aplicação do padrão Command Query Responsability Segregation
- **API RESTful:** Exposição de endpoints para operações via API.

## **6. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 9.0 ou superior
- SQL Server / SQLite
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/victorhigaki/XpertEducation.git`
   - `cd XpertEducation`

2. **Configuração do Banco de Dados:**
   - No arquivo `appsettings.json`, configure a string de conexão do SQL Server.
   - Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

3. **Executar a API:**
   - `cd src/XpertEducation.Api/`
   - `dotnet run`
   - Acesse a documentação da API em: http://localhost:5001/swagger

## **7. Instruções de Configuração**

- **JWT para API:** As chaves de configuração do JWT estão no `appsettings.json`.
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

http://localhost:5001/swagger

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.

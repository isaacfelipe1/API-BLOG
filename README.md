# Hanami API

Este projeto é uma API RESTful construída usando .NET (C#). Ela é projetada para gerenciar posts de maneira eficiente, fornecendo endpoints para criar, ler, atualizar e deletar posts.

## Índice

- [Hanami API](#hanami-api)
  - [Índice](#índice)
  - [Visão Geral do Projeto](#visão-geral-do-projeto)
  - [Funcionalidades](#funcionalidades)
  - [Stack de Tecnologias](#stack-de-tecnologias)
  - [Primeiros Passos](#primeiros-passos)
    - [Pré-requisitos](#pré-requisitos)
    - [Instalação dos Pacotes NuGet](#instalação-dos-pacotes-nuget)
      - [Usando a Interface do Visual Studio](#usando-a-interface-do-visual-studio)
      - [Usando o Console do Gerenciador de Pacotes](#usando-o-console-do-gerenciador-de-pacotes)
    - [Configuração](#configuração)
    - [Executando a Aplicação](#executando-a-aplicação)
  - [Recomendação para Commit de Dados no `app.db`](#recomendação-para-commit-de-dados-no-appdb)
  - [Endpoints da API](#endpoints-da-api)
    - [Criar um Post](#criar-um-post)
    - [Listar Todos os Posts](#listar-todos-os-posts)
    - [Obter um Post Específico](#obter-um-post-específico)
    - [Atualizar um Post](#atualizar-um-post)
    - [Deletar um Post](#deletar-um-post)
  - [Migrações do Banco de Dados](#migrações-do-banco-de-dados)
  - [Contribuindo](#contribuindo)
  - [Licença](#licença)

## Visão Geral do Projeto

A Hanami API é um serviço web robusto e escalável que permite aos usuários gerenciar posts. Ela é construída com uma arquitetura limpa para garantir a facilidade de manutenção e uso.

## Funcionalidades

- Operações CRUD para posts
- Endpoints RESTful
- Gerenciamento de migrações do banco de dados
- Injeção de dependência
- Containerização com Docker

## Stack de Tecnologias

- **.NET (C#)**
- **Entity Framework Core** (ORM)
- **SQLite** (Banco de Dados)
- **Swagger** (Documentação da API)
- **Docker** (Containerização)

## Primeiros Passos

### Pré-requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html)
- [Docker (opcional)](https://www.docker.com/)

### Instalação dos Pacotes NuGet

#### Usando a Interface do Visual Studio

1. Abra o Gerenciador de Pacotes NuGet no Visual Studio:
   - Clique com o botão direito no seu projeto na Solution Explorer.
   - Selecione "Gerenciar Pacotes NuGet...".

2. Instale os seguintes pacotes:
   - `Microsoft.EntityFrameworkCore.Sqlite`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
   - `Swashbuckle.AspNetCore`

#### Usando o Console do Gerenciador de Pacotes

1. Abra o Console do Gerenciador de Pacotes:
   - Vá para "Ferramentas (Tools)" > "Gerenciador de Pacotes NuGet" > "Console do Gerenciador de Pacotes".

2. Execute os seguintes comandos:
   ```powershell
   Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 8.0.5
   Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.5
   Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.5
   Install-Package Swashbuckle.AspNetCore -Version 6.6.2
    ```

### Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/hanami-api.git
   cd hanami-api
   ```

2. Instale as dependências:

   ```bash
   dotnet restore
   ```

### Configuração

Certifique-se de ter um arquivo `appsettings.json` na raiz do projeto com o seguinte conteúdo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Executando a Aplicação

1. Aplique as migrações do banco de dados:

   ```bash
   dotnet ef database update
   ```

2. Execute a aplicação:

   ```bash
   dotnet run
   ```

3. Acesse a documentação da API em `http://localhost:8080/swagger`.

## Recomendação para Commit de Dados no `app.db`

Para garantir que as mudanças no arquivo app.db não sejam incluídas em futuros commits, execute o seguinte comando:

   ```bash
   git update-index --assume-unchanged app.db
   ```

Esse comando faz com que o Git ignore futuras mudanças no arquivo app.db no seu repositório local.

## Endpoints da API

### Criar um Post

- **URL:** `/api/posts`
- **Método:** `POST`
- **Corpo da Requisição:**

  ```json
  {
    "title": "Título do Post",
    "content": "Conteúdo do post"
  }
  ```

- **Resposta:**

  ```json
  {
    "id": 1,
    "title": "Título do Post",
    "content": "Conteúdo do post",
    "createdAt": "2024-05-27T12:34:56Z"
  }
  ```

### Listar Todos os Posts

- **URL:** `/api/posts`
- **Método:** `GET`
- **Resposta:**

  ```json
  [
    {
      "id": 1,
      "title": "Título do Post",
      "content": "Conteúdo do post",
      "createdAt": "2024-05-27T12:34:56Z"
    }
  ]
  ```

### Obter um Post Específico

- **URL:** `/api/posts/{id}`
- **Método:** `GET`
- **Resposta:**

  ```json
  {
    "id": 1,
    "title": "Título do Post",
    "content": "Conteúdo do post",
    "createdAt": "2024-05-27T12:34:56Z"
  }
  ```

### Atualizar um Post

- **URL:** `/api/posts/{id}`
- **Método:** `PUT`
- **Corpo da Requisição:**

  ```json
  {
    "title": "Título Atualizado",
    "content": "Conteúdo atualizado"
  }
  ```

- **Resposta:**

  ```json
  {
    "id": 1,
    "title": "Título Atualizado",
    "content": "Conteúdo atualizado",
    "createdAt": "2024-05-27T12:34:56Z",
    "updatedAt": "2024-05-27T12:45:00Z"
  }
  ```

### Deletar um Post

- **URL:** `/api/posts/{id}`
- **Método:** `DELETE`
- **Resposta:** `204 No Content`

## Migrações do Banco de Dados

Para adicionar uma nova migração:

```bash
dotnet ef migrations add NomeDaMigracao
```

Para atualizar o banco de dados:

```bash
dotnet ef database update
```

## Contribuindo

Contribuições são bem-vindas! Por favor, siga estes passos:

1. Faça um fork do repositório.
2. Crie uma nova branch (`git checkout -b feature/SuaFeature`).
3. Faça suas alterações.
4. Faça o commit de suas alterações (`git commit -m "Add some feature"`).
5. Faça o push para a branch (`git push origin feature/SuaFeature`).
6. Crie um novo Pull Request.

## Licença

Este projeto é licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

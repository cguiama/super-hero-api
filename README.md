# 🦸‍♂️ Hero Management API

API REST para gerenciamento de super-heróis, desenvolvida como parte de um desafio FullStack. O projeto utiliza arquitetura **Clean Architecture**, **.NET 8**, **Entity Framework Core (PostgreSQL)**, **CQRS** com **MediatR** e **FluentValidation**.

---

## 📚 Funcionalidades Implementadas

- ✅ Cadastro de herói com dados completos
- ✅ Associação de múltiplos superpoderes a um herói
- ✅ Listagem de heróis
- ✅ Detalhamento de herói por ID
- ✅ Atualização e exclusão de herói
- ✅ Endpoint para listar superpoderes
- ✅ Relacionamento N:N entre heróis e superpoderes via `HeroSuperPowers`
- ✅ Validações com FluentValidation
- ✅ Documentação da API com Swagger

---

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- Entity Framework Core (Code First + PostgreSQL)
- MediatR (CQRS)
- AutoMapper
- FluentValidation
- Swagger (Swashbuckle)

---

## 🧱 Arquitetura

O projeto segue o padrão **Clean Architecture**, com divisão em camadas:

```
HeroManagement/
├── Heroes.Domain/        # Entidades de domínio
├── Heroes.Application/   # Handlers, DTOs, Commands, Queries
├── Heroes.Infrastructure/# DbContext, Repositórios, Mapeamentos
├── Heroes.Api/           # API (Controllers, Program.cs)
```

---


---

## 🧠 Padrão CQRS (Command and Query Responsibility Segregation)

Este projeto aplica o padrão **CQRS**, que separa as responsabilidades de **leitura (Queries)** e **escrita (Commands)** da aplicação. Isso melhora a organização, escalabilidade e testabilidade do código.

### 📌 Benefícios aplicados no projeto:

- 📂 Separação clara entre leitura e escrita
- 📤 Comandos manipulam estado: `CreateHeroCommand`, `UpdateHeroCommand`, etc.
- 📥 Consultas são isoladas e sem efeitos colaterais: `GetHeroByIdQuery`, `GetAllHeroesQuery`, etc.
- 📬 Integração com **MediatR** para centralizar o envio de comandos e queries
- ✅ Facilita a validação e mapeamento em cada lado (leitura e escrita)

---

### 🗂️ Estrutura aplicada:

```
Heroes.Application/
└── Features/
    └── Heroes/
        ├── Commands/
        │   └── CreateHero/
        │       ├── CreateHeroCommand.cs
        │       └── CreateHeroCommandHandler.cs
        ├── Queries/
        │   └── GetHeroById/
        │       ├── GetHeroByIdQuery.cs
        │       └── GetHeroByIdQueryHandler.cs
        └── Dtos/
            └── HeroDto.cs
```

---

### 🔁 Como funciona:

1. O Controller recebe uma requisição
2. Envia um `Command` ou `Query` via **`IMediator.Send()`**
3. O **Handler** do comando ou da query é executado separadamente
4. A camada de persistência (via repositório) é chamada de forma indireta
5. O resultado (ou ação) é retornado ao Controller


## 🗃️ Banco de Dados

- PostgreSQL com Migrations via EF Core
- Superpoderes inseridos diretamente no banco como dados fixos
- Relacionamento N:N entre `Heroes` e `SuperPowers` via tabela de junção `HeroSuperPowers`

---

## 🔗 Endpoints principais (Swagger)

- `GET /api/heroes` — Lista todos os heróis
- `GET /api/heroes/{id}` — Busca herói por ID
- `POST /api/heroes` — Cria novo herói
- `PUT /api/heroes/{id}` — Atualiza herói
- `DELETE /api/heroes/{id}` — Remove herói
- `GET /api/superpowers` — Lista todos os superpoderes disponíveis

---

## 🧪 Como executar o projeto localmente

1. Clonar o repositório
2. Criar o banco no PostgreSQL e ajustar a connection string em `appsettings.json`
3. Rodar as migrations:

```bash
dotnet ef database update --project Heroes.Infrastructure --startup-project Heroes.Api
```

4. Executar o projeto:

```bash
dotnet run --project Heroes.Api
```

5. Acessar o Swagger:
```
https://localhost:{porta}/swagger
```

---

## 🧑‍💻 Próximos passos

- [ ] Iniciar o frontend em Angular 19
- [ ] Tela de cadastro de herói com select múltiplo de superpoderes
- [ ] Deploy e publicação da aplicação

---

## 👨‍💻 Autor

**Guilherme Castro**  
Desenvolvedor Full Stack  
Projeto desenvolvido para desafio técnico
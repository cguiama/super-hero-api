# 🦸‍♂️ Hero Management API + Frontend

API REST e Frontend para gerenciamento de super-heróis, desenvolvidos como parte de um desafio FullStack.
O projeto utiliza arquitetura **Clean Architecture**, **.NET 8**, **Entity Framework Core (PostgreSQL)**, **CQRS** com **MediatR** e **FluentValidation** no backend, além de **Angular 19** com **Micro Frontends (MFE)** no frontend.

---

## 📚 Funcionalidades Implementadas

### Backend
- ✅ Cadastro de herói com dados completos
- ✅ Associação de múltiplos superpoderes a um herói
- ✅ Listagem de heróis
- ✅ Detalhamento de herói por ID
- ✅ Atualização e exclusão de herói
- ✅ Endpoint para listar superpoderes
- ✅ Relacionamento N:N entre heróis e superpoderes via `HeroSuperPowers`
- ✅ Validações com FluentValidation
- ✅ Documentação da API com Swagger

### Frontend
- ✅ Criação de arquitetura inicial com Angular 19 standalone
- ✅ Implementação de Micro Frontends (MFE) usando Module Federation
- ✅ HeroStore implementado com **Signals** para gerenciamento reativo de estado
- ✅ Consumo da API REST do backend
- ✅ Listagem de heróis no frontend
- ✅ Integração backend + frontend 100% funcional

---

## 🛠️ Tecnologias Utilizadas

### Backend
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (PostgreSQL)
- MediatR (CQRS)
- AutoMapper
- FluentValidation
- Swagger (Swashbuckle)

### Frontend
- Angular 19 (Standalone Components)
- Module Federation (Micro Frontends)
- Angular Signals
- RxJS
- SCSS

---

## 🧱 Arquitetura

### Backend
Segue o padrão **Clean Architecture**, com divisão em camadas:

```
HeroManagement/
├── Heroes.Domain/        # Entidades de domínio
├── Heroes.Application/   # Handlers, DTOs, Commands, Queries
├── Heroes.Infrastructure/# DbContext, Repositórios, Mapeamentos
├── Heroes.Api/           # API (Controllers, Program.cs)
```

### Frontend
Organizado em Shell e Micro Frontend (MFE):

```
frontend/
├── heroes-shell/    # Aplicativo principal (host)
├── heroes-mfe/      # MFE dos heróis (listagem, cadastro, etc)
```

---

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

## 🚀 Como executar o projeto localmente

### Backend
1. Clonar o repositório
2. Criar o banco no PostgreSQL e ajustar a connection string em `appsettings.json`
3. Rodar as migrations:

```bash
dotnet ef database update --project Heroes.Infrastructure --startup-project Heroes.Api
```

4. Executar o backend:

```bash
dotnet run --project Heroes.Api
```

5. Acessar o Swagger:

```
https://localhost:{porta}/swagger
```

### Frontend

1. Acessar a pasta `frontend`
2. Rodar o shell e o mfe em dois terminais diferentes:

```bash
cd heroes-mfe
npm install
ng serve --port 4201
```

```bash
cd heroes-shell
npm install
ng serve --port 4200
```

3. Acessar o Frontend:

```
http://localhost:4200/heroes
```

---

## 👨‍💻 Autor

**Guilherme Castro**  
Desenvolvedor Full Stack  
Projeto desenvolvido para desafio técnico FullStack

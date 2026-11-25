# StudyFlow

Aplicação web desenvolvida para organizar matérias, tarefas e sessões de estudo, permitindo acompanhar o progresso e o tempo dedicado a cada matéria.

O projeto foi desenvolvido como prática de desenvolvimento **Full Stack**, utilizando ASP.NET Core no backend, Angular no frontend e SQL Server para persistência dos dados.

## Tecnologias utilizadas

### Backend
- C#
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- REST API
- DTOs e Data Annotations
- Injeção de dependência

### Frontend
- Angular 21
- TypeScript
- HTML5
- CSS3
- Angular Signals
- HttpClient
- Angular Forms

## Funcionalidades implementadas

### Matérias
- Cadastro de matérias.
- Consulta de matérias.
- Atualização de matérias.
- Exclusão de matérias.
- Validação dos dados.

### Tarefas
- CRUD de tarefas.
- Associação de tarefas às matérias.
- Conclusão e reabertura de tarefas.
- Consulta por matéria e situação.
- Consulta de tarefas atrasadas.

### Sessões de estudo
- Registro de sessões de estudo.
- Associação das sessões às matérias.
- Consulta, atualização e exclusão de sessões.
- Cálculo do total de minutos estudados por matéria.

### Progresso
- Resumo de progresso por matéria.
- Total de sessões realizadas.
- Total de minutos estudados.

## Arquitetura

O projeto está organizado em duas aplicações independentes:

```text
StudyFlow/
├── StudyFlow.Api/
│   ├── Controllers/
│   ├── Data/
│   ├── Dtos/
│   ├── Models/
│   ├── Services/
│   ├── Migrations/
│   └── Program.cs
│
└── studyflow-web/
    └── src/
        └── app/
            ├── components/
            ├── models/
            ├── services/
            └── app.ts
```

O backend é responsável pelas regras de negócio, processamento das requisições e acesso ao banco de dados.

O frontend consome a API REST por meio de requisições HTTP.


## Status do projeto

Projeto desenvolvido como prática de aprendizado de desenvolvimento Full Stack.

O backend possui os módulos de matérias, tarefas, sessões de estudo e resumo de progresso implementados.

No frontend, o módulo de matérias possui integração funcional com a API, incluindo consulta, cadastro, edição e exclusão.

Os demais módulos do frontend não foram implementados nesta versão.

## Objetivo de aprendizado

Praticar desenvolvimento de APIs REST, persistência de dados com Entity Framework Core, organização em camadas, desenvolvimento frontend com Angular e integração entre aplicações utilizando HTTP e JSON.

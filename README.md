# 🔧 Backend - API RESTful em .NET 8

Este é o backend da aplicação de gerenciamento de produtos, desenvolvido em .NET 8 seguindo os princípios de Domain-Driven Design (DDD) e RESTful.

## 🏗️ Tecnologias Utilizadas

- .NET 8 🚀
- FluentValidation ✅
- Injeção de Dependência nativa do .NET 🏗️
- xUnit + Moq para testes 🧪
- HATEOAS para enriquecer as respostas com links 🔗
- Estrutura em camadas com separação DDD 🧱

## 📦 Estrutura do Projeto

```
Backend/
│-- Domain/          # Camada de Domínio (Entidades, Interfaces, Regras de Negócio)
│-- Application/     # Camada de Aplicação (Serviços, DTOs, Validadores, HATEOAS)
│-- Infrastructure/  # Camada de Infraestrutura (Repositórios)
│-- API/             # Camada de Apresentação (Controllers, Program.cs)
│-- Tests/           # Testes Unitários com xUnit e Moq
```

## ✅ Propriedades RESTful implementadas

| Propriedade RESTful          | Status | Observações |
|-----------------------------|--------|-------------|
| Verbos HTTP corretos        | ✅     | GET, POST, PUT, DELETE corretamente usados |
| URIs orientadas a recurso   | ✅     | `/api/produto`, `/api/produto/{id}` |
| Códigos de status HTTP      | ✅     | 200, 201, 204, 400, 404, 500 usados corretamente |
| Stateless                   | ✅     | Sem sessão, sem estado entre requisições |
| Representações em JSON      | ✅     | Retorno padronizado em JSON |
| HATEOAS                     | ✅     | Links "self", "update", "delete" incluídos nas respostas |
| Cacheabilidade              | ✅     | Implementado cuidadosamente em algumas rotas |

## ▶️ Como Rodar o Projeto

1. Instale o .NET 8, caso não tenha:  
   👉 [Baixar .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

2. No terminal, navegue até a pasta do backend e rode o projeto:  
   ```bash
   dotnet run --project DesafioProdutoAPI
   ```

A API estará disponível em:  
📡 `http://localhost:7171/api/produto`

## 🧪 Como Executar os Testes

Na raiz do projeto, execute:  
```bash
dotnet test
```

Isso rodará os testes unitários com xUnit e Moq.

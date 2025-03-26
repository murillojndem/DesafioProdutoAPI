# 🔧 Backend - API RESTful em .NET 8

Este é o backend da aplicação de gerenciamento de produtos, desenvolvido em .NET 8 seguindo os princípios de Domain-Driven Design (DDD).

## 🏗️ Tecnologias Utilizadas

- .NET 8 🚀
- FluentValidation ✅
- Injeção de Dependência nativa do .NET 🏗️

## 📂 Estrutura do Projeto

```
Backend/
│-- Domain/          # Camada de Domínio (Entidades, Interfaces, Regras de Negócio)
│-- Application/     # Camada de Aplicação (Serviços e Casos de Uso)
│-- Infrastructure/  # Camada de Infraestrutura (Repositórios, Banco de Dados)
│-- API/             # Camada de Apresentação (Controllers, Endpoints)
│-- Tests/           # Testes Unitários
```

## ▶️ Como Rodar o Projeto

1. Instale o .NET 8, caso não tenha:  
   [Baixar .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  

2. No terminal, navegue até a pasta do backend e rode o projeto:  
   ```bash
   dotnet run --project API
   ```

A API estará disponível em `http://localhost:7171/api/produtos`. 🚀

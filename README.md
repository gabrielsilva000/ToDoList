# Documentação do Projeto

## **Descrição**
Este projeto é uma aplicação **Angular + .NET** que implementa um sistema de **CRUD** integrado com autenticação baseada em **JWT (JSON Web Token)**. Ele inclui funcionalidades de login, validação de usuários e proteção de rotas.

---

## **Tecnologias Utilizadas**
- **Frontend**: Angular
- **Backend**: .NET Core
- **Banco de Dados**: (Adicionar aqui se for usado um banco específico, ex.: SQL Server, PostgreSQL)
- **Autenticação**: JWT para geração e validação de tokens.

---

## **Funcionalidades**
1. **Login e Autenticação**
   - Envio de credenciais para o backend.
   - Geração e validação de JWT.
   - Armazenamento do token no **localStorage** para acesso autenticado.

2. **CRUD**
   - Operações de criação, leitura, atualização e exclusão de dados.
   - Proteção de rotas para acesso às funcionalidades apenas por usuários autenticados.

---

## **Estrutura do Projeto**
- **Frontend (Angular 19.0.2)**:
  - Componentes para login e CRUD.
  - Serviço para autenticação e requisições HTTP.
  - Caminho ToDoList/To-Do-List

- **Backend (ASP.NET Core 8.01)**:
  - Endpoints RESTful para as operações CRUD.
  - Endpoint de login que retorna o token JWT.
  - Caminho ToDoList/To-Do-List.App

---

## **Autenticação**
O backend utiliza JWT para proteger os endpoints. O token é enviado pelo frontend no cabeçalho `Authorization` em requisições autenticadas.

Exemplo de cabeçalho:


---

## **Requisitos**
- **Node.js** e Angular CLI para o frontend.
- **.NET Core SDK** para o backend.

---

## **Execução**
### **Frontend**
1. Instalar dependências:
   ```bash
   npm install


    configuração de endpoint no front no arquivo environment

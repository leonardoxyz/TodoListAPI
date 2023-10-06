# ToDoList Web API em C#

Bem-vindo ao projeto ToDoList Web API em C#! Esta é uma aplicação simples e poderosa para ajudá-lo a gerenciar suas tarefas diárias de forma eficiente. Esta API permite que você crie, leia, atualize e delete tarefas em sua lista de afazeres.

## Iniciando

Siga estas instruções para configurar e executar o projeto em sua própria máquina.

### Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas:

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/downloads/)

### Instalação

1. Clone este repositório em sua máquina:

2. Abra o projeto em seu Visual Studio.

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`. Por padrão, a configuração aponta para um banco de dados local SQL Server. Certifique-se de que a configuração esteja de acordo com seu ambiente.

4. Abra o Package Manager Console no Visual Studio e execute as migrações para criar o banco de dados:

5. Execute a aplicação.

### Uso

Agora que a aplicação está em execução, você pode começar a usar a API para gerenciar suas tarefas. Aqui estão algumas das principais rotas disponíveis:

- `GET /api/TodoItems`: Retorna todas as tarefas da lista.
- `GET /api/TodoItems{id}`: Retorna uma tarefa específica pelo ID.
- `POST /api/TodoItems`: Cria uma nova tarefa.
- `PUT /api/TodoItems/{id}`: Atualiza uma tarefa existente pelo ID.
- `DELETE /api/TodoItems/{id}`: Exclui uma tarefa pelo ID.

Certifique-se de usar o Postman ou outra ferramenta semelhante para fazer solicitações à API.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter detalhes.
Aproveite o uso da sua nova ToDoList API! 😊📝

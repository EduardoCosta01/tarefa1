using Dapper.Contrib.Extensions;

namespace Tarefas_API.Data;

[Table("Tarefas")]
public record Tarefa(int Id, string Atividade, string Status);




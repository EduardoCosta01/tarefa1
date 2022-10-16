using Dapper.Contrib.Extensions;
using Tarefas_API.Data;
using static Tarefas_API.Data.TarefaContext;

namespace Tarefas_API.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints( this WebApplication app)
        {
            app.MapGet("/", () => $"Bem-Vidos ao API Tarefas - {DateTime.Now}");


            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();

                if (tarefas is null)
                    return Results.NotFound();

                return Results.Ok(tarefas);
            });


            app.MapGet("/tarefas/{Id}", async (GetConnection connectionGetter, int Id) =>
            {
                using var con = await connectionGetter();
                var tarefas = con.Get<Tarefa>(Id);

                if (tarefas is null)
                    return Results.NotFound();

                return Results.Ok(tarefas);
            });


            app.MapPost("/Tarefas", async (GetConnection connectionGetter, Tarefa Tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(Tarefa);
                return Results.Created($"/Tarefas/{id}", Tarefa);
            });


            app.MapPut("/Tarefas", async (GetConnection connectionGetter, Tarefa Tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(Tarefa);
                return Results.Ok();
            });


            app.MapDelete("/tarefas/{Id}", async (GetConnection connectionGetter, int Id) =>
            {
                using var con = await connectionGetter();
                var deleted = con.Get<Tarefa>(Id);

                if (deleted is null)
                    return Results.NotFound();

                con.Delete(deleted);
                return Results.Ok(deleted);
            });
        }

    }
}

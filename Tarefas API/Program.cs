using Tarefas_API.Endpoints;
using Tarefas_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AppPersistence();

var app = builder.Build();

app.MapTarefasEndpoints();

app.Run();

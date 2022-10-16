using System.Data.SqlClient;
using static Tarefas_API.Data.TarefaContext;

namespace Tarefas_API.Extensions
{
    public static class ServiceCollctionsExtensions
    {
        public static WebApplicationBuilder AppPersistence (this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaltConnection");

            builder.Services.AddScoped<GetConnection>(sp =>
            async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });
            return builder;

        }

       
    }
}

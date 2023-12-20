using Npgsql;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.MinimumLevel.Debug();
    
    configuration
        .WriteTo
        .Console();
});

var connectionString = builder.Configuration.GetConnectionString("Postgres");

var app = builder.Build();

if (string.IsNullOrEmpty(connectionString))
{
    app.Logger.LogError("Connection string for Postgres is empty");
    throw new Exception("Connection string for Postgres is empty");
}

app.UseDeveloperExceptionPage();
app.MapGet("/", async () =>
{
    app.Logger.LogInformation("Trying to connect to YDB via Postgres driver");
    await using var dataSource = NpgsqlDataSource.Create(connectionString);
    var connection = await dataSource.OpenConnectionAsync();
    var command = connection.CreateCommand();
    command.CommandText = "SELECT 1;";
    var scalar = command.ExecuteScalar();
    return Results.Json(new { scalar });
});

app.Run();
using EFCoreMigrateMultiDatabase;
using EFCoreMigrateMultiDatabase.MigrationsAssemblies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=vs

var provider = builder.Configuration.GetValue("Provider", "UnKnown");
//builder.Services.AddEntityFrameworkDesignTimeServices();
//Add-Migration InitialCreate -Context MyDbContext -OutputDir Migrations\SqlServer -Args "--provider SqlServer"
//Add-Migration InitialCreate -Context MyDbContext -OutputDir Migrations\MySql -Args "--provider MySql"
//update-database -Args "--provider MySql"
//update-database -Args "--provider SqlServer"
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.ReplaceService<IMigrationsAssembly, EFCoreMultiDatabaseMigrationsAssembly>();
    _ = provider switch
    {
        "MySql" => options.UseMySql("server=127.0.0.1;port=3306;database=DBMultiDataBase;userid=root;password=L6yBtV6qNENrwBy7;", new MySqlServerVersion(new Version()))
            .UseMigrationNamespace(new MySqlMigrationNamespace()),
        "SqlServer" => options.UseSqlServer("Data Source=localhost;Initial Catalog=DBMultiDataBase;Integrated Security=True;")
        .UseMigrationNamespace(new SqlServerMigrationNamespace()),
        _ => throw new Exception($"Unsupported provider: {provider}")
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
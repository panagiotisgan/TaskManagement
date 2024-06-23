using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

var sqlSettings = builder.Configuration.GetSection(nameof(SqlServerSettings));
builder.Services.Configure<SqlServerSettings>(sqlSettings);

// Add services to the container.
builder.Services.AddDbContext<TaskManagementContext>(options =>
{
    var serverName = sqlSettings.GetValue<string>("ServerName");
    var databaseName = sqlSettings.GetValue<string>("DatabaseName");
    string connectionString = string.Format(builder.Configuration.GetConnectionString("SQLServer")!, serverName, databaseName);
    
    Console.WriteLine(connectionString);
    
    options.UseSqlServer(connectionString, b=>b.MigrationsAssembly("TaskManagement.Infrastructure"));
});


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

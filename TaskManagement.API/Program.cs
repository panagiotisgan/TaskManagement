using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManagement.Application.Comments.Commands;
using TaskManagement.Application.Extensions;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Infrastructure.Extensions;
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

	//Console.WriteLine(connectionString);

	options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TaskManagement.Infrastructure"));
});


builder.Services.AddMediatR(options =>
{
	options.RegisterServicesFromAssemblies(typeof(Comment).Assembly);
	options.RegisterServicesFromAssemblies(typeof(CreateCommentCommand).Assembly);
});

builder.Services.RegisterServices();

builder.Services.AddControllers();

builder.Services.RegisterValidators();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sw =>
{
	var securitySchema = new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		Reference = new OpenApiReference
		{
			Type = ReferenceType.SecurityScheme,
			Id = "Bearer"
		}
	};

	sw.AddSecurityDefinition("Bearer", securitySchema);

	var securityRequirement = new OpenApiSecurityRequirement();
	securityRequirement.Add(securitySchema, new[] { "Bearer" });
	sw.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 7;
})
	.AddEntityFrameworkStores<TaskManagementContext>()
	.AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagement.API");
		c.RoutePrefix = "admin/swagger";
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<User>();

app.MapControllers();

app.Run();

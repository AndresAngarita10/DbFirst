using System.Reflection;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.ConfigureCors();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Inyectando el ApiContext
builder.Services.AddDbContext<DbFirstContext>(options =>
{
	string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});
//Fin Inyeccion del ApiContext
//-----------------------------------------------------------------------------

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//-----------------------------------------------------------------------------
//inyeccion de demas dependencias --------------------------------
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var loggerFactory = services.GetRequiredService<ILoggerFactory>();
	try
	{
		var context = services.GetRequiredService<DbFirstContext>();
		await context.Database.MigrateAsync();
	}
	catch (Exception ex)
	{
		var _logger = loggerFactory.CreateLogger<Program>();
		_logger.LogError(ex, "Ocurrio un error durante la migracion");
	}
}
//fin -------------------------------------
//------------------------------

app.UseCors("CorsPolicy"); //configurando politica
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

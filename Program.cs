using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Models;
using WebAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
//Se pueden bloquear las peticiones de origen cruzado
//Se puede configurar para que solo se permitan peticiones de un origen específico
//Se puede configurar para que solo se permitan peticiones de un origen específico y con un método específico
//Se puede configurar para que solo se permitan peticiones de un origen específico y con un método específico y con un encabezado específico
builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            cors =>
            {
                cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
    });
// Configure DbContext with MySQL
builder.Services.AddDbContext<Jq4bContext>(opciones => 
    opciones.UseMySQL(builder.Configuration.GetConnectionString("db")!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureDbContext(IServiceCollection services, string connectionString)
{
    services.AddDbContext<DbfrontendContext>(options =>
        options.UseMySQL(connectionString));
}
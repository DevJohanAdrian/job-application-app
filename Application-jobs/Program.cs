using Microsoft.EntityFrameworkCore; // para conexion y set up de bd
using Application_jobs.Context;
using Application_jobs.Services; // se trae para utilizar el contexto y configurar la conexion.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Añade todo los controladores automaticamente
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir contexto y generar conexion
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"))
);


builder.Services.AddScoped<ApplicationStatusService>(); // Se agregar servicio de application status
builder.Services.AddScoped<CompanyService>();

var app = builder.Build();

// Middlewares como en express con palabra use

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


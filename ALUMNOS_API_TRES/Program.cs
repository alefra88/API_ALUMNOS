using ALUMNOS_API_TRES.Config.Impl;
using ALUMNOS_API_TRES.Config.Interfaces;
using ALUMNOS_API_TRES.Repositories.Impl;
using ALUMNOS_API_TRES.Repositories.Interfaces;
using ALUMNOS_API_TRES.Services.Impl;
using ALUMNOS_API_TRES.Services.Interfaces;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//conexion
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();

//reps
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoService, AlumnoService >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//habilita cors
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

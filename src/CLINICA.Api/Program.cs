using CLINICA.Api.Extensions.Middleware;
using CLINICA.Application.UseCase.Extensions;
using CLINICA.Persistencia.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Cors = "Cors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//AGREGAMOS LA PERSISTENCIA SOLO LAS INYECTION EXTENSIONS
builder.Services.addInyectionPersistence();

//AGREGAMOS LA APPLICACION SOLO LAS INYECTION EXTENSIONS
builder.Services.AddInyectionApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(Cors);

app.UseAuthorization();
app.AddMiddleware();

app.MapControllers();

app.Run();

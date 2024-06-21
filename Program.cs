using Backend.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<IPeopleService, PeopleService>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");

builder.Services.AddScoped<IPostService, PostService>();

//HttpClient servicio jsonplaceholder
builder.Services.AddHttpClient<IPostService, PostService>(c => 
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

//Entity Framework


// Validators
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Configuración de swagger

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

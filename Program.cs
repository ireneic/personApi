using Person_Api.Repositories;
using Person_Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      
    app.UseSwaggerUI();    
}

app.UseAuthorization();

app.MapControllers();
app.MapGet("/hello-world", () => "Hello World!");

app.Run();

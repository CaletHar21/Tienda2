using Microsoft.OpenApi.Models;
using TienditaStore.DB;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.MapPost("/Tienda", (Product product) => ProductDB.CreateProduct(product));
app.MapGet("/Tienda/{id}", (int id) => ProductDB.GetProduct(id));
app.MapPut("/Tienda/{id}", (Product product) => ProductDB.UpdateProduct(product));
app.MapDelete("/Tienda/{id}", (int id) => ProductDB.RemoveProduct(id));


app.Run();
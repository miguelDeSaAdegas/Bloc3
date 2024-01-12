using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// Get price of article in specified country
app.MapGet("/bank/tva/{articlePrice}/{country}", (int articlePrice, string country) =>
{
    double price = 0;
    if (country == "BE")
    {
        price = articlePrice * 1.21;
    }else if (country == "FR")
    {
        price = articlePrice * 1.20;
    }

    String rep = "price: " + articlePrice + ", country : " + country + " -> " + price + ((country == "BE") ? "TVA Belgique 21%" : "TVA France 20%");

    return rep;

});

app.Run();

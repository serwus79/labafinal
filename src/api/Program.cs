var builder = WebApplication.CreateBuilder(args);

// Dodaj usługę CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Pozwól na zapytania z dowolnej domeny
              .AllowAnyMethod() // Pozwól na wszystkie metody HTTP
              .AllowAnyHeader(); // Pozwól na wszystkie nagłówki
    });
});

var app = builder.Build();

// Użyj CORS
app.UseCors();

app.MapGet("/api/message", () => new { Message = "Hello from Minimal API!" });

app.Run();

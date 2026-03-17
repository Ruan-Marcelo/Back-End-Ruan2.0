using Microsoft.EntityFrameworkCore;
using RuanApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Usar PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Aplicar migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "API ONLINE 🚀");

app.Run();
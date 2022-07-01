using Microsoft.EntityFrameworkCore;
using Presistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DatabaseContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

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

app.UseAuthorization();

app.MapControllers();


await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<DatabaseContext>();
await db.Database.MigrateAsync();

app.Run();

using BE_22042024;
using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.IServices;
using EBook.DataAccess.NetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
//builder.Services.AddDbContext<EBookDBContext>(options =>
//               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBookServices, BookServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});
//app.UseMiddleware<MyCustomMiddleWare>();
app.UseMyMiddleware();
app.UseAuthorization();
app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using OUCR202409018.Endpoints;
using OUCR202409018.Models.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CRMContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
);

builder.Services.AddScoped<ProductsOUCRDAL>();

var app = builder.Build();

app.AddProductEndpoints();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 

app.Run();

 
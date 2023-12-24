using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Mybizz.DAL;
using Mybizz.DTOs.Profession;
using Mybizz.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(ProfessionCreateDto).Assembly);
});

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlServer("Server=MSI;Database=MyBizz-API;Trusted_Connection=True;TrustServerCertificate=true");

});

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

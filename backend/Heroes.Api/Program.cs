using Heroes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using Heroes.Application.Common;
using Heroes.Application.Interfaces;
using Heroes.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Heroes.Application.Features.Heroes.Validators;
using Heroes.Application.Behaviors;
using Heroes.Api.Middlewares;
using Heroes.Application.Features.Heroes.Commands.DeleteHero; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HeroesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(DeleteHeroCommand).Assembly);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddScoped<IHeroRepository, HeroRepository>();

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateHeroCommandValidator>();

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

using Assignment_App.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Assignment_App.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Pour dev : écouter sur HTTP
builder.WebHost.UseUrls("http://localhost:5225");

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TasksDb"));

// MediatR (MediatR 13)
builder.Services.AddMediatR(typeof(Assignment_App.Application.Commands.CreateTaskCommand).Assembly);

// Web + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.MapControllers();

app.Run();

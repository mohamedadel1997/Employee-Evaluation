using Microsoft.Extensions.Configuration;
using System;
using DomainLayer.MigrationFolder;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using DomainLayer;
using ServiceLayer.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DataBaseConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IEmployeeServices,EmployeeServices >();
builder.Services.AddScoped<IEvaluationServices, EvaluationServices>();
builder.Services.AddScoped<IEmployeeEvaluationsServices, EmployeeEvaluationsServices>();
builder.Services.AddScoped<IQuestionsServices, QuestionsServices>();
builder.Services.AddScoped<IQuestionsEvaluationServices, QuestionsEvaluationServices>();
builder.Services.AddScoped<IEmployeeEvaluationAnswersServices, EmployeeEvaluationAnswersServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

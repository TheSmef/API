using API.Data.Context;
using API.Data.Repositories;
using API.Data.Repositories.Interfaces;
using API.Extensions.Reference;
using API.Services.Pipelines;
using API.Utility.Errors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Register App Services
builder.Services.Configure<ApiBehaviorOptions>(op =>
{
    op.InvalidModelStateResponseFactory = ErrorResponceHandler.GenerateErrorResponce;
});

builder.Services.AddDbContextPool<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Database"))
);


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();



builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssembly(AssemblyReference.Assembly));

builder.Services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

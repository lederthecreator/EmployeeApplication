using Application.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    opt.DefaultRequestCulture = new RequestCulture("ru-Ru");
});

builder.Services.AddPersistence(configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}\\EmployeeApi.xml");
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1", 
        Description = "Данные о работниках"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeApi");
    });
}

app.UseCors(opt =>
{
    opt.AllowAnyMethod();
    opt.AllowAnyHeader();
    opt.AllowAnyOrigin();
});

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
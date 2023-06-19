using FluentValidation;
using GestionePratiche.Persistence.Data;
using GestionePratiche.Persistence.Model;
using GestionePratiche.Persistence.Repositories;
using GestionePratiche.Services.Mapping;
using GestionePratiche.Services.Services;
using GestionePratiche.Services.Validations;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServiceCollection(builder);
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


static void ServiceCollection(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<GestionePraticheDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

    builder.Services.AddValidatorsFromAssemblyContaining<CreaPraticaRequestValidator>();
    builder.Services.AddAutoMapper(typeof(Profiles));

    builder.Services.AddScoped<IPraticaService, PraticaService>();
    builder.Services.AddScoped<IRepository<Pratica>, PraticaRepository>();
}
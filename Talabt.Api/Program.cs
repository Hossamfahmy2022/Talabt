using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabt.Api.Errors;
using Talabt.Api.Mapping;
using Talabt.Core.Entities;
using Talabt.Core.Reposirties.Contracts;
using Talabt.Repositery;
using Talabt.Repositery.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// add services
//builder.Services.AddScoped<IGenericRepostriy<Product>, GenericRepostriy<Product>>();
//builder.Services.AddScoped<IGenericRepostriy<ProducrtBrand>, GenericRepostriy<ProducrtBrand>>();
//builder.Services.AddScoped<IGenericRepostriy<ProductCatergory>, GenericRepostriy<ProductCatergory>>();
// make it generic 
builder.Services.AddScoped(typeof(IGenericRepostriy<>), typeof(GenericRepostriy<>));

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); // required for Swagger
builder.Services.AddSwaggerGen();
// Connection string
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(ConnectionString)
    );
// Configure AutoMapper
builder.Services.AddAutoMapper(M => M.AddProfile(typeof(MappingProfiles)));
// Change Bad request behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory =
        (actionContext) =>
    {
        var errors = actionContext.ModelState.Where(P => P.Value!.Errors.Count() > 0)
        .SelectMany( P => P.Value!.Errors)
        .Select(E => E.ErrorMessage).ToArray();
        var response = new ApiResponseValidationError()
        {
            Errors = errors
        };
        return new BadRequestObjectResult(response);
    };
}
);


var app = builder.Build();

// need to accees scoped service and get my service
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var dbcontext = services.GetRequiredService<ApplicationDbContext>();
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    await dbcontext.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(dbcontext);
}
catch (Exception ex)
{

    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "error during apply migration");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Enables Swagger UI at /swagger
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();

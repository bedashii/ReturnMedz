using FlowinglySDC.API.Configuration;
using FlowinglySDC.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<SalesTaxConfig>(builder.Configuration.GetSection("SalesTaxConfig"));
builder.Services.AddSingleton<UserMessageValidator>();
builder.Services.AddSingleton<CostCalculator>();
builder.Services.AddSingleton<JsonParser>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();

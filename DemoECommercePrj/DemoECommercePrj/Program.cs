using DemoECommercePrj.Data;
using DemoECommercePrj.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Cors
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddAuthentication();

//Register DbContext
builder.Services.AddDbContext<DemoEcommerceDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DemoECommerce"));
});

//Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
//Register Services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();

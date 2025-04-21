using ProductAPI.Interfaces;
using ProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Urls.Add("http://0.0.0.0:5000");
app.Run();


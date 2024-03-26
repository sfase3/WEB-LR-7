using ProductWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Сервіс створюється під час запуску додатка лише один раз і використовується для всіх запитів, що надходять.
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IShopCartService, ShopCartService>();
builder.Services.AddSingleton<ICatalogService, CatalogService>();

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

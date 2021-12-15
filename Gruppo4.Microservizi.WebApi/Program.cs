using Gruppo4.Microservizi.AppCore.Consumers.Customers;
using Gruppo4.Microservizi.AppCore.Consumers.Products;
using Gruppo4.Microservizi.AppCore.Consumers.Warehouse;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Services;
using Gruppo4.Microservizi.Persistency.Repositories.RepositoriesContrib;
using Gruppo4.Microservizi.Persistency.RepositoriesContrib;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICouponHasOrdersService, CouponHasOrdersService>();
builder.Services.AddScoped<IOrdersHasProductService, OrdersHasProductService>();


builder.Services.AddScoped<IOrderRepository, OrdersRepositoryContrib>();
builder.Services.AddScoped<ICouponRepository, CouponsRepositoryContrib>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryContrib>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryContrib>();
builder.Services.AddScoped<ICouponHasOrdersRepository, CouponHasOrdersRepositoryContrib>();
builder.Services.AddScoped<IOrdersHasProductRepository, OrdersHasProductRepositoryContrib>();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, rabbitConfigurator) =>
    {
        rabbitConfigurator.Host(
            "roedeer-01.rmq.cloudamqp.com",
            "/",
            credentials =>
            {
                credentials.Username("vpeeygzh");
                credentials.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
            });

        rabbitConfigurator.ReceiveEndpoint("test_1", e =>
        {
            e.Consumer<CreateClientEventConsumer>();
        });
        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<DeleteClientEventConsumer>();
        });

        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<UpdateClientEventConsumer>();
        });

        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<DeleteProductEventConsumer>();
        });

        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<NewProductEventConsumer>();
        });

        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<UpdateProductEventConsumer>();
        });

        rabbitConfigurator.ReceiveEndpoint("test_2", e =>
        {
            e.Consumer<NewRefillEventConsumer>();
        });

    });

});
builder.Services.AddMassTransitHostedService();

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

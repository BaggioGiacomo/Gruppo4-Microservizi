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
    x.AddConsumer<CreateClientEventConsumer>();
    x.AddConsumer<DeleteClientEventConsumer>();
    x.AddConsumer<UpdateClientEventConsumer>();
    x.AddConsumer<DeleteProductEventConsumer>();
    x.AddConsumer<NewProductEventConsumer>();
    x.AddConsumer<UpdateProductEventConsumer>();
    x.AddConsumer<NewRefillEventConsumer>();



    x.UsingRabbitMq((context, rabbitConfigurator) =>
    {

        

        rabbitConfigurator.Host(
            "roedeer-01.rmq.cloudamqp.com",
            "vpeeygzh",
            credentials =>
            {
                credentials.Username("vpeeygzh");
                credentials.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
            });

        rabbitConfigurator.ReceiveEndpoint("orders_create_client", e =>
        {
            e.Consumer<CreateClientEventConsumer>(context);
        });
        rabbitConfigurator.ReceiveEndpoint("orders_delete_client", e =>
        {
            e.Consumer<DeleteClientEventConsumer>(context);
        });

        rabbitConfigurator.ReceiveEndpoint("orders_update_client", e =>
        {
            e.Consumer<UpdateClientEventConsumer>(context);
        });

        rabbitConfigurator.ReceiveEndpoint("orders_delete_product", e =>
        {
            e.Consumer<DeleteProductEventConsumer>(context);
        });

        rabbitConfigurator.ReceiveEndpoint("orders_new_product", e =>
        {
            e.Consumer<NewProductEventConsumer>(context);
        });

        rabbitConfigurator.ReceiveEndpoint("orders_update_product", e =>
        {
            e.Consumer<UpdateProductEventConsumer>(context);
        });

        rabbitConfigurator.ReceiveEndpoint("orders_newrefill_product", e =>
        {
            e.Consumer<NewRefillEventConsumer>(context);
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

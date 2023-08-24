using StrategyPattern.Services.PaymentMethods;
using StrategyPattern.Services;
using StrategyPattern.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MyCode
//for Enumerable
builder.Services.AddScoped<IPaymentStrategy, PartialPaymentStrategy>();
builder.Services.AddScoped<IPaymentStrategy, ConcretePaymentStrategy>();
//for Dictionary and Delegate
builder.Services.AddScoped<PartialPaymentStrategy>();
builder.Services.AddScoped<ConcretePaymentStrategy>();


//with Enumerable
builder.Services.AddScoped<PaymentStrategyEnumerable>();
//with Dictionary
builder.Services.AddScoped<PaymentStrategyDictionary>(provider =>
{
    var dictionary = new PaymentStrategyDictionary
    {
        { Payment.Partial, provider.GetService<PartialPaymentStrategy>() },
        { Payment.Concrete, provider.GetService<ConcretePaymentStrategy>() }
    };
    return dictionary;
});
//with Delegate
builder.Services.AddScoped<PaymentStrategyDelegate>(serviceProvider => key => key switch
    {
        Payment.Concrete => serviceProvider.GetRequiredService<PartialPaymentStrategy>(),
        Payment.Partial => serviceProvider.GetRequiredService<ConcretePaymentStrategy>(),
        _ => throw new KeyNotFoundException(),
    });

#endregion




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

using Refit;
using WebApiConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRefitClient<IDummyJsonServiceRefit>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://dummyjson.com/"));

builder.Services.AddHttpClient<IDummyJsonService, DummyJsonService>(client =>
{
    client.BaseAddress = new Uri("https://dummyjson.com/");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

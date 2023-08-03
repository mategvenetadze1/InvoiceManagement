using InvoiceManagement.API.Middlewares;
using InvoiceManagement.Application;
using InvoiceManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add project services.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", options =>
        options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

var app = builder.Build();

// Custom middlewares
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Built in middlewares 
app.UseCors("all");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

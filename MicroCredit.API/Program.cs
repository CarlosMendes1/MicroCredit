using MicroCredit.Application.Services;
using MicroCredit.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//// Application Services
//builder.Services.AddTransient<IMicroCreditService, MicroCreditService>();
//builder.Services.AddTransient<IUserService, UserService>();

//// Infrastructure Services
//builder.Services.AddTransient<ICreditService, CreditService>();
//builder.Services.AddTransient<IDigitalKeyService, DigitalKeyServiceMock>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

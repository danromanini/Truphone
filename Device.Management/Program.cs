using Device.Management.Api.Configurations;
using Device.Management.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);

builder.Services.AddDbContext<DeviceContext>(x => x.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddSwaggerConfiguration();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerSetup();


app.Run();





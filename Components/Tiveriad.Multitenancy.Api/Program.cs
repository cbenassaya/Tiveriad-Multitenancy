using Tiveriad.Multitenancy.Infrastructure;
using Tiveriad.Multitenancy.Application;
using Tiveriad.Multitenancy.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMapper();
builder.Services.AddController();
builder.Services.AddSwagger();
builder.Services.AddCorsMethod();
builder.Services.AddUserResolverService();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.DatabaseEnsureCreated();
var app = builder.Build();
app.UseDevelopmentEnvironment();
app.UseLoggerFile();
app.UseRouting();
app.UseCorsAllowAny();
app.UseEndpoints();
app.Run();
public partial class Program
{
}
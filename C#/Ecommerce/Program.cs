
using Ecommerce.Service.Persistence;
using Ecommerce.Service.Producer;
using Ecommerce.ConfigDatabase;
using poc.api.sqlserver.Service.MessageBus;
using MongoDB.Driver;
using poc.api.sqlserver.EndPoints;
using Ecommerce.Controller.Users;
using Ecommerce.Service.Persistence.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<PeriodicTaskService>();




builder.Services.AddSingleton<MongoDBContext>(sp =>
{
  var mongoConnectionString = builder.Configuration["MongoDB:ConnectionString"];
  var mongoDatabaseName = builder.Configuration["MongoDB:DatabaseName"];
  var mongoClient = new MongoClient(mongoConnectionString);
  var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
  return new MongoDBContext(mongoDatabase);
});


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IMessageBusService, MessageBusService>();
builder.Services.AddScoped<ICreateProducer, CreateProducer>();
builder.Services.AddScoped<IChangeProduct, ChangeProduct>();
builder.Services.AddScoped<IRemoveProduct, RemoveProduct>();





var app = builder.Build();


var periodicTaskService = app.Services.GetRequiredService<PeriodicTaskService>();
var timer = new System.Timers.Timer(3000);
timer.Elapsed += (sender, e) => periodicTaskService.ExecuteTask();
timer.AutoReset = true;
timer.Enabled = true;

app.UseHttpsRedirection();
app.RegisterProdutosEndpoints();
app.RegisterUsersEndpoints();
app.UseAuthorization();
app.Run();
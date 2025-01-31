
using Ecommerce.Service.Persistence;
using Ecommerce.ConfigDatabase;
using poc.api.sqlserver.Service.MessageBus;
using MongoDB.Driver;
using poc.api.sqlserver.EndPoints;
using Ecommerce.Controller.Users;
using Ecommerce.Service.Persistence.Users;
using Ecommerce.Controller;
using Ecommerce.Service.Persistence.PurchasingProcessPessister;
using Ecommerce.Service.MessagePurchansing;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Logging.AddConsole();

builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();





builder.Services.AddSingleton<MongoDBContext>(sp =>
{
  var mongoConnectionString = builder.Configuration["MongoDB:ConnectionString"];
  var mongoDatabaseName = builder.Configuration["MongoDB:DatabaseName"];
  var mongoClient = new MongoClient(mongoConnectionString);
  var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
  return new MongoDBContext(mongoDatabase);
});

builder.Services.AddScoped<IBuyProduct, BuyProductService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchasingProcess, PurchasingProcessService>();
builder.Services.AddSingleton<PeriodicTaskService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IMessageBusService, MessageBusService>();
builder.Services.AddScoped<ICreatePurchansingProcess, CreatePurchansingProcess>();




var app = builder.Build();


var periodicTaskService = app.Services.GetRequiredService<PeriodicTaskService>();
var timer = new System.Timers.Timer(5000);
timer.Elapsed += async (sender, e) => await periodicTaskService.ExecuteTask();
timer.AutoReset = true;
timer.Enabled = true;

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.RegisterProdutosEndpoints();
app.RegisterUsersEndpoints();
app.RegisterBuyProductEndpoints();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
using Ecommerce.src.Infrastructure.auth;
using Ecommerce.src.Infrastructure.ConfigDatabase;
using Ecommerce.src.Infrastructure.MessageBus;
using Ecommerce.src.Infrastructure.MessageBus.MessagePurchansing;
using Ecommerce.src.Infrastructure.Persistence.BuyProductPersister;
using Ecommerce.src.Infrastructure.Persistence.ProductPersistence;
using Ecommerce.src.Infrastructure.Persistence.PurchasingProcessPessister;
using Ecommerce.src.Infrastructure.Persistence.Users;
using Ecommerce.src.Presentation.Controller;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAnyOrigin", builder =>
  {
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
  });
});

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
builder.Services.AddSingleton<InsertObjectsDB>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IMessageBusService, MessageBusService>();
builder.Services.AddScoped<ICreatePurchansingProcess, CreatePurchansingProcess>();
builder.Services.AddScoped<IAuthentification, Authentification>();




var app = builder.Build();


var periodicTaskService = app.Services.GetRequiredService<PeriodicTaskService>();
var insertObjectsDB = app.Services.GetRequiredService<InsertObjectsDB>();
var timer = new System.Timers.Timer(5000);
timer.Elapsed += async (sender, e) => await periodicTaskService.ExecuteTask();
await insertObjectsDB.ExecuteTask();
timer.AutoReset = true;
timer.Enabled = true;
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.RegisterProdutosEndpoints();
app.RegisterUsersEndpoints();
app.RegisterBuyProductEndpoints();
app.RegisterAuthentificationEndpoints();
app.RegisterPurchasingEndPoint();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
using System.Text.Json;
using Ecommerce.Service.MessagePurchansing;
using Ecommerce.Service.Model;
using Ecommerce.Service.Persistence;
using Ecommerce.Service.Persistence.PurchasingProcessPessister;

public class PeriodicTaskService
{
  private readonly ILogger<PeriodicTaskService> _logger;
  private readonly IServiceProvider _serviceProvider;

  public PeriodicTaskService(ILogger<PeriodicTaskService> logger, IServiceProvider serviceProvider)
  {
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  public async Task ExecuteTask()
  {


    // Criar um escopo para resolver as dependências
    using (var scope = _serviceProvider.CreateScope())
    {
      _logger.LogInformation("Executando tarefa periódica. 1");
      var purchasingProcessService = scope.ServiceProvider.GetRequiredService<IPurchasingProcess>();
      var createPurchansingProcess = scope.ServiceProvider.GetRequiredService<ICreatePurchansingProcess>();
      var purchaseOrchestrator = scope.ServiceProvider.GetRequiredService<IPurchasingProcess>();
      var IBuyProductT = scope.ServiceProvider.GetRequiredService<IBuyProduct>();

      var allPurchasingProcesses = await purchasingProcessService.GetAll();
      var AllpurchaseOrchestrator = await purchaseOrchestrator.GetAll();
      var pendingProcesses = allPurchasingProcesses.Where(p => p.StatusProcess == "waitingInLine").ToList();
      foreach (var process in pendingProcesses)
      {
        {
          await createPurchansingProcess.Publish(process);
          process.StatusProcess = "Processing";
          await purchasingProcessService.Update(process);
          _logger.LogInformation($"Publicado processo de compra: {process.Id}");
        }
      }
      foreach (var process in AllpurchaseOrchestrator)
      {
        if (process.StatusProcess == "Success" || process.StatusProcess == "Canceled")
        {
          var productPay = await IBuyProductT.GetById(process.IdBuyProduct);
          productPay.PaymentCompleted = true;
          await IBuyProductT.Update(productPay);

        }
      }

      _logger.LogInformation(JsonSerializer.Serialize(pendingProcesses));
    }
  }
}
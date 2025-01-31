using System.Text.Json;
using Ecommerce.Service.MessagePurchansing;
using Ecommerce.Service.Model;
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

      var allPurchasingProcesses = await purchasingProcessService.GetAll();
      var pendingProcesses = allPurchasingProcesses.Where(p => p.StatusProcess == "Pending").ToList();
      foreach (var process in pendingProcesses)
      {
        if (process.StatusProcess == "Pending")
        {
          await createPurchansingProcess.Publish(process);
          await purchasingProcessService.Update(process);
          _logger.LogInformation($"Publicado processo de compra: {process.Id}");
        }
      }

      _logger.LogInformation(JsonSerializer.Serialize(pendingProcesses));
    }
  }
}
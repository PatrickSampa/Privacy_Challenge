public class PeriodicTaskService
{
  private readonly ILogger<PeriodicTaskService> _logger;
  private readonly IServiceProvider _serviceProvider;

  public PeriodicTaskService(ILogger<PeriodicTaskService> logger, IServiceProvider serviceProvider)
  {
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  public void ExecuteTask()
  {
    _logger.LogInformation("Executando tarefa periódica.");
    
  }
}
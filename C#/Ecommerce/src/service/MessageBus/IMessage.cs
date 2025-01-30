public interface IMessageBusService
{
  Task Publish(string queue, byte[] message);
}
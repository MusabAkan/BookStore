namespace WebApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("[dd-mm-yyyy HH:dd:ss]")} [ConsoleLogger] - " + message);
        }
    }
}

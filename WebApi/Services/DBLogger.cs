namespace WebApi.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message) => Console.WriteLine($"{DateTime.Now.ToString("[dd-mm-yyyy HH:dd:ss]")} [DbLogger] {message}");
    }
}

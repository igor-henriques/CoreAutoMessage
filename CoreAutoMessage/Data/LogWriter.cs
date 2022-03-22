namespace CoreAutoMessage.Data;

public class LogWriter
{
    private readonly ILogger<LogWriter> _logger;
    public LogWriter(ILogger<LogWriter> logger)
    {
        this._logger = logger;
    }

    public void Write(string logMessage)
    {
        try
        {
            using (StreamWriter str = File.AppendText("./log.txt"))
            {
                str.Write("\r\nLog Entry : ");
                str.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                str.WriteLine("  :");
                str.WriteLine("  :{0}", logMessage);
                str.WriteLine("-------------------------------");

                _logger.LogInformation($"{DateTime.Now.ToShortTimeString()}: {logMessage}");
            }
        }
        catch (Exception) { }
    }

    public static void StaticWrite(string logMessage)
    {
        try
        {
            using (StreamWriter w = new StreamWriter(File.OpenWrite("./log.txt")))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");

                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {logMessage}");
            }
        }
        catch (Exception) { }
    }
}
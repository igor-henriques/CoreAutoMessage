namespace CoreAutoMessage.Workers;

public class AutoMessageWorker : BackgroundService
{
    int randomMessageTimeControl = 0;
    private GProvider gprovider;
    private readonly ILogger<AutoMessageWorker> logger;
    private AutoMessageDefinitions autoMessage;
    Random random = new Random();

    /// <summary>
    /// Inicia um Timer que roda o comando de envio de mensagem ao servidor.
    /// </summary>
    /// <param name="_autoMessage">Configurações de auto-mensagem, que consiste no intervalo de envio, mensagens e em qual canal serão enviadas.</param>
    /// <param name="_gprovider">Configurações de conexão ao servidor.</param>        
    public AutoMessageWorker(ILogger<AutoMessageWorker> logger, AutoMessageDefinitions _autoMessage, GProvider _gprovider)
    {
        PWGlobal.UsedPwVersion = (PwVersion)_gprovider.PwVersion;
        this.logger = logger;
        autoMessage = _autoMessage;
        gprovider = _gprovider;
    }

    protected override async Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            SendRandomMessage();

            SendScheduledMessages();

            await Task.Delay(1000);

            this.randomMessageTimeControl += 1000;
        }
    }

    private void SendRandomMessage()
    {
        if (randomMessageTimeControl == (autoMessage.Interval * 60_000))
        {
            string sortedMessage = autoMessage.Messages.ElementAt(random.Next(autoMessage.Messages.Count));

            ChatBroadcast.Send(gprovider, autoMessage.BroadcastChannel, autoMessage.MessageColor + sortedMessage);

            logger.LogInformation(sortedMessage);

            this.randomMessageTimeControl = 0;
        }
    }

    private void SendScheduledMessages()
    {
        foreach (var message in autoMessage.ScheduledMessages)
        {
            if (message?.Minute != DateTime.Now.Minute)
                continue;

            if (message?.Hour != DateTime.Now.Hour)
                continue;            

            if (message?.DayOfWeek != DateTime.Now.DayOfWeek)
                continue;

            logger.LogInformation(message.Message);

            ChatBroadcast.Send(gprovider, autoMessage.BroadcastChannel, autoMessage.MessageColor + message.Message);
        }
    }
}
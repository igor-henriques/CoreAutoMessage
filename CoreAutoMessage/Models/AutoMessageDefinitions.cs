namespace CoreAutoMessage.Models;

public record AutoMessageDefinitions
{
    public int Interval { get; private init; }
    public BroadcastChannel BroadcastChannel { get; private init; }
    public List<string> Messages { get; private init; }
    public List<ScheduledMessage> ScheduledMessages { get; private init; }
    public string MessageColor { get; private init; }

    public AutoMessageDefinitions()
    {
        JObject jsonNodes = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configurations/Definitions.json"));

        Messages = jsonNodes["MENSAGENS ALEATÓRIAS"].ToObject<List<string>>();  
        ScheduledMessages = jsonNodes["MENSAGENS PROGRAMADAS"].ToObject<List<ScheduledMessage>>();
        Interval = jsonNodes["INTERVALO ENTRE MENSAGENS ALEATÓRIAS (EM MINUTOS)"].ToObject<int>();
        BroadcastChannel = (BroadcastChannel)jsonNodes["CANAL DE ENVIO"].ToObject<int>();
        MessageColor = jsonNodes["COR DA MENSAGEM"].ToObject<string>();
    }
}
namespace CoreAutoMessage.Models;

public record ScheduledMessage
{
    [JsonProperty("Mensagem")]
    public string Message { get; set; }

    [JsonProperty("Hora de Envio")]
    public int? Hour { get; set; }

    [JsonProperty("Minuto de Envio")]
    public int? Minute { get; set; }

    [JsonProperty("Segundo de Envio")]
    public int? Second { get; set; }

    [JsonProperty("Dia da Semana de Envio")]
    public DayOfWeek? DayOfWeek { get; set; }
}
namespace CoreAutoMessage.Models;

public record GProvider : IPwDaemonConfig
{
    public string Host { get; private init; }
    public int Port { get; private init; }
    public int PwVersion { get; private init; }

    public GProvider()
    {
        var gproviderConfs = File.ReadAllLines("./Configurations/GProvider.conf");

        this.Host = gproviderConfs[1];
        this.Port = int.Parse(gproviderConfs[3]);
        this.PwVersion = int.Parse(gproviderConfs[5]);
    }
}
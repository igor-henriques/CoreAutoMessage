namespace CoreAutoMessage.License;

public class CoreLicense
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Licensekey { get; set; }
    public DateTime Validade { get; set; }
    public bool Active { get; set; }
    public string Hwid { get; set; }
    public Product Product { get; set; }

    public CoreLicense()
    {
        JObject jsonNodes = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configurations/License.json"));

        this.Product = jsonNodes["product"].ToObject<Product>();
        this.Licensekey = jsonNodes["licensekey"].ToObject<string>();
        this.User = jsonNodes["user"].ToObject<string>();
    }
}
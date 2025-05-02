namespace VF.Infrastructure.Configurations;

public class CredentialsEmailConfiguration
{
#nullable disable
    public string FromEmail { get; set; }
    public string AppPassword { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
}

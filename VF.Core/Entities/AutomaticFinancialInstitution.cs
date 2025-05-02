namespace VF.Core.Entities;

public class AutomaticFinancialInstitution : FinancialInstitution
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string ApiEndpoint { get; set; }
    public string AccessToken { get; set; }
    public DateTime TokenExpiration { get; set; }
}

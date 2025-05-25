namespace VF.Core.Entities;

public class TransferTransaction : Transaction
{
    public Guid OriginAccountId { get; set; }
    public Account OriginAccount { get; set; }

    public Guid DestinyAccountId { get; set; }
    public Account DestinyAccount { get; set; }
    
    public bool Transferred { get; set; }
}

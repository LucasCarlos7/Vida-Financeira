namespace VF.Core.Entities;

public class TransferTransaction : Transaction
{
    public Account OriginAccount { get; set; }
    public Account DestinyAccount { get; set; }
    public bool Transferred { get; set; }
}

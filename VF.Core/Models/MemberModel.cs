using VF.Core.Enums;

namespace VF.Core.Models;

public class MemberModel
{
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public RelationshipEnum Relationship { get; set; }
}

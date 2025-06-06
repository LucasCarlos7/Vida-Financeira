using VF.Core.Enums;

namespace VF.Core.Entities;

public class Member
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public RelationshipEnum Relationship { get; set; }
}

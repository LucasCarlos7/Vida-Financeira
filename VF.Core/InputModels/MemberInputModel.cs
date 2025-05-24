using VF.Core.Enums;

namespace VF.Core.InputModels;

public class MemberInputModel
{
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public RelationshipEnum Relationship { get; set; }
}

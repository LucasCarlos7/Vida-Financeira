using VF.Core.Enums;

namespace VF.Core.ViewModels;

public class MembersViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public RelationshipEnum Relationship { get; set; }
}

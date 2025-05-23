using System.ComponentModel;

namespace VF.Core.Enums;

public enum RelationshipEnum
{
    [Description("Conhecido")]
    FAMILIAR,

    [Description("Filho(a)")]
    CHILD,

    [Description("Cônjuge")]
    SPOUSE,

    [Description("Amigo")]
    FRIEND,

    [Description("Outros")]
    OTHERS
}

namespace VF.Core.Entities
{
    public class FinancialInstitution
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
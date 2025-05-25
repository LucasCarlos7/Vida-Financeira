using VF.Core.Enums;

namespace VF.Core.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public decimal TransactionValue { get; set; }

        public string Description { get; set; } = string.Empty;

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid? SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }

        public DateTime Date { get; set; }

        public Guid? MemberId { get; set; }
        public Member? Member { get; set; }

        public List<Tag>? Tags { get; set; } = new List<Tag>();
    }
}
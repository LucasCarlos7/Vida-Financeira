using System.Text.Json.Serialization;

namespace VF.Core.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Cpf { get; set; }
    public required string Phone { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}

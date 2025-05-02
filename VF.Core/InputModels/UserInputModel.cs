namespace VF.Core.InputModels;

public class UserInputModel
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Cpf { get; set; }
    public required string Phone { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

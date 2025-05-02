namespace VF.Application.Utilities;

public static class CodeGeneratorUtility
{
    public static string GenerateCode()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}

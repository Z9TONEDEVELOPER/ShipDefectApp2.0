namespace MauiApp1.Models;

public class CommissionMember
{
    public string Position { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public string? SignatureImagePath { get; set; }
    public string? StampImagePath { get; set; }

    public bool IsPickingSignature { get; set; }
}
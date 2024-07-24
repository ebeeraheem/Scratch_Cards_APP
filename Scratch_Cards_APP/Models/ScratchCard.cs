namespace Scratch_Cards_APP.Models;

public class ScratchCard
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public bool IsPurchased { get; set; }
    public bool IsUsed { get; set; }
}

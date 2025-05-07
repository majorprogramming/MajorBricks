namespace MajorBricks.Core.Models;

public class Manufacturer
{
    public Int32 Id { get; set; }               // Primary key
    public required String Name { get; set; }            // e.g. "Lego", "Mega", "Mould King"
    
    // Navigation property: One Manufacturer kann viele Sets haben
    public ICollection<Set> Sets { get; set; } = new List<Set>();

    public static implicit operator Manufacturer(string v)
    {
        throw new NotImplementedException();
    }
}

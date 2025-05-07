namespace MajorBricks.Core.Models;

public class Set
{
    public Int32 Id { get; set; }               // Primary key
    public required String Name { get; set; }            // e.g. "Millennium Falcon"
    public required String ArticleNumber { get; set; }   // Herstellernummer
    public Int32 Year { get; set; }             // Erscheinungsjahr
    public Int32 PartCount { get; set; }        // Teileanzahl

    // Foreign key / Navigation
    public Int32 ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
}

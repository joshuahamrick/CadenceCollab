using System.ComponentModel.DataAnnotations;

public class Type
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation properties
    public List<Artist> Artists { get; set; } = new List<Artist>();
    public List<Song> Songs { get; set; } = new List<Song>();
}
using System.ComponentModel.DataAnnotations;

public class ArtistForSongListDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}

using System.ComponentModel.DataAnnotations;

public class ArtistSong
{
    public int Id { get; set; }

    [Required]
    public int ArtistId { get; set; }

    [Required]
    public int SongId { get; set; }

    // Navigation properties
    public Artist? Artist { get; set; }
    public Song? Song { get; set; }
}
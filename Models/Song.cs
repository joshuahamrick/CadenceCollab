
using System.ComponentModel.DataAnnotations;

public class Song
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int GenreId { get; set; }

    [Required]
    public int TypeId { get; set; }

    public string? Lyrics { get; set; }

    [Required]
    public string Description { get; set; }

    public string? PictureUrl { get; set; }

    // Navigation properties
    public Genre? Genre { get; set; }
    public Type? Type { get; set; }
    public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
}
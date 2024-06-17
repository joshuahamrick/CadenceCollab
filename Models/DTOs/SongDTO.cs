
using CadenceCollab.Models.DTOs;
using System.ComponentModel.DataAnnotations;

public class SongDTO
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
    public GenreDTO? Genre { get; set; }
    public TypeDTO? Type { get; set; }
    public List<ArtistSongsForSongsDTO> ArtistSongs { get; set; } = new List<ArtistSongsForSongsDTO>();
}
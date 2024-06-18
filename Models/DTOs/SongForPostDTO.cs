
using CadenceCollab.Models.DTOs;
using System.ComponentModel.DataAnnotations;

public class SongForPostDTO
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
    public List<ArtistSongsForSongsDTO> ArtistSongs { get; set; } = new List<ArtistSongsForSongsDTO>();


}
namespace CadenceCollab.Models.DTOs;

using System.ComponentModel.DataAnnotations;

public class ArtistSongsForSongsDTO
{
    public int Id { get; set; }

    [Required]
    public int UserProfileId { get; set; }

    [Required]
    public int SongId { get; set; }

    // Navigation properties
    public UserProfileForSongListDTO? UserProfile { get; set; }
}
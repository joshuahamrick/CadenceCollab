using CadenceCollab.Models;
using System.ComponentModel.DataAnnotations;

public class ArtistSong
{
    public int Id { get; set; }

    [Required]
    public int UserProfileId { get; set; }

    [Required]
    public int SongId { get; set; }

    // Navigation properties
    public UserProfile? UserProfile { get; set; }
    public Song? Song { get; set; }
}
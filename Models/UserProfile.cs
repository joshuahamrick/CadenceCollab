
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CadenceCollab.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public string ArtistName { get; set; }
    public string Address { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

    [Required]
    public int TypeId { get; set; }

    [Required]
    public string Location { get; set; }

    public string? ProfilePictureUrl { get; set; }

    [Required]
    public int GenreId { get; set; }

    // Navigation properties
    public Genre? Genre { get; set; }
    public Type? Type { get; set; }
    public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();

}

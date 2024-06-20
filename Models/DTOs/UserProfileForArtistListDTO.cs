
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CadenceCollab.Models;

public class UserProfileForArtistListDTO
{
    public int Id { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
    public string UserName { get; set; }

    [Required]
    public int TypeId { get; set; }

    [Required]
    public string Location { get; set; }

    public string? ProfilePictureUrl { get; set; }

    [Required]
    public int GenreId { get; set; }
    public string GenreName { get; set; }
    public string TypeName { get; set; }

    // Navigation properties
    public Genre? Genre { get; set; }
    public Type? Type { get; set; }

}

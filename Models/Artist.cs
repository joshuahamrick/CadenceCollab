// using System.ComponentModel.DataAnnotations;
// using CadenceCollab.Models;

// public class Artist
// {
//     public int Id { get; set; }

//     [Required]
//     public string Name { get; set; }

//     [Required]
//     public int TypeId { get; set; }

//     [Required]
//     public string Location { get; set; }

//     public string? ProfilePic { get; set; }

//     [Required]
//     public int GenreId { get; set; }

//     // Navigation properties
//     public Genre? Genre { get; set; }
//     public Type? Type { get; set; }
//     public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
//     public int UserProfileId { get; set; }
//     public UserProfile ArtistProfile { get; set; }
// }
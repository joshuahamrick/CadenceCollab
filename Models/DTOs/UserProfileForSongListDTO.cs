using System.ComponentModel.DataAnnotations;

public class UserProfileForSongListDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}
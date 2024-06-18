namespace CadenceCollab.Models.DTOs;

public class RegistrationDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int TypeId { get; set; }
    public string Location { get; set; }
    public string ProfilePictureUrl { get; set; }
    public int GenreId { get; set; }
}
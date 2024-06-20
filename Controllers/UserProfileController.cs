using CadenceCollab.Data;
using CadenceCollab.Models;
using CadenceCollab.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/api/[controller]")]

public class UserProfileController : ControllerBase  
{
    private CadenceCollabDbContext _dbContext;

    public UserProfileController(CadenceCollabDbContext context) 
    {
        _dbContext = context;
    }
    
    [HttpGet]
    // [Authorize]
    public IActionResult GetUserProfiles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.Genre)
        .Include(up => up.Type)
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileForArtistListDTO 
        {
            Id = up.Id, 
            // Genre = , 
            GenreName = up.Genre.Name, 
            UserName = up.IdentityUser.UserName, 
            IdentityUserId = up.IdentityUserId, 
            Location = up.Location, 
            // ProfilePictureUrl = up.ProfilePictureUrl, 
            TypeName = up.Type.Name, 
            TypeId = up.TypeId
        }));
    }
    
    [HttpGet("{userProfileId}")]
    // [Authorize]
    public IActionResult GetUserProfiles(int userProfileId)
    {

        return Ok(_dbContext.UserProfiles
        .Include(up => up.Genre)
        .Include(up => up.Type)
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileForArtistListDTO 
        {
            Id = up.Id, 
            // Genre = , 
            GenreName = up.Genre.Name, 
            UserName = up.IdentityUser.UserName, 
            IdentityUserId = up.IdentityUserId, 
            Location = up.Location, 
            // ProfilePictureUrl = up.ProfilePictureUrl, 
            TypeName = up.Type.Name, 
            TypeId = up.TypeId
        }).Single(up => up.Id == userProfileId));
    }

}
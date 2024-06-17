using CadenceCollab.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]

public class GenreController : ControllerBase  
{
    private CadenceCollabDbContext _dbContext;

    public GenreController(CadenceCollabDbContext context) 
    {
        _dbContext = context;
    }
    
    [HttpGet]
    // [Authorize]
    public IActionResult GetAllGenres()
    {
        return Ok(_dbContext.Genres
        .Select(g => new GenreDTO 
        {
            Id = g.Id, 
            Name = g.Name
        })
        );
    }
} 
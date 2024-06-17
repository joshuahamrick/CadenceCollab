using CadenceCollab.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]

public class TypeController : ControllerBase  
{
    private CadenceCollabDbContext _dbContext;

    public TypeController(CadenceCollabDbContext context) 
    {
        _dbContext = context;
    }
    
    [HttpGet]
    // [Authorize]
    public IActionResult GetAllTypes()
    {
        return Ok(_dbContext.Types
        .Select(t => new TypeDTO 
        {
            Id = t.Id, 
            Name = t.Name
        })
        );
    }
} 
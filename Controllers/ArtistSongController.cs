using CadenceCollab.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]

public class ArtistSongController : ControllerBase  
{
    private CadenceCollabDbContext _dbContext;

    public ArtistSongController(CadenceCollabDbContext context) 
    {
        _dbContext = context;
    }
    
    [HttpPost]
    // [Authorize]
    public IActionResult PostArtistSong(ArtistSong artistSong)
    {
        Song foundSong = _dbContext.Songs.SingleOrDefault(s => s.Id == artistSong.SongId);
        if (foundSong == null ) {
            return NotFound();
        }
        ArtistSong newArtistSong = new ArtistSong()
        {
            SongId = artistSong.SongId, 
            UserProfileId = artistSong.UserProfileId
        };
        _dbContext.ArtistSongs.Add(newArtistSong);
        _dbContext.SaveChanges();
        return Created($"songs/{newArtistSong.Id}", newArtistSong);
    }

}
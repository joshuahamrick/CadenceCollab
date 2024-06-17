using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadenceCollab.Data;
using CadenceCollab.Models;
using CadenceCollab.Models.DTOs;
namespace CadenceCollab.Controllers;
[ApiController]
[Route("/api/[controller]")]

public class SongController : ControllerBase  
{
    private CadenceCollabDbContext _dbContext;

    public SongController(CadenceCollabDbContext context) 
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllSongs()
    {
        return Ok(_dbContext.Songs
        .Include(s => s.Genre)
        .Include(s => s.Type)
        .Include(s => s.ArtistSongs)
            .ThenInclude(artistsong => artistsong.Artist)
        .Select(s => new SongDTO 
        {
            Id = s.Id, 
            ArtistSongs = s.ArtistSongs.Select(artistsong => new ArtistSongsForSongsDTO
            {
                Id = artistsong.Id, 
                Artist = new ArtistForSongListDTO
                {
                    Id = artistsong.Artist.Id, 
                    Name  =  artistsong.Artist.Name
                }, 
                ArtistId = artistsong.ArtistId, 
                SongId = artistsong.SongId 
            }).ToList(),
            Description = s.Description, 
            Genre = new GenreDTO
            {
                Id = s.Genre.Id, 
                Name = s.Genre.Name
            }, 
            GenreId = s.GenreId, 
            Lyrics = s.Lyrics, 
            PictureUrl = s.PictureUrl, 
            Title = s.Title, 
            Type = new TypeDTO
            {
                Id = s.Type.Id,  
                Name = s.Type.Name
            }, 
            TypeId = s.TypeId
        }));
    }

    [HttpGet("{songId}")]
    // [Authorize]
    public IActionResult GetSongById(int songId)
    {
        return Ok(_dbContext.Songs
        .Include(s => s.Genre)
        .Include(s => s.Type)
        .Include(s => s.ArtistSongs)
            .ThenInclude(artistsong => artistsong.Artist)
        .Select(s => new SongDTO 
        {
            Id = s.Id, 
            ArtistSongs = s.ArtistSongs.Select(artistsong => new ArtistSongsForSongsDTO
            {
                Id = artistsong.Id, 
                Artist = new ArtistForSongListDTO
                {
                    Id = artistsong.Artist.Id, 
                    Name  =  artistsong.Artist.Name
                }, 
                ArtistId = artistsong.ArtistId, 
                SongId = artistsong.SongId 
            }).ToList(),
            Description = s.Description, 
            Genre = new GenreDTO
            {
                Id = s.Genre.Id, 
                Name = s.Genre.Name
            }, 
            GenreId = s.GenreId, 
            Lyrics = s.Lyrics, 
            PictureUrl = s.PictureUrl, 
            Title = s.Title, 
            Type = new TypeDTO
            {
                Id = s.Type.Id,  
                Name = s.Type.Name
            }, 
            TypeId = s.TypeId
        }).SingleOrDefault(s => s.Id == songId));
    }
    [HttpGet("{songId}/edit")]
    // [Authorize]
    public IActionResult GetSongByIdForEdit(int songId)
    {
        Song foundSong = _dbContext.Songs.SingleOrDefault(s => s.Id == songId);

        return Ok(new SongForEditDTO 
        {
            Id = foundSong.Id, 
            Description = foundSong.Description, 
            GenreId = foundSong.GenreId, 
            Lyrics = foundSong.Lyrics, 
            PictureUrl = foundSong.PictureUrl, 
            Title = foundSong.Title, 
            TypeId = foundSong.TypeId
        });
    }
    [HttpPut("{songId}")]
    //[Authorize]
    public IActionResult Edit(int songId, Song song)
    {
        Song songToUpdate = _dbContext.Songs.SingleOrDefault(s => s.Id == songId);
        if (songToUpdate == null)
        {
            return NotFound();
        }
        else if (songId != song.Id)
        {
            return BadRequest();
        }

        songToUpdate.Title = song.Title;
        songToUpdate.Description = song.Description;
        songToUpdate.Lyrics = song.Lyrics;
        songToUpdate.TypeId = song.TypeId;
        songToUpdate.GenreId  = song.GenreId;
        // songToUpdate.PictureUrl = song.PictureUrl;
        // songToUpdate.PictureUrl = song.SongUrl
        
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{songId}")]
    // [Authorize]
    public IActionResult SongDelete(int songId)
    {
        Song foundSong = _dbContext.Songs.SingleOrDefault(c => c.Id == songId);
        if (foundSong == null) 
        {
            return NotFound();
        }
        _dbContext.Songs.Remove(foundSong);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
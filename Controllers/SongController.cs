using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadenceCollab.Data;
using CadenceCollab.Models;
using CadenceCollab.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
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
            .ThenInclude(artistsong => artistsong.UserProfile)
        .Select(s => new SongDTO 
        {
            Id = s.Id, 
            ArtistSongs = s.ArtistSongs.Select(artistsong => new ArtistSongsForSongsDTO
            {
                Id = artistsong.Id, 
                UserProfile = new UserProfileForSongListDTO
                {
                    Id = artistsong.UserProfile.Id, 
                    Name  =  artistsong.UserProfile.IdentityUser.UserName
                }, 
                UserProfileId = artistsong.UserProfileId, 
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
            .ThenInclude(artistsong => artistsong.UserProfile)
        .Select(s => new SongDTO 
        {
            Id = s.Id, 
            ArtistSongs = s.ArtistSongs.Select(artistsong => new ArtistSongsForSongsDTO
            {
                Id = artistsong.Id, 
                UserProfile = new UserProfileForSongListDTO
                {
                    Id = artistsong.UserProfile.Id, 
                    Name  =  artistsong.UserProfile.IdentityUser.UserName
                }, 
                UserProfileId = artistsong.UserProfileId, 
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
    
    [HttpPost]
    // [Authorize]
    public IActionResult Create(SongForPostDTO song)
    {
        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == song.UserProfileId);
        if (foundUserProfile == null)
        {
            return NotFound("No User with that Id found!");
        }
        Genre foundGenre = _dbContext.Genres.SingleOrDefault(c => c.Id == song.GenreId);
        if (foundGenre == null)
        {
            return NotFound("No Genre with that Id found!");
        }

        Song newSong = new Song()
        {
            UserProfileId = song.UserProfileId,
            CategoryId = song.CategoryId,
            Title = song.Title,
            Content = song.Content,
            HeaderImageURL = song.HeaderImageURL,
            IsApproved = false,
            DateCreated = DateTime.Now,
            PublicationDate = song.PublicationDate
        };

        _dbContext.Songs.Add(newSong);
        _dbContext.SaveChanges();

        SongDTO createdSong = _dbContext.Songs
            .Include(p => p.UserProfile)
            .Include(p => p.Category)
            .Select(p => new SongDTO()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CategoryId = p.CategoryId,
                UserProfileId = p.UserProfileId,
                DateCreated = p.DateCreated,
                PublicationDate = p.PublicationDate,
                UserProfile = new UserProfileForSongDTO()
                {
                    Id = p.UserProfile.Id,
                    FirstName = p.UserProfile.FirstName,
                    LastName = p.UserProfile.LastName,
                    ImageLocation = p.UserProfile.ImageLocation,
                    IsActive = p.UserProfile.IsActive
                },
                Category = p.CategoryId == null ? null : new CategoryNoNavDTO()
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .SingleOrDefault(p => p.Id == newSong.Id);

        return Created($"songs/{createdSong.Id}", createdSong);
        return Ok();
    }
}

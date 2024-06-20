using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CadenceCollab.Models;
using Microsoft.AspNetCore.Identity;

namespace CadenceCollab.Data;
public class CadenceCollabDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<ArtistSong> ArtistSongs { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public CadenceCollabDbContext(DbContextOptions<CadenceCollabDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "ADMIN"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
            Location = "Huntsville",
            TypeId = 3,
            GenreId = 3,
            ProfilePictureUrl = null,
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "1a2b3c4d-5678-9abc-def0-1234567890ab",
            UserName = "LiamWalker",
            Email = "liam.walker@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 2,
            IdentityUserId = "1a2b3c4d-5678-9abc-def0-1234567890ab",
            FirstName = "Liam",
            LastName = "Walker",
            Address = "102 Main Street",
            Location = "Huntsville",
            TypeId = 2,
            GenreId = 1,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "2b3c4d5e-6789-0abc-def1-2345678901bc",
            UserName = "OliviaSmith",
            Email = "olivia.smith@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 3,
            IdentityUserId = "2b3c4d5e-6789-0abc-def1-2345678901bc",
            FirstName = "Olivia",
            LastName = "Smith",
            Address = "103 Main Street",
            Location = "Huntsville",
            TypeId = 1,
            GenreId = 2,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3c4d5e6f-7890-1abc-def2-3456789012cd",
            UserName = "NoahJohnson",
            Email = "noah.johnson@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 4,
            IdentityUserId = "3c4d5e6f-7890-1abc-def2-3456789012cd",
            FirstName = "Noah",
            LastName = "Johnson",
            Address = "104 Main Street",
            Location = "Huntsville",
            TypeId = 3,
            GenreId = 3,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "4d5e6f70-8901-2abc-def3-4567890123de",
            UserName = "EmmaBrown",
            Email = "emma.brown@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 5,
            IdentityUserId = "4d5e6f70-8901-2abc-def3-4567890123de",
            FirstName = "Emma",
            LastName = "Brown",
            Address = "105 Main Street",
            Location = "Huntsville",
            TypeId = 2,
            GenreId = 1,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "5e6f7081-9012-3abc-def4-5678901234ef",
            UserName = "AvaDavis",
            Email = "ava.davis@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 6,
            IdentityUserId = "5e6f7081-9012-3abc-def4-5678901234ef",
            FirstName = "Ava",
            LastName = "Davis",
            Address = "106 Main Street",
            Location = "Huntsville",
            TypeId = 1,
            GenreId = 2,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Rock" },
            new Genre { Id = 2, Name = "Pop" },
            new Genre { Id = 3, Name = "Jazz" },
            new Genre { Id = 4, Name = "Classical" },
            new Genre { Id = 5, Name = "Hip-Hop" }
        );

        modelBuilder.Entity<Type>().HasData(
            new Type { Id = 1, Name = "Vocals" },
            new Type { Id = 2, Name = "Instrumentation" },
            new Type { Id = 3, Name = "Songwriting" },
            new Type { Id = 4, Name = "Mixing/Mastering" },
            new Type { Id = 5, Name = "Percussion" }
        );

        modelBuilder.Entity<Song>().HasData(
            new Song { Id = 1, Title = "Echoes of Silence", GenreId = 1, TypeId = 1, Description = "A haunting rock ballad", Lyrics = "In the shadows, where dreams lie broken, echoes of silence, words unspoken..." },
            new Song { Id = 2, Title = "Pop Star Dreams", GenreId = 2, TypeId = 2, Description = "An upbeat pop anthem", Lyrics = "Shining lights, city nights, chasing those pop star dreams tonight..." },
            new Song { Id = 3, Title = "Jazz in the Night", GenreId = 3, TypeId = 3, Description = "Smooth jazz tune", Lyrics = "Under the moonlight, we sway, jazz in the night, leads the way..." },
            new Song { Id = 4, Title = "Classical Reverie", GenreId = 4, TypeId = 1, Description = "A serene classical piece", Lyrics = "Instrumental melodies that drift and soar, a classical reverie forevermore..." },
            new Song { Id = 5, Title = "Hip-Hop Hustle", GenreId = 5, TypeId = 2, Description = "A powerful hip-hop track", Lyrics = "On the streets, we hustle and grind, hip-hop beats, always on my mind..." },
            new Song { Id = 6, Title = "Rock and Roll Heart", GenreId = 1, TypeId = 2, Description = "An energetic rock song", Lyrics = "With a rock and roll heart, we never part, music flows, right from the start..." },
            new Song { Id = 7, Title = "Pop Love", GenreId = 2, TypeId = 3, Description = "A catchy pop love song", Lyrics = "Dancing in the rain, pop love so sweet, feeling the beat, as our hearts meet..." },
            new Song { Id = 8, Title = "Jazz Cafe", GenreId = 3, TypeId = 1, Description = "A cool jazz track", Lyrics = "In the jazz cafe, we play all night, melodies sway, in the soft light..." },
            new Song { Id = 9, Title = "Symphony of Dreams", GenreId = 4, TypeId = 2, Description = "A grand symphonic piece", Lyrics = "Instrumental symphony that dreams unfold, a timeless tale forever told..." },
            new Song { Id = 10, Title = "Urban Vibes", GenreId = 5, TypeId = 3, Description = "A modern hip-hop tune", Lyrics = "In the city, urban vibes collide, beats and rhymes, on a wild ride..." }
        );

        modelBuilder.Entity<ArtistSong>().HasData(
            new ArtistSong { Id = 1, UserProfileId = 1, SongId = 1 },
            new ArtistSong { Id = 2, UserProfileId = 2, SongId = 2 },
            new ArtistSong { Id = 3, UserProfileId = 3, SongId = 3 },
            new ArtistSong { Id = 4, UserProfileId = 4, SongId = 4 },
            new ArtistSong { Id = 5, UserProfileId = 5, SongId = 5 },
            new ArtistSong { Id = 6, UserProfileId = 1, SongId = 6 },
            new ArtistSong { Id = 7, UserProfileId = 2, SongId = 7 },
            new ArtistSong { Id = 8, UserProfileId = 3, SongId = 8 },
            new ArtistSong { Id = 9, UserProfileId = 4, SongId = 9 },
            new ArtistSong { Id = 10, UserProfileId = 5, SongId = 10 }
        );
    }
}

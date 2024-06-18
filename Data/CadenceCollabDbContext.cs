using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CadenceCollab.Models;
using Microsoft.AspNetCore.Identity;

namespace CadenceCollab.Data;
public class CadenceCollabDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
        // public DbSet<Artist> Artists { get; set; }
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
            NormalizedName = "admin"
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
            UserName = "User1",
            Email = "user1@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 2,
            IdentityUserId = "1a2b3c4d-5678-9abc-def0-1234567890ab",
            FirstName = "User",
            LastName = "One",
            Address = "102 Main Street",
            Location = "Huntsville",
            TypeId = 2,
            GenreId = 1,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "2b3c4d5e-6789-0abc-def1-2345678901bc",
            UserName = "User2",
            Email = "user2@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 3,
            IdentityUserId = "2b3c4d5e-6789-0abc-def1-2345678901bc",
            FirstName = "User",
            LastName = "Two",
            Address = "103 Main Street",
            Location = "Huntsville",
            TypeId = 1,
            GenreId = 2,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3c4d5e6f-7890-1abc-def2-3456789012cd",
            UserName = "User3",
            Email = "user3@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 4,
            IdentityUserId = "3c4d5e6f-7890-1abc-def2-3456789012cd",
            FirstName = "User",
            LastName = "Three",
            Address = "104 Main Street",
            Location = "Huntsville",
            TypeId = 3,
            GenreId = 3,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "4d5e6f70-8901-2abc-def3-4567890123de",
            UserName = "User4",
            Email = "user4@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 5,
            IdentityUserId = "4d5e6f70-8901-2abc-def3-4567890123de",
            FirstName = "User",
            LastName = "Four",
            Address = "105 Main Street",
            Location = "Huntsville",
            TypeId = 2,
            GenreId = 1,
            ProfilePictureUrl = null
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "5e6f7081-9012-3abc-def4-5678901234ef",
            UserName = "User5",
            Email = "user5@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 6,
            IdentityUserId = "5e6f7081-9012-3abc-def4-5678901234ef",
            FirstName = "User",
            LastName = "Five",
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

            // modelBuilder.Entity<Artist>().HasData(
            //     new Artist { Id = 1, Name = "Artist One", TypeId = 1, Location = "New York", GenreId = 1 },
            //     new Artist { Id = 2, Name = "Artist Two", TypeId = 2, Location = "Los Angeles", GenreId = 2 },
            //     new Artist { Id = 3, Name = "Artist Three", TypeId = 3, Location = "Chicago", GenreId = 3 },
            //     new Artist { Id = 4, Name = "Artist Four", TypeId = 1, Location = "San Francisco", GenreId = 4 },
            //     new Artist { Id = 5, Name = "Artist Five", TypeId = 2, Location = "Seattle", GenreId = 5 }
            // );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Song One", GenreId = 1, TypeId = 1, Description = "Description One" },
                new Song { Id = 2, Title = "Song Two", GenreId = 2, TypeId = 2, Description = "Description Two" },
                new Song { Id = 3, Title = "Song Three", GenreId = 3, TypeId = 3, Description = "Description Three" },
                new Song { Id = 4, Title = "Song Four", GenreId = 4, TypeId = 1, Description = "Description Four" },
                new Song { Id = 5, Title = "Song Five", GenreId = 5, TypeId = 2, Description = "Description Five" },
                new Song { Id = 6, Title = "Song Six", GenreId = 1, TypeId = 2, Description = "Description Six" },
                new Song { Id = 7, Title = "Song Seven", GenreId = 2, TypeId = 3, Description = "Description Seven" },
                new Song { Id = 8, Title = "Song Eight", GenreId = 3, TypeId = 1, Description = "Description Eight" },
                new Song { Id = 9, Title = "Song Nine", GenreId = 4, TypeId = 2, Description = "Description Nine" },
                new Song { Id = 10, Title = "Song Ten", GenreId = 5, TypeId = 3, Description = "Description Ten" }
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
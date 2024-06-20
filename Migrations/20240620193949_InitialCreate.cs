using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cadence_Collab.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Lyrics = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PictureUrl = table.Column<string>(type: "text", nullable: true),
                    SongAudioUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    SongId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a2b3c4d-5678-9abc-def0-1234567890ab", 0, "bcf072b2-8c7c-4631-b05d-e7332679dc47", "liam.walker@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFriB5MLy3o9xCfB1YZEG3/Zm/YmSNZjUqat2QJq6mTjWhxQn5M9bMb8qiYuIPkyOA==", null, false, "d395daa2-02f2-4cee-929d-09874c06c29b", false, "LiamWalker" },
                    { "2b3c4d5e-6789-0abc-def1-2345678901bc", 0, "71fabedc-03c0-4208-bcb8-6dc747f50946", "olivia.smith@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEER8t1EhvJMfIHF9YwreG9YcFxiRzCgTPHbCv8pHYBhpGM8gVIHfGyOpU8CjlAomNQ==", null, false, "993e0cc0-9453-4f7e-ac14-760914fda363", false, "OliviaSmith" },
                    { "3c4d5e6f-7890-1abc-def2-3456789012cd", 0, "3fd60502-c49e-4423-a182-19c0274645c6", "noah.johnson@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJm9NM33tzlwg4aFEMTNzSAmJigdYiZ+GIiL6G9h5slgUXfNIR6slC/071Wci7lNpQ==", null, false, "d7fa2544-8b53-48fb-9f7b-a09db5ff54ea", false, "NoahJohnson" },
                    { "4d5e6f70-8901-2abc-def3-4567890123de", 0, "0bb8fabc-b304-47c8-ac8b-838cb43dcbd1", "emma.brown@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEM7Bwg776LZyl2uEmYgv+g3yYywkOKL1yoQ6BSTnRdWOK1E0mAbwGeciLjtIgybxQ==", null, false, "1750bcd0-f6e3-4bd2-8cc9-fae5a46a203a", false, "EmmaBrown" },
                    { "5e6f7081-9012-3abc-def4-5678901234ef", 0, "cbf4c86b-26bf-42a1-838f-84733a2bdd03", "ava.davis@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGxknQiDW//Ua+SIHTNks/vz1qDD0SftT5o/GhLvSnzSH3zE33j32Wv+FR197103Pg==", null, false, "926b05c8-6b70-4c11-9c11-d0f8e34d374d", false, "AvaDavis" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "ccd2b431-1b10-4e1c-90be-46e952d1932a", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEBr2TY3m/3rFC5xaFetmM1bjQYoUWzVXyoYw0YwJcRyeEIbGRaDKLO6+77kDt3daCQ==", null, false, "7b7f80c6-39b2-4fde-badf-1e7857e22de8", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Classical" },
                    { 5, "Hip-Hop" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vocals" },
                    { 2, "Instrumentation" },
                    { 3, "Songwriting" },
                    { 4, "Mixing/Mastering" },
                    { 5, "Percussion" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Description", "GenreId", "Lyrics", "PictureUrl", "SongAudioUrl", "Title", "TypeId" },
                values: new object[,]
                {
                    { 1, "A haunting rock ballad", 1, "In the shadows, where dreams lie broken, echoes of silence, words unspoken...", null, null, "Echoes of Silence", 1 },
                    { 2, "An upbeat pop anthem", 2, "Shining lights, city nights, chasing those pop star dreams tonight...", null, null, "Pop Star Dreams", 2 },
                    { 3, "Smooth jazz tune", 3, "Under the moonlight, we sway, jazz in the night, leads the way...", null, null, "Jazz in the Night", 3 },
                    { 4, "A serene classical piece", 4, "Instrumental melodies that drift and soar, a classical reverie forevermore...", null, null, "Classical Reverie", 1 },
                    { 5, "A powerful hip-hop track", 5, "On the streets, we hustle and grind, hip-hop beats, always on my mind...", null, null, "Hip-Hop Hustle", 2 },
                    { 6, "An energetic rock song", 1, "With a rock and roll heart, we never part, music flows, right from the start...", null, null, "Rock and Roll Heart", 2 },
                    { 7, "A catchy pop love song", 2, "Dancing in the rain, pop love so sweet, feeling the beat, as our hearts meet...", null, null, "Pop Love", 3 },
                    { 8, "A cool jazz track", 3, "In the jazz cafe, we play all night, melodies sway, in the soft light...", null, null, "Jazz Cafe", 1 },
                    { 9, "A grand symphonic piece", 4, "Instrumental symphony that dreams unfold, a timeless tale forever told...", null, null, "Symphony of Dreams", 2 },
                    { 10, "A modern hip-hop tune", 5, "In the city, urban vibes collide, beats and rhymes, on a wild ride...", null, null, "Urban Vibes", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "GenreId", "IdentityUserId", "LastName", "Location", "ProfilePictureUrl", "TypeId" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", 3, "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator", "Huntsville", null, 3 },
                    { 2, "102 Main Street", "Liam", 1, "1a2b3c4d-5678-9abc-def0-1234567890ab", "Walker", "Huntsville", null, 2 },
                    { 3, "103 Main Street", "Olivia", 2, "2b3c4d5e-6789-0abc-def1-2345678901bc", "Smith", "Huntsville", null, 1 },
                    { 4, "104 Main Street", "Noah", 3, "3c4d5e6f-7890-1abc-def2-3456789012cd", "Johnson", "Huntsville", null, 3 },
                    { 5, "105 Main Street", "Emma", 1, "4d5e6f70-8901-2abc-def3-4567890123de", "Brown", "Huntsville", null, 2 },
                    { 6, "106 Main Street", "Ava", 2, "5e6f7081-9012-3abc-def4-5678901234ef", "Davis", "Huntsville", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ArtistSongs",
                columns: new[] { "Id", "SongId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 1 },
                    { 7, 7, 2 },
                    { 8, 8, 3 },
                    { 9, 9, 4 },
                    { 10, 10, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_SongId",
                table: "ArtistSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_UserProfileId",
                table: "ArtistSongs",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_TypeId",
                table: "Songs",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_GenreId",
                table: "UserProfiles",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_TypeId",
                table: "UserProfiles",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSongs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}

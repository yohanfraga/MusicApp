using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MusicApp");

            migrationBuilder.CreateTable(
                name: "Artist",
                schema: "MusicApp",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", nullable: false),
                    join_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "MusicApp",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", nullable: false),
                    join_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "MusicApp",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    artist_id = table.Column<long>(type: "bigint", nullable: false),
                    ArtistId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistId1",
                        column: x => x.ArtistId1,
                        principalSchema: "MusicApp",
                        principalTable: "Artist",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Album_Artist_artist_id",
                        column: x => x.artist_id,
                        principalSchema: "MusicApp",
                        principalTable: "Artist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistFollow",
                schema: "MusicApp",
                columns: table => new
                {
                    artist_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    follow_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFollow", x => new { x.artist_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_ArtistFollow_Artist_ArtistId1",
                        column: x => x.ArtistId1,
                        principalSchema: "MusicApp",
                        principalTable: "Artist",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArtistFollow_Artist_artist_id",
                        column: x => x.artist_id,
                        principalSchema: "MusicApp",
                        principalTable: "Artist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFollow_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArtistFollow_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                schema: "MusicApp",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", nullable: false),
                    description = table.Column<string>(type: "varchar(200)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_Playlist_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Playlist_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                schema: "MusicApp",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.id);
                    table.ForeignKey(
                        name: "FK_Music_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "MusicApp",
                        principalTable: "Album",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistFollow",
                schema: "MusicApp",
                columns: table => new
                {
                    playlist_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    follow_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistFollow", x => new { x.playlist_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_PlaylistFollow_Playlist_playlist_id",
                        column: x => x.playlist_id,
                        principalSchema: "MusicApp",
                        principalTable: "Playlist",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PlaylistFollow_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PlaylistFollow_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                schema: "MusicApp",
                columns: table => new
                {
                    Music_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    like_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusicId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.Music_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_Like_Music_MusicId1",
                        column: x => x.MusicId1,
                        principalSchema: "MusicApp",
                        principalTable: "Music",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Like_Music_Music_id",
                        column: x => x.Music_id,
                        principalSchema: "MusicApp",
                        principalTable: "Music",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Like_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "MusicApp",
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistMusic",
                schema: "MusicApp",
                columns: table => new
                {
                    music_id = table.Column<long>(type: "bigint", nullable: false),
                    playlist_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistMusic", x => new { x.music_id, x.playlist_id });
                    table.ForeignKey(
                        name: "FK_PlaylistMusic_Music_music_id",
                        column: x => x.music_id,
                        principalSchema: "MusicApp",
                        principalTable: "Music",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PlaylistMusic_Playlist_playlist_id",
                        column: x => x.playlist_id,
                        principalSchema: "MusicApp",
                        principalTable: "Playlist",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_artist_id",
                schema: "MusicApp",
                table: "Album",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId1",
                schema: "MusicApp",
                table: "Album",
                column: "ArtistId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFollow_ArtistId1",
                schema: "MusicApp",
                table: "ArtistFollow",
                column: "ArtistId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFollow_user_id",
                schema: "MusicApp",
                table: "ArtistFollow",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFollow_UserId1",
                schema: "MusicApp",
                table: "ArtistFollow",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Like_MusicId1",
                schema: "MusicApp",
                table: "Like",
                column: "MusicId1");

            migrationBuilder.CreateIndex(
                name: "IX_Like_user_id",
                schema: "MusicApp",
                table: "Like",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId1",
                schema: "MusicApp",
                table: "Like",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Music_AlbumId",
                schema: "MusicApp",
                table: "Music",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_user_id",
                schema: "MusicApp",
                table: "Playlist",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId1",
                schema: "MusicApp",
                table: "Playlist",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFollow_user_id",
                schema: "MusicApp",
                table: "PlaylistFollow",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFollow_UserId1",
                schema: "MusicApp",
                table: "PlaylistFollow",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistMusic_playlist_id",
                schema: "MusicApp",
                table: "PlaylistMusic",
                column: "playlist_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistFollow",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "Like",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "PlaylistFollow",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "PlaylistMusic",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "Music",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "Playlist",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "User",
                schema: "MusicApp");

            migrationBuilder.DropTable(
                name: "Artist",
                schema: "MusicApp");
        }
    }
}

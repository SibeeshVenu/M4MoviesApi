using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M4Movie.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    WatchListMovieId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AverageVote = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 750, nullable: true),
                    IsWatchList = table.Column<bool>(nullable: false),
                    MovieDescription = table.Column<string>(maxLength: 750, nullable: true),
                    MovieId = table.Column<long>(nullable: false),
                    MovieImage = table.Column<string>(maxLength: 500, nullable: false),
                    MovieName = table.Column<string>(maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.WatchListMovieId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

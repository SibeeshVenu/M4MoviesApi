using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M4Movie.Api.Data.Migrations
{
    public partial class Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    AverageVote = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 750, nullable: true),
                    IsWatchList = table.Column<bool>(nullable: false),
                    MovieDescription = table.Column<string>(maxLength: 750, nullable: true),
                    MovieImage = table.Column<string>(maxLength: 500, nullable: false),
                    MovieName = table.Column<string>(maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

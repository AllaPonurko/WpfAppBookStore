using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfAppBookStore.Migrations
{
    public partial class addId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "books",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

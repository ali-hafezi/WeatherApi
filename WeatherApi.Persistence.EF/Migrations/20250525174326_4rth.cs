using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class _4rth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "WeatherReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Station",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Cities",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "WeatherReports");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Station");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Cities");
        }
    }
}

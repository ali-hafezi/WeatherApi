using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Hilo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SQ_Hilo_City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SQ_Hilo_City");
        }
    }
}

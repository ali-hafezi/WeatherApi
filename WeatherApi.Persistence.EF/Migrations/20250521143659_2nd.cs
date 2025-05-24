using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherReports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<long>(type: "bigint", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeatherData_temperature = table.Column<double>(type: "float", nullable: false),
                    WeatherData_pressure = table.Column<double>(type: "float", nullable: false),
                    WeatherData_humidity = table.Column<int>(type: "int", nullable: false),
                    WeatherData_windSpeed = table.Column<double>(type: "float", nullable: false),
                    WeatherData_windDirection = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherReports_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReports_StationId",
                table: "WeatherReports",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherReports");
        }
    }
}

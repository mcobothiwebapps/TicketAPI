using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventDate", "EventName", "Price", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 29, 23, 57, 28, 937, DateTimeKind.Local).AddTicks(1326), "Rock Concert", 150.00m, "VIP" },
                    { 2, new DateTime(2026, 4, 3, 23, 57, 28, 937, DateTimeKind.Local).AddTicks(1345), "Theater Play", 45.00m, "Regular" },
                    { 3, new DateTime(2026, 4, 8, 23, 57, 28, 937, DateTimeKind.Local).AddTicks(1347), "Sports Game", 85.00m, "Front Row" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}

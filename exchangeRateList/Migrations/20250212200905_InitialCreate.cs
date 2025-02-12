using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exchangeRateList.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CnbMid = table.Column<decimal>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    CurrBuy = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrMid = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrSell = table.Column<decimal>(type: "TEXT", nullable: false),
                    EcbMid = table.Column<decimal>(type: "TEXT", nullable: false),
                    Move = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    ValBuy = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValMid = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValSell = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}

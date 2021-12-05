using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace DataApi1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarih_Dates",
                columns: table => new
                {
                    trId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tarih = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Bulten_No = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarih_Dates", x => x.trId);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    crId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    Isim = table.Column<string>(type: "text", nullable: true),
                    CurrencyName = table.Column<string>(type: "text", nullable: true),
                    ForexBuying = table.Column<string>(type: "text", nullable: true),
                    ForexSelling = table.Column<string>(type: "text", nullable: true),
                    BanknoteBuying = table.Column<string>(type: "text", nullable: true),
                    BanknoteSelling = table.Column<string>(type: "text", nullable: true),
                    CrossRateUSD = table.Column<string>(type: "text", nullable: true),
                    CrossRateOther = table.Column<string>(type: "text", nullable: true),
                    CrossOrder = table.Column<string>(type: "text", nullable: true),
                    Kod = table.Column<string>(type: "text", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    tarihId = table.Column<int>(type: "int", nullable: false),
                    Tarih_DatetrId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.crId);
                    table.ForeignKey(
                        name: "FK_currencies_tarih_Dates_Tarih_DatetrId",
                        column: x => x.Tarih_DatetrId,
                        principalTable: "tarih_Dates",
                        principalColumn: "trId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_currencies_Tarih_DatetrId",
                table: "currencies",
                column: "Tarih_DatetrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "tarih_Dates");
        }
    }
}

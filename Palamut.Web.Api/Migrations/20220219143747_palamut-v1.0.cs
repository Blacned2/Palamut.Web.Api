using Microsoft.EntityFrameworkCore.Migrations;

namespace Palamut.Web.Api.Migrations
{
    public partial class palamutv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alicilar",
                columns: table => new
                {
                    AliciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AliciName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliciTelNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alicilar", x => x.AliciID);
                });

            migrationBuilder.CreateTable(
                name: "Saticilar",
                columns: table => new
                {
                    SaticiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaticiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaticiTelNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saticilar", x => x.SaticiID);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    UrunFiyat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunID);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AliciID = table.Column<int>(type: "int", nullable: false),
                    SaticiID = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Siparisler_Alicilar_AliciID",
                        column: x => x.AliciID,
                        principalTable: "Alicilar",
                        principalColumn: "AliciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparisler_Saticilar_SaticiID",
                        column: x => x.SaticiID,
                        principalTable: "Saticilar",
                        principalColumn: "SaticiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_AliciID",
                table: "Siparisler",
                column: "AliciID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SaticiID",
                table: "Siparisler",
                column: "SaticiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Alicilar");

            migrationBuilder.DropTable(
                name: "Saticilar");
        }
    }
}

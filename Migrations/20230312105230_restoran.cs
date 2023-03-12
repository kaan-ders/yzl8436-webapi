using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class restoran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestoranId",
                table: "Yemek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restoran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoran", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yemek_RestoranId",
                table: "Yemek",
                column: "RestoranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yemek_Restoran_RestoranId",
                table: "Yemek",
                column: "RestoranId",
                principalTable: "Restoran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yemek_Restoran_RestoranId",
                table: "Yemek");

            migrationBuilder.DropTable(
                name: "Restoran");

            migrationBuilder.DropIndex(
                name: "IX_Yemek_RestoranId",
                table: "Yemek");

            migrationBuilder.DropColumn(
                name: "RestoranId",
                table: "Yemek");
        }
    }
}

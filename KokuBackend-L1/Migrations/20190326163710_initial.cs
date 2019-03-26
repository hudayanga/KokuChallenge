using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KokuBackend_L1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "L2Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Partner = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    ForexRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L2Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "L3Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Partner = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    EffectiveRate = table.Column<decimal>(nullable: false),
                    ServiceCharge = table.Column<decimal>(nullable: false),
                    TakenQuantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L3Rates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "L2Rates");

            migrationBuilder.DropTable(
                name: "L3Rates");
        }
    }
}

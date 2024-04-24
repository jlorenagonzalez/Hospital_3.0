using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_2._0.Migrations.Occupation
{
    /// <inheritdoc />
    public partial class Inici_Occupation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    OccupationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gendero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.OccupationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");
        }
    }
}

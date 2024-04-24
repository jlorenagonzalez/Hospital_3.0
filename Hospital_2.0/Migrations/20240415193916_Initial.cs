using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firt_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Second_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Second_last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone_Number = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinic_History = table.Column<int>(type: "int", nullable: false),
                    ID_Doctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

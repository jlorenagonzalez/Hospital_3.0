using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_2._0.Migrations.Occupation
{
    /// <inheritdoc />
    public partial class Inici_Occupation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameDoctor",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "Gendero",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "SpecialtyDoctor",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "Occupations");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Occupations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOccupation",
                table: "Occupations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Occupations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Occupations",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOccupation",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Occupations");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Occupations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameDoctor",
                table: "Occupations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gendero",
                table: "Occupations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Occupations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialtyDoctor",
                table: "Occupations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "Occupations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

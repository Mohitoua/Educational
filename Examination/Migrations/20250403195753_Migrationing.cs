using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination.Migrations
{
    /// <inheritdoc />
    public partial class Migrationing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    LCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PCode = table.Column<int>(type: "int", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    LCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LGrade = table.Column<int>(type: "int", nullable: false),
                    LTeacherName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LTeacherSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    PCode = table.Column<int>(type: "int", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Exams");

            migrationBuilder.DropTable(name: "Lessons");

            migrationBuilder.DropTable(name: "Pupils");
        }
    }
}

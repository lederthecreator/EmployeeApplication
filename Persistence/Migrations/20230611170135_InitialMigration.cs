using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "employee_seq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false),
                    full_name = table.Column<string>(type: "varchar(500)", nullable: false),
                    surname = table.Column<string>(type: "varchar(200)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(200)", nullable: false),
                    patronymic_name = table.Column<string>(type: "varchar(200)", nullable: true),
                    birth_day = table.Column<DateOnly>(type: "date", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    salary = table.Column<decimal>(type: "numeric(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropSequence(
                name: "employee_seq");
        }
    }
}

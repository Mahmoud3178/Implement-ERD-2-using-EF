using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_3_EF_Core.Migrations
{
    /// <inheritdoc />
    public partial class Prject3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "VARCHAR(128)", maxLength: 128, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aircrafts_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "airlinePhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airlinePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_airlinePhones_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assigneds",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumOfPassengers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assigneds", x => new { x.AircraftId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_assigneds_aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assigneds_routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crewces",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    MajPilot = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AssisPilot = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Host1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Host2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crewces", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_crewces_aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employeeQualifications_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aircrafts_AirlineId",
                table: "aircrafts",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_airlinePhones_AirlineId",
                table: "airlinePhones",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_assigneds_RouteId",
                table: "assigneds",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeQualifications_EmployeeId",
                table: "employeeQualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_AirlineId",
                table: "employees",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AirlineId",
                table: "transactions",
                column: "AirlineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airlinePhones");

            migrationBuilder.DropTable(
                name: "assigneds");

            migrationBuilder.DropTable(
                name: "crewces");

            migrationBuilder.DropTable(
                name: "employeeQualifications");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "aircrafts");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "airlines");
        }
    }
}

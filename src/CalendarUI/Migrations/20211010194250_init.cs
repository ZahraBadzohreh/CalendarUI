using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarUI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    Attendees = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Organizer = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Attendees", "DateTime", "Description", "Organizer" },
                values: new object[,]
                {
                    { new Guid("de7c6f81-68bc-45cb-8ec8-60f6aa0250b0"), "Fal J, Mark Z, Jeff Z", new DateTime(2021, 10, 15, 23, 12, 49, 534, DateTimeKind.Local).AddTicks(4987), "Interview", "Amir" },
                    { new Guid("daec16b2-025f-4401-9e38-c4379f62ec46"), "A J, D S", new DateTime(2021, 10, 25, 23, 12, 49, 540, DateTimeKind.Local).AddTicks(3542), "Meeting", "Javad" },
                    { new Guid("ebc22679-c0e4-4d94-acb0-68286270e1a5"), "Fin J, Dar S", new DateTime(2021, 11, 4, 23, 12, 49, 540, DateTimeKind.Local).AddTicks(3641), "Int with Fin", "Ali" },
                    { new Guid("96059c0b-737d-4789-8b49-f78eb421478a"), "John D, Ali S", new DateTime(2021, 11, 24, 23, 12, 49, 540, DateTimeKind.Local).AddTicks(3666), "Meeting with Ali S", "Smith" },
                    { new Guid("ec5e460e-0a48-4f7f-ae1a-963dca87c0ab"), "Smith J, Sun S", new DateTime(2021, 12, 14, 23, 12, 49, 540, DateTimeKind.Local).AddTicks(3718), "Interview with Smith", "John" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}

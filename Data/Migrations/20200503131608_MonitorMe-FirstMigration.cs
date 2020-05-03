using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MonitorMeFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.MonitorGroup",
                columns: table => new
                {
                    MonitorGroupId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.MonitorGroup", x => x.MonitorGroupId);
                });

            migrationBuilder.CreateTable(
                name: "log.SysLog",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log.SysLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Monitor",
                columns: table => new
                {
                    MonitorId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    MaxInterval = table.Column<TimeSpan>(nullable: false),
                    LastBeat = table.Column<DateTime>(nullable: false),
                    MonitorGroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Monitor", x => x.MonitorId);
                    table.ForeignKey(
                        name: "FK_dbo.Monitor_dbo.MonitorGroup_MonitorGroupId",
                        column: x => x.MonitorGroupId,
                        principalTable: "dbo.MonitorGroup",
                        principalColumn: "MonitorGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "log.AlarmLog",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    MonitorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log.AlarmLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_log.AlarmLog_dbo.Monitor_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "dbo.Monitor",
                        principalColumn: "MonitorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Monitor_MonitorGroupId",
                table: "dbo.Monitor",
                column: "MonitorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_log.AlarmLog_MonitorId",
                table: "log.AlarmLog",
                column: "MonitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log.AlarmLog");

            migrationBuilder.DropTable(
                name: "log.SysLog");

            migrationBuilder.DropTable(
                name: "dbo.Monitor");

            migrationBuilder.DropTable(
                name: "dbo.MonitorGroup");
        }
    }
}

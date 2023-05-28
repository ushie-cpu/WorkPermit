using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPermitApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTermAndCondition = table.Column<bool>(type: "bit", nullable: false),
                    PermitStatus = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermits_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiteCheckers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsIsolated = table.Column<bool>(type: "bit", nullable: false),
                    IsCriticalByPassed = table.Column<bool>(type: "bit", nullable: false),
                    ByPassedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ByPassedTagNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByPassedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProvideAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsRestrictAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsCriticalLift = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialiLightning = table.Column<bool>(type: "bit", nullable: false),
                    IsJsaReviewed = table.Column<bool>(type: "bit", nullable: false),
                    OtherSpecialRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGastested = table.Column<bool>(type: "bit", nullable: false),
                    GasTesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteTestingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LELPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPermitId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteCheckers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteCheckers_WorkPermits_WorkPermitId",
                        column: x => x.WorkPermitId,
                        principalTable: "WorkPermits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteCheckers_WorkPermitId",
                table: "SiteCheckers",
                column: "WorkPermitId",
                unique: true,
                filter: "[WorkPermitId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermits_AppUserId",
                table: "WorkPermits",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteCheckers");

            migrationBuilder.DropTable(
                name: "WorkPermits");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}

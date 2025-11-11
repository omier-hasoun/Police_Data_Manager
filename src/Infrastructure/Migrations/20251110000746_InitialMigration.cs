using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "OfficerBadgeNumberSeq",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastModifiedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    ProgressReport = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FinalReport = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IncidentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvestigationStartedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ClosedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.CheckConstraint("CK_ClosedAt", "ClosedAt > IncidentDate and InvestigationStartedAt is null or ClosedAt > InvestigationStartedAt and ClosedAt <= GETUTCDATE()");
                    table.CheckConstraint("CK_IncidentDate", "IncidentDate < InvestigationStartedAt and IncidentDate <= GETUTCDATE()");
                    table.CheckConstraint("CK_InvestigationStartedAt", "IncidentDate is null or InvestigationStartedAt > IncidentDate and ClosedAt is null");
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                    table.CheckConstraint("CK_DateOfBirth", "DateOfBirth <= GETUTCDATE() and DateOfBirth > DateAdd(YEAR, -110, GETUTCDATE())");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: false),
                    Code = table.Column<string>(type: "CHAR(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evidences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CollectionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidences_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseParticipants_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseParticipants_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Witnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statements = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CitizenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Witnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Witnesses_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Witnesses_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "CHAR(15)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(254)", nullable: false),
                    InStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Officers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Officers_States_InStateId",
                        column: x => x.InStateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficerBadgeNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BadgeNumber = table.Column<string>(type: "CHAR(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerBadgeNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficerBadgeNumbers_Officers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastModifiedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LockTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginAttemptsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Officers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    IPAddress = table.Column<string>(type: "VARCHAR(45)", fixedLength: true, maxLength: 45, nullable: false),
                    DeviceInfo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseParticipants_CaseId",
                table: "CaseParticipants",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseParticipants_CitizenId",
                table: "CaseParticipants",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentDate",
                table: "Cases",
                column: "IncidentDate");

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_FullName",
                table: "Citizens",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_CaseId",
                table: "Evidences",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerBadgeNumbers_OfficerId",
                table: "OfficerBadgeNumbers",
                column: "OfficerId",
                unique: true,
                filter: "[OfficerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_FullName",
                table: "Officers",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Officers_DepartmentId",
                table: "Officers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_InStateId",
                table: "Officers",
                column: "InStateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginAudits_UserId",
                table: "UserLoginAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OfficerId",
                table: "Users",
                column: "OfficerId",
                unique: true,
                filter: "[OfficerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Witnesses_CaseId",
                table: "Witnesses",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Witnesses_CitizenId",
                table: "Witnesses",
                column: "CitizenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseParticipants");

            migrationBuilder.DropTable(
                name: "Evidences");

            migrationBuilder.DropTable(
                name: "OfficerBadgeNumbers");

            migrationBuilder.DropTable(
                name: "UserLoginAudits");

            migrationBuilder.DropTable(
                name: "Witnesses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropSequence(
                name: "OfficerBadgeNumberSeq",
                schema: "dbo");
        }
    }
}

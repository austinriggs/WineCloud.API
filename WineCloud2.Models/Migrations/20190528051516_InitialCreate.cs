using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineCloud2.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BottleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(maxLength: 16, nullable: true),
                    YearVintage = table.Column<int>(nullable: true),
                    Winery = table.Column<string>(maxLength: 64, nullable: true),
                    Varietal = table.Column<string>(maxLength: 64, nullable: true),
                    Vinyard = table.Column<string>(maxLength: 64, nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    PurchasePrice = table.Column<double>(nullable: true),
                    CellarId = table.Column<Guid>(nullable: false),
                    RackId = table.Column<Guid>(nullable: true),
                    ZoneId = table.Column<Guid>(nullable: true),
                    RackRowId = table.Column<Guid>(nullable: true),
                    StorageDate = table.Column<DateTime>(nullable: true),
                    StorageTemparature = table.Column<double>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<string>(maxLength: 64, nullable: true),
                    OpenedDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cellars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellarId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racks_Cellars_CellarId",
                        column: x => x.CellarId,
                        principalTable: "Cellars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CellarUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CellarId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellarUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellarUsers_Cellars_CellarId",
                        column: x => x.CellarId,
                        principalTable: "Cellars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CellarUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RackId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Temperature = table.Column<double>(nullable: true),
                    StaggeredRows = table.Column<bool>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RackRows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ZoneId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackRows_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bottles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BottleTypeId = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(maxLength: 16, nullable: true),
                    YearVintage = table.Column<int>(nullable: true),
                    Winery = table.Column<string>(maxLength: 64, nullable: true),
                    Varietal = table.Column<string>(maxLength: 64, nullable: true),
                    Vinyard = table.Column<string>(maxLength: 64, nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    PurchasePrice = table.Column<double>(nullable: true),
                    CellarId = table.Column<Guid>(nullable: false),
                    RackId = table.Column<Guid>(nullable: true),
                    ZoneId = table.Column<Guid>(nullable: true),
                    RackRowId = table.Column<Guid>(nullable: true),
                    RackColumnId = table.Column<Guid>(nullable: true),
                    StorageDate = table.Column<DateTime>(nullable: true),
                    StorageTemparature = table.Column<double>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<string>(maxLength: 64, nullable: true),
                    OpenedDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bottles_BottleTypes_BottleTypeId",
                        column: x => x.BottleTypeId,
                        principalTable: "BottleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bottles_Cellars_CellarId",
                        column: x => x.CellarId,
                        principalTable: "Cellars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bottles_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bottles_RackRows_RackRowId",
                        column: x => x.RackRowId,
                        principalTable: "RackRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bottles_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RackColumns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RackRowId = table.Column<Guid>(nullable: false),
                    BottleId = table.Column<Guid>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    BottleId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackColumns_Bottles_BottleId1",
                        column: x => x.BottleId1,
                        principalTable: "Bottles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RackColumns_RackRows_RackRowId",
                        column: x => x.RackRowId,
                        principalTable: "RackRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_BottleTypeId",
                table: "Bottles",
                column: "BottleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_CellarId",
                table: "Bottles",
                column: "CellarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_RackId",
                table: "Bottles",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_RackRowId",
                table: "Bottles",
                column: "RackRowId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_ZoneId",
                table: "Bottles",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CellarUsers_CellarId",
                table: "CellarUsers",
                column: "CellarId");

            migrationBuilder.CreateIndex(
                name: "IX_CellarUsers_UserId",
                table: "CellarUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RackColumns_BottleId1",
                table: "RackColumns",
                column: "BottleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RackColumns_RackRowId",
                table: "RackColumns",
                column: "RackRowId");

            migrationBuilder.CreateIndex(
                name: "IX_RackRows_ZoneId",
                table: "RackRows",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_CellarId",
                table: "Racks",
                column: "CellarId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_RackId",
                table: "Zones",
                column: "RackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellarUsers");

            migrationBuilder.DropTable(
                name: "RackColumns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bottles");

            migrationBuilder.DropTable(
                name: "BottleTypes");

            migrationBuilder.DropTable(
                name: "RackRows");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Cellars");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vlog.Migrations
{
    public partial class Init_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(nullable: true),
                    Specific = table.Column<string>(nullable: true),
                    RuralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    EstablishedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactEnum = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticFareIdentityItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticFareIdentityItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticOtherServiceFareItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogisticUnit = table.Column<int>(nullable: false),
                    Nominal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticOtherServiceFareItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticOtherServiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticOtherServiceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticPacketItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFrom = table.Column<string>(nullable: true),
                    NameTo = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CurrentNominal = table.Column<decimal>(nullable: false),
                    AirWayBill = table.Column<string>(nullable: true),
                    AddressFromId = table.Column<int>(nullable: false),
                    AddressToId = table.Column<int>(nullable: false),
                    LogisticServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticPacketItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogisticServiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LogisticFareIdentityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticServiceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegencyItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegencyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuralItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuralItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserRoleEnum = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvinceItems_CountryItems_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogisticFareNominalItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogisticFareIdentityId = table.Column<int>(nullable: true),
                    LogisticUnit = table.Column<int>(nullable: false),
                    Nominal = table.Column<decimal>(nullable: false),
                    MinimumEstimateDay = table.Column<int>(nullable: false),
                    MaximumEstimateDay = table.Column<int>(nullable: false),
                    RegencyFromId = table.Column<int>(nullable: false),
                    RegencyToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticFareNominalItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogisticFareNominalItems_LogisticFareIdentityItems_LogisticFareIdentityId",
                        column: x => x.LogisticFareIdentityId,
                        principalTable: "LogisticFareIdentityItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogisticFareNominalItems_LogisticFareIdentityId",
                table: "LogisticFareNominalItems",
                column: "LogisticFareIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceItems_CountryId",
                table: "ProvinceItems",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressItems");

            migrationBuilder.DropTable(
                name: "CompanyItems");

            migrationBuilder.DropTable(
                name: "ContactItems");

            migrationBuilder.DropTable(
                name: "LogisticFareNominalItems");

            migrationBuilder.DropTable(
                name: "LogisticOtherServiceFareItems");

            migrationBuilder.DropTable(
                name: "LogisticOtherServiceItems");

            migrationBuilder.DropTable(
                name: "LogisticPacketItems");

            migrationBuilder.DropTable(
                name: "LogisticServiceItems");

            migrationBuilder.DropTable(
                name: "ProvinceItems");

            migrationBuilder.DropTable(
                name: "RegencyItems");

            migrationBuilder.DropTable(
                name: "RuralItems");

            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "UserRoleItems");

            migrationBuilder.DropTable(
                name: "LogisticFareIdentityItems");

            migrationBuilder.DropTable(
                name: "CountryItems");
        }
    }
}

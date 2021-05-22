using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Winkellijst");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Winkellijst",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Winkellijst",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winkel",
                schema: "Winkellijst",
                columns: table => new
                {
                    WinkelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Winkelnaam = table.Column<string>(maxLength: 255, nullable: false),
                    Straat = table.Column<string>(maxLength: 255, nullable: false),
                    Huisnummer = table.Column<string>(maxLength: 12, nullable: false),
                    Stad = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkel", x => x.WinkelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Winkellijst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Winkellijst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Winkellijst",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Winkellijst",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Winkellijst",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                schema: "Winkellijst",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppGebruikerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikerId);
                    table.ForeignKey(
                        name: "FK_Gebruiker_AspNetUsers_AppGebruikerId",
                        column: x => x.AppGebruikerId,
                        principalSchema: "Winkellijst",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Afdeling",
                schema: "Winkellijst",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 255, nullable: false),
                    Volgorde = table.Column<int>(nullable: false),
                    WinkelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.AfdelingId);
                    table.ForeignKey(
                        name: "FK_Afdeling_Winkel_WinkelId",
                        column: x => x.WinkelId,
                        principalSchema: "Winkellijst",
                        principalTable: "Winkel",
                        principalColumn: "WinkelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boodschappenlijst",
                schema: "Winkellijst",
                columns: table => new
                {
                    WinkelLijstId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false),
                    AanmaakDatum = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boodschappenlijst", x => x.WinkelLijstId);
                    table.ForeignKey(
                        name: "FK_Boodschappenlijst_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalSchema: "Winkellijst",
                        principalTable: "Gebruiker",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Winkellijst",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 255, nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Beschrijving = table.Column<string>(nullable: false),
                    AfdelingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalSchema: "Winkellijst",
                        principalTable: "Afdeling",
                        principalColumn: "AfdelingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WinkelLijstProduct",
                schema: "Winkellijst",
                columns: table => new
                {
                    WinkelLijstProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Aantal = table.Column<int>(nullable: false),
                    WinkelLijstId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelLijstProduct", x => x.WinkelLijstProductId);
                    table.ForeignKey(
                        name: "FK_WinkelLijstProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Winkellijst",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinkelLijstProduct_Boodschappenlijst_WinkelLijstId",
                        column: x => x.WinkelLijstId,
                        principalSchema: "Winkellijst",
                        principalTable: "Boodschappenlijst",
                        principalColumn: "WinkelLijstId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afdeling_WinkelId",
                schema: "Winkellijst",
                table: "Afdeling",
                column: "WinkelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Winkellijst",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Winkellijst",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Winkellijst",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Winkellijst",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Winkellijst",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Winkellijst",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Winkellijst",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Boodschappenlijst_GebruikerId",
                schema: "Winkellijst",
                table: "Boodschappenlijst",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_AppGebruikerId",
                schema: "Winkellijst",
                table: "Gebruiker",
                column: "AppGebruikerId",
                unique: true,
                filter: "[AppGebruikerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AfdelingId",
                schema: "Winkellijst",
                table: "Product",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Naam",
                schema: "Winkellijst",
                table: "Product",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WinkelLijstProduct_ProductId",
                schema: "Winkellijst",
                table: "WinkelLijstProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelLijstProduct_WinkelLijstId",
                schema: "Winkellijst",
                table: "WinkelLijstProduct",
                column: "WinkelLijstId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "WinkelLijstProduct",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Boodschappenlijst",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Afdeling",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Gebruiker",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "Winkel",
                schema: "Winkellijst");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Winkellijst");
        }
    }
}

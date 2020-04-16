using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cultivars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScientificName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxaHierarchies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HierarchyKey = table.Column<string>(nullable: true),
                    TaxaPhilosophy = table.Column<int>(nullable: false),
                    TaxonomicCode = table.Column<string>(nullable: true),
                    TaxonomicCodeVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaHierarchies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CultivarPopularName",
                columns: table => new
                {
                    DataSetId = table.Column<Guid>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false),
                    CultivarId = table.Column<Guid>(nullable: false),
                    LanguageCultureName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Usage = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivarPopularName", x => new { x.DataSetId, x.LanguageCultureName, x.CultivarId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_CultivarPopularName_Cultivars_CultivarId",
                        column: x => x.CultivarId,
                        principalTable: "Cultivars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CultivarIdentifier",
                columns: table => new
                {
                    DataSetId = table.Column<Guid>(nullable: false),
                    CultivarId = table.Column<Guid>(nullable: false),
                    TaxonomicCode = table.Column<string>(maxLength: 32, nullable: false),
                    TaxonomicCodeVersion = table.Column<string>(maxLength: 32, nullable: false),
                    TaxaHierarchyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Usage = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivarIdentifier", x => new { x.DataSetId, x.CultivarId, x.TaxonomicCode, x.TaxonomicCodeVersion, x.TaxaHierarchyId });
                    table.ForeignKey(
                        name: "FK_CultivarIdentifier_Cultivars_CultivarId",
                        column: x => x.CultivarId,
                        principalTable: "Cultivars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CultivarIdentifier_TaxaHierarchies_TaxaHierarchyId",
                        column: x => x.TaxaHierarchyId,
                        principalTable: "TaxaHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxaHierarchyRank",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(nullable: false),
                    TaxonType = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ConnectingTermUsage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaHierarchyRank", x => new { x.HierarchyId, x.TaxonType });
                    table.ForeignKey(
                        name: "FK_TaxaHierarchyRank_TaxaHierarchies_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "TaxaHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxaHierarchyTaxonValue",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(nullable: false),
                    TaxonType = table.Column<string>(maxLength: 32, nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CultivarIdentifierCultivarId = table.Column<Guid>(nullable: true),
                    CultivarIdentifierDataSetId = table.Column<Guid>(nullable: true),
                    CultivarIdentifierTaxaHierarchyId = table.Column<int>(nullable: true),
                    CultivarIdentifierTaxonomicCode = table.Column<string>(nullable: true),
                    CultivarIdentifierTaxonomicCodeVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaHierarchyTaxonValue", x => new { x.HierarchyId, x.TaxonType });
                    table.ForeignKey(
                        name: "FK_TaxaHierarchyTaxonValue_TaxaHierarchies_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "TaxaHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxaHierarchyTaxonValue_CultivarIdentifier_CultivarIdentifierDataSetId_CultivarIdentifierCultivarId_CultivarIdentifierTaxonomicCode_CultivarIdentifierTaxonomicCodeVersion_CultivarIdentifierTaxaHierarchyId",
                        columns: x => new { x.CultivarIdentifierDataSetId, x.CultivarIdentifierCultivarId, x.CultivarIdentifierTaxonomicCode, x.CultivarIdentifierTaxonomicCodeVersion, x.CultivarIdentifierTaxaHierarchyId },
                        principalTable: "CultivarIdentifier",
                        principalColumns: new[] { "DataSetId", "CultivarId", "TaxonomicCode", "TaxonomicCodeVersion", "TaxaHierarchyId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CultivarIdentifier_CultivarId",
                table: "CultivarIdentifier",
                column: "CultivarId");

            migrationBuilder.CreateIndex(
                name: "IX_CultivarIdentifier_TaxaHierarchyId",
                table: "CultivarIdentifier",
                column: "TaxaHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_CultivarPopularName_CultivarId",
                table: "CultivarPopularName",
                column: "CultivarId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxaHierarchyTaxonValue_CultivarIdentifierDataSetId_CultivarIdentifierCultivarId_CultivarIdentifierTaxonomicCode_CultivarIdentifierTaxonomicCodeVersion_CultivarIdentifierTaxaHierarchyId",
                table: "TaxaHierarchyTaxonValue",
                columns: new[] { "CultivarIdentifierDataSetId", "CultivarIdentifierCultivarId", "CultivarIdentifierTaxonomicCode", "CultivarIdentifierTaxonomicCodeVersion", "CultivarIdentifierTaxaHierarchyId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CultivarPopularName");

            migrationBuilder.DropTable(
                name: "TaxaHierarchyRank");

            migrationBuilder.DropTable(
                name: "TaxaHierarchyTaxonValue");

            migrationBuilder.DropTable(
                name: "CultivarIdentifier");

            migrationBuilder.DropTable(
                name: "Cultivars");

            migrationBuilder.DropTable(
                name: "TaxaHierarchies");
        }
    }
}

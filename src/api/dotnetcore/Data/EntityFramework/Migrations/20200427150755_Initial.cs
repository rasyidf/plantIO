using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotanicFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotanicFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BotanicLifeCycle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotanicLifeCycle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomicCode",
                columns: table => new
                {
                    Identifier = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: false),
                    Philosophy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomicCode", x => new { x.Identifier, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "TaxonMethodology",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identifier = table.Column<string>(nullable: true),
                    TaxonomicCodeIdentifier = table.Column<string>(nullable: true),
                    TaxonomicCodeVersion = table.Column<string>(nullable: true),
                    Philosophy = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonMethodology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonMethodology_TaxonomicCode_TaxonomicCodeIdentifier_TaxonomicCodeVersion",
                        columns: x => new { x.TaxonomicCodeIdentifier, x.TaxonomicCodeVersion },
                        principalTable: "TaxonomicCode",
                        principalColumns: new[] { "Identifier", "Version" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxonMethodologyHierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TaxonomicCodeIdentifier = table.Column<string>(nullable: true),
                    TaxonomicCodeVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonMethodologyHierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonMethodologyHierarchy_TaxonMethodology_Id",
                        column: x => x.Id,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonMethodologyHierarchy_TaxonomicCode_TaxonomicCodeIdentifier_TaxonomicCodeVersion",
                        columns: x => new { x.TaxonomicCodeIdentifier, x.TaxonomicCodeVersion },
                        principalTable: "TaxonomicCode",
                        principalColumns: new[] { "Identifier", "Version" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxonType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LatinName = table.Column<string>(nullable: true),
                    MethodologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonType_TaxonMethodology_MethodologyId",
                        column: x => x.MethodologyId,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomicTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomicTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonomicTag_TaxonType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonTypeRank",
                columns: table => new
                {
                    TaxonTypeId = table.Column<int>(nullable: false),
                    HierarchyId = table.Column<int>(nullable: false),
                    Level = table.Column<byte>(nullable: false),
                    SubLevel = table.Column<sbyte>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ConnectingTermUsage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonTypeRank", x => x.TaxonTypeId);
                    table.ForeignKey(
                        name: "FK_TaxonTypeRank_TaxonMethodologyHierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "TaxonMethodologyHierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonTypeRank_TaxonType_TaxonTypeId",
                        column: x => x.TaxonTypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxon_Rank",
                columns: table => new
                {
                    GroupingTaxonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RankHierarchyId = table.Column<int>(nullable: false),
                    RankTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxon_Rank", x => x.GroupingTaxonId);
                    table.ForeignKey(
                        name: "FK_Taxon_Rank_TaxonMethodologyHierarchy_RankHierarchyId",
                        column: x => x.RankHierarchyId,
                        principalTable: "TaxonMethodologyHierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_Rank_TaxonTypeRank_RankTypeId",
                        column: x => x.RankTypeId,
                        principalTable: "TaxonTypeRank",
                        principalColumn: "TaxonTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxon_Grouping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxonId = table.Column<int>(nullable: false),
                    MethodologyId = table.Column<int>(nullable: false),
                    TaxonTypeId = table.Column<int>(nullable: false),
                    RankId = table.Column<int>(nullable: true),
                    TaxaPhilosophy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxon_Grouping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxon_Grouping_TaxonMethodology_MethodologyId",
                        column: x => x.MethodologyId,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_Grouping_Taxon_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Taxon_Rank",
                        principalColumn: "GroupingTaxonId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Taxon_Grouping_TaxonType_TaxonTypeId",
                        column: x => x.TaxonTypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identifier = table.Column<string>(nullable: true),
                    MethodologyId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    GroupingTaxonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxon_Taxon_Grouping_GroupingTaxonId",
                        column: x => x.GroupingTaxonId,
                        principalTable: "Taxon_Grouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taxon_TaxonMethodology_MethodologyId",
                        column: x => x.MethodologyId,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_TaxonType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesTaxonEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxonId = table.Column<int>(nullable: false),
                    BinomialName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesTaxonEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeciesTaxonEntity_Taxon_TaxonId",
                        column: x => x.TaxonId,
                        principalTable: "Taxon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxon_GroupingRelations",
                columns: table => new
                {
                    MethodologyId = table.Column<int>(nullable: false),
                    GroupingTaxonId = table.Column<int>(nullable: false),
                    TaxonTypeId = table.Column<int>(nullable: false),
                    TaxonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxon_GroupingRelations", x => new { x.MethodologyId, x.GroupingTaxonId, x.TaxonTypeId });
                    table.ForeignKey(
                        name: "FK_Taxon_GroupingRelations_Taxon_Grouping_GroupingTaxonId",
                        column: x => x.GroupingTaxonId,
                        principalTable: "Taxon_Grouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_GroupingRelations_TaxonMethodology_MethodologyId",
                        column: x => x.MethodologyId,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_GroupingRelations_Taxon_TaxonId",
                        column: x => x.TaxonId,
                        principalTable: "Taxon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxon_GroupingRelations_TaxonType_TaxonTypeId",
                        column: x => x.TaxonTypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonBotanicFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxonId = table.Column<int>(nullable: false),
                    BotanicFeatureId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonBotanicFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxonBotanicFeature_BotanicFeature_BotanicFeatureId",
                        column: x => x.BotanicFeatureId,
                        principalTable: "BotanicFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonBotanicFeature_Taxon_TaxonId",
                        column: x => x.TaxonId,
                        principalTable: "Taxon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonEntry",
                columns: table => new
                {
                    TargetTaxonId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonEntry", x => x.TargetTaxonId);
                    table.ForeignKey(
                        name: "FK_TaxonEntry_Taxon_TargetTaxonId",
                        column: x => x.TargetTaxonId,
                        principalTable: "Taxon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonEntry_TaxonType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomicTagValue",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    TaxonId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomicTagValue", x => new { x.TaxonId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TaxonomicTagValue_TaxonomicTag_TagId",
                        column: x => x.TagId,
                        principalTable: "TaxonomicTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxonomicTagValue_Taxon_TaxonId",
                        column: x => x.TaxonId,
                        principalTable: "Taxon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesTaxonGroupRelation",
                columns: table => new
                {
                    MethodologyId = table.Column<int>(nullable: false),
                    SpeciesId = table.Column<int>(nullable: false),
                    GroupingTaxonTypeId = table.Column<int>(nullable: false),
                    GroupingTaxonId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesTaxonGroupRelation", x => new { x.MethodologyId, x.GroupingTaxonTypeId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_SpeciesTaxonGroupRelation_Taxon_Grouping_GroupingTaxonId",
                        column: x => x.GroupingTaxonId,
                        principalTable: "Taxon_Grouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesTaxonGroupRelation_TaxonType_GroupingTaxonTypeId",
                        column: x => x.GroupingTaxonTypeId,
                        principalTable: "TaxonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesTaxonGroupRelation_TaxonMethodology_MethodologyId",
                        column: x => x.MethodologyId,
                        principalTable: "TaxonMethodology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeciesTaxonGroupRelation_SpeciesTaxonEntity_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "SpeciesTaxonEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotanicFeatureRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataSetId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true),
                    FeatureId = table.Column<int>(nullable: false),
                    Types = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotanicFeatureRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotanicFeatureRange_TaxonBotanicFeature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "TaxonBotanicFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotanicFeatureRange_FeatureId",
                table: "BotanicFeatureRange",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesTaxonEntity_TaxonId",
                table: "SpeciesTaxonEntity",
                column: "TaxonId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesTaxonGroupRelation_GroupingTaxonId",
                table: "SpeciesTaxonGroupRelation",
                column: "GroupingTaxonId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesTaxonGroupRelation_GroupingTaxonTypeId",
                table: "SpeciesTaxonGroupRelation",
                column: "GroupingTaxonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesTaxonGroupRelation_SpeciesId",
                table: "SpeciesTaxonGroupRelation",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_GroupingTaxonId",
                table: "Taxon",
                column: "GroupingTaxonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_MethodologyId",
                table: "Taxon",
                column: "MethodologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_TypeId",
                table: "Taxon",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_Grouping_RankId",
                table: "Taxon_Grouping",
                column: "RankId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_Grouping_TaxonTypeId",
                table: "Taxon_Grouping",
                column: "TaxonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_Grouping_MethodologyId_TaxonTypeId_TaxonId",
                table: "Taxon_Grouping",
                columns: new[] { "MethodologyId", "TaxonTypeId", "TaxonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_GroupingRelations_GroupingTaxonId",
                table: "Taxon_GroupingRelations",
                column: "GroupingTaxonId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_GroupingRelations_TaxonId",
                table: "Taxon_GroupingRelations",
                column: "TaxonId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_GroupingRelations_TaxonTypeId",
                table: "Taxon_GroupingRelations",
                column: "TaxonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_Rank_RankHierarchyId",
                table: "Taxon_Rank",
                column: "RankHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxon_Rank_RankTypeId",
                table: "Taxon_Rank",
                column: "RankTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonBotanicFeature_BotanicFeatureId",
                table: "TaxonBotanicFeature",
                column: "BotanicFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonBotanicFeature_TaxonId",
                table: "TaxonBotanicFeature",
                column: "TaxonId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonEntry_TypeId",
                table: "TaxonEntry",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonMethodology_TaxonomicCodeIdentifier_TaxonomicCodeVersion",
                table: "TaxonMethodology",
                columns: new[] { "TaxonomicCodeIdentifier", "TaxonomicCodeVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_TaxonMethodologyHierarchy_TaxonomicCodeIdentifier_TaxonomicCodeVersion",
                table: "TaxonMethodologyHierarchy",
                columns: new[] { "TaxonomicCodeIdentifier", "TaxonomicCodeVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomicTag_TypeId",
                table: "TaxonomicTag",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonomicTagValue_TagId",
                table: "TaxonomicTagValue",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonType_MethodologyId",
                table: "TaxonType",
                column: "MethodologyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxonTypeRank_HierarchyId",
                table: "TaxonTypeRank",
                column: "HierarchyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotanicFeatureRange");

            migrationBuilder.DropTable(
                name: "BotanicLifeCycle");

            migrationBuilder.DropTable(
                name: "SpeciesTaxonGroupRelation");

            migrationBuilder.DropTable(
                name: "Taxon_GroupingRelations");

            migrationBuilder.DropTable(
                name: "TaxonEntry");

            migrationBuilder.DropTable(
                name: "TaxonomicTagValue");

            migrationBuilder.DropTable(
                name: "TaxonBotanicFeature");

            migrationBuilder.DropTable(
                name: "SpeciesTaxonEntity");

            migrationBuilder.DropTable(
                name: "TaxonomicTag");

            migrationBuilder.DropTable(
                name: "BotanicFeature");

            migrationBuilder.DropTable(
                name: "Taxon");

            migrationBuilder.DropTable(
                name: "Taxon_Grouping");

            migrationBuilder.DropTable(
                name: "Taxon_Rank");

            migrationBuilder.DropTable(
                name: "TaxonTypeRank");

            migrationBuilder.DropTable(
                name: "TaxonMethodologyHierarchy");

            migrationBuilder.DropTable(
                name: "TaxonType");

            migrationBuilder.DropTable(
                name: "TaxonMethodology");

            migrationBuilder.DropTable(
                name: "TaxonomicCode");
        }
    }
}

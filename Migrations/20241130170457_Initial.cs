using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ccex_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChineseCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Char = table.Column<string>(type: "text", nullable: false),
                    BaseId = table.Column<int>(type: "integer", nullable: true),
                    Definition = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChineseCharacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChineseCharacter_ChineseCharacter_BaseId",
                        column: x => x.BaseId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pinyin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Syllable = table.Column<string>(type: "text", nullable: false),
                    ToneNumber = table.Column<int>(type: "integer", nullable: false),
                    SyllableWithToneMark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinyin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChineseCharacterChineseCharacter",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "integer", nullable: false),
                    DerivativesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChineseCharacterChineseCharacter", x => new { x.ComponentsId, x.DerivativesId });
                    table.ForeignKey(
                        name: "FK_ChineseCharacterChineseCharacter_ChineseCharacter_Component~",
                        column: x => x.ComponentsId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChineseCharacterChineseCharacter_ChineseCharacter_Derivativ~",
                        column: x => x.DerivativesId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChineseCharacterPinyin",
                columns: table => new
                {
                    CharsId = table.Column<int>(type: "integer", nullable: false),
                    PinyinsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChineseCharacterPinyin", x => new { x.CharsId, x.PinyinsId });
                    table.ForeignKey(
                        name: "FK_ChineseCharacterPinyin_ChineseCharacter_CharsId",
                        column: x => x.CharsId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChineseCharacterPinyin_Pinyin_PinyinsId",
                        column: x => x.PinyinsId,
                        principalTable: "Pinyin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacter_BaseId",
                table: "ChineseCharacter",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacterChineseCharacter_DerivativesId",
                table: "ChineseCharacterChineseCharacter",
                column: "DerivativesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacterPinyin_PinyinsId",
                table: "ChineseCharacterPinyin",
                column: "PinyinsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChineseCharacterChineseCharacter");

            migrationBuilder.DropTable(
                name: "ChineseCharacterPinyin");

            migrationBuilder.DropTable(
                name: "ChineseCharacter");

            migrationBuilder.DropTable(
                name: "Pinyin");
        }
    }
}

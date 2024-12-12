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
                    MainPinyinId = table.Column<int>(type: "integer", nullable: true),
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
                name: "TradCharacterStub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Char = table.Column<string>(type: "text", nullable: false),
                    SimpCharId = table.Column<int>(type: "integer", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradCharacterStub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradCharacterStub_ChineseCharacter_SimpCharId",
                        column: x => x.SimpCharId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pinyin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Syllable = table.Column<string>(type: "text", nullable: false),
                    ToneNumber = table.Column<int>(type: "integer", nullable: false),
                    SyllableWithToneMark = table.Column<string>(type: "text", nullable: false),
                    TradCharacterStubId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinyin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pinyin_TradCharacterStub_TradCharacterStubId",
                        column: x => x.TradCharacterStubId,
                        principalTable: "TradCharacterStub",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChineseCharacterPinyin",
                columns: table => new
                {
                    AllPinyinId = table.Column<int>(type: "integer", nullable: false),
                    CharsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChineseCharacterPinyin", x => new { x.AllPinyinId, x.CharsId });
                    table.ForeignKey(
                        name: "FK_ChineseCharacterPinyin_ChineseCharacter_CharsId",
                        column: x => x.CharsId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChineseCharacterPinyin_Pinyin_AllPinyinId",
                        column: x => x.AllPinyinId,
                        principalTable: "Pinyin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacter_BaseId",
                table: "ChineseCharacter",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacter_Char",
                table: "ChineseCharacter",
                column: "Char",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacter_MainPinyinId",
                table: "ChineseCharacter",
                column: "MainPinyinId");

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacterChineseCharacter_DerivativesId",
                table: "ChineseCharacterChineseCharacter",
                column: "DerivativesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChineseCharacterPinyin_CharsId",
                table: "ChineseCharacterPinyin",
                column: "CharsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pinyin_Syllable_ToneNumber",
                table: "Pinyin",
                columns: new[] { "Syllable", "ToneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pinyin_SyllableWithToneMark",
                table: "Pinyin",
                column: "SyllableWithToneMark",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pinyin_TradCharacterStubId",
                table: "Pinyin",
                column: "TradCharacterStubId");

            migrationBuilder.CreateIndex(
                name: "IX_TradCharacterStub_SimpCharId",
                table: "TradCharacterStub",
                column: "SimpCharId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChineseCharacter_Pinyin_MainPinyinId",
                table: "ChineseCharacter",
                column: "MainPinyinId",
                principalTable: "Pinyin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChineseCharacter_Pinyin_MainPinyinId",
                table: "ChineseCharacter");

            migrationBuilder.DropTable(
                name: "ChineseCharacterChineseCharacter");

            migrationBuilder.DropTable(
                name: "ChineseCharacterPinyin");

            migrationBuilder.DropTable(
                name: "Pinyin");

            migrationBuilder.DropTable(
                name: "TradCharacterStub");

            migrationBuilder.DropTable(
                name: "ChineseCharacter");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ccex_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Pinyin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Syllable = table.Column<string>(type: "text", nullable: false),
                    ToneNumber = table.Column<int>(type: "integer", nullable: false),
                    SyllableWithToneMark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinyin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChineseCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Char = table.Column<string>(type: "text", nullable: false),
                    BaseId = table.Column<int>(type: "integer", nullable: true),
                    PrimaryPinyin = table.Column<string[]>(type: "text[]", nullable: false),
                    SecondaryPinyin = table.Column<string[]>(type: "text[]", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    PinyinId = table.Column<int>(type: "integer", nullable: true),
                    Components = table.Column<string>(type: "jsonb", nullable: true),
                    Derivatives = table.Column<string>(type: "jsonb", nullable: true),
                    TradChars = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChineseCharacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChineseCharacter_ChineseCharacter_BaseId",
                        column: x => x.BaseId,
                        principalTable: "ChineseCharacter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChineseCharacter_Pinyin_PinyinId",
                        column: x => x.PinyinId,
                        principalTable: "Pinyin",
                        principalColumn: "Id");
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
                name: "IX_ChineseCharacter_PinyinId",
                table: "ChineseCharacter",
                column: "PinyinId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChineseCharacter");

            migrationBuilder.DropTable(
                name: "Pinyin");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");
        }
    }
}

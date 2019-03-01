using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class next_update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "048ebc26-7f07-492c-bb74-f77d39f3ee50");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "a794b338-4f1b-4ccc-84f3-a807f2927105");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "c79d6556-3d5e-4b50-b521-d2c61a5e7506");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "cbb3cb52-04f1-4178-94ad-65722b921c40");

            migrationBuilder.InsertData(
                table: "ForumUpdates",
                columns: new[] { "Id", "IsTheme", "Message", "Theme", "ThemeId", "UserId" },
                values: new object[,]
                {
                    { "519140a7-f1d8-4b49-bab6-b955ebcc13a0", true, "first message", "first theme", "53c27b34-1b1b-474f-82f4-449df8738eae", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "76817959-3005-431d-a497-4a8c9cbb56a0", false, "second message", null, "53c27b34-1b1b-474f-82f4-449df8738eae", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "7219c355-b86a-4764-8c05-95b7a6ba734e", false, "three message", null, "53c27b34-1b1b-474f-82f4-449df8738eae", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "8b59d5dc-5a9b-47c6-ad64-273fd305b76e", false, "four message", null, "53c27b34-1b1b-474f-82f4-449df8738eae", "de72ade2-d396-4aa6-aaad-68b08a813cfa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "519140a7-f1d8-4b49-bab6-b955ebcc13a0");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "7219c355-b86a-4764-8c05-95b7a6ba734e");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "76817959-3005-431d-a497-4a8c9cbb56a0");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "8b59d5dc-5a9b-47c6-ad64-273fd305b76e");

            migrationBuilder.InsertData(
                table: "ForumUpdates",
                columns: new[] { "Id", "IsTheme", "Message", "Theme", "ThemeId", "UserId" },
                values: new object[,]
                {
                    { "cbb3cb52-04f1-4178-94ad-65722b921c40", true, "first message", "first theme", "3c1f2120-95b8-4064-a8c4-817c837473ef", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "c79d6556-3d5e-4b50-b521-d2c61a5e7506", false, "second message", null, "3c1f2120-95b8-4064-a8c4-817c837473ef", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "048ebc26-7f07-492c-bb74-f77d39f3ee50", false, "three message", null, "3c1f2120-95b8-4064-a8c4-817c837473ef", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "a794b338-4f1b-4ccc-84f3-a807f2927105", false, "four message", null, "3c1f2120-95b8-4064-a8c4-817c837473ef", "de72ade2-d396-4aa6-aaad-68b08a813cfa" }
                });
        }
    }
}

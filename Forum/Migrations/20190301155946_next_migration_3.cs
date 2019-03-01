using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class next_migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "585cddac-3db3-42d8-8624-9dfafabe75dd", true, "first message", "first theme", "282bcdd5-e820-4f62-a41f-f54def51cf49", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "a893b66e-5fbb-4fd5-ad62-4ac9ab77ef80", false, "second message", "first theme", "282bcdd5-e820-4f62-a41f-f54def51cf49", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "26577132-53af-4d7c-937b-2e09787dca09", false, "three message", "first theme", "282bcdd5-e820-4f62-a41f-f54def51cf49", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "d39976cb-40db-42f5-999b-2e820294a17d", false, "four message", "first theme", "282bcdd5-e820-4f62-a41f-f54def51cf49", "de72ade2-d396-4aa6-aaad-68b08a813cfa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "26577132-53af-4d7c-937b-2e09787dca09");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "585cddac-3db3-42d8-8624-9dfafabe75dd");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "a893b66e-5fbb-4fd5-ad62-4ac9ab77ef80");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "d39976cb-40db-42f5-999b-2e820294a17d");

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
    }
}

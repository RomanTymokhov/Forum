using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class next_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "40b69feb-1951-42e7-8bad-7ab80c52872f");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "c9e27458-d68f-4a23-beb0-463e355f90d2");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "d16ff9d5-f01c-4008-a9d2-900748ae43ee");

            migrationBuilder.DeleteData(
                table: "ForumUpdates",
                keyColumn: "Id",
                keyValue: "dadcd5d1-e352-4866-9167-4da58ef53b4a");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "40b69feb-1951-42e7-8bad-7ab80c52872f", true, "first message", "first theme", "9bbe4fa3-bb91-4bc7-9056-af44867cfc57", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "d16ff9d5-f01c-4008-a9d2-900748ae43ee", false, "second message", null, "9bbe4fa3-bb91-4bc7-9056-af44867cfc57", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "c9e27458-d68f-4a23-beb0-463e355f90d2", false, "three message", null, "9bbe4fa3-bb91-4bc7-9056-af44867cfc57", "de72ade2-d396-4aa6-aaad-68b08a813cfa" },
                    { "dadcd5d1-e352-4866-9167-4da58ef53b4a", false, "four message", null, "9bbe4fa3-bb91-4bc7-9056-af44867cfc57", "de72ade2-d396-4aa6-aaad-68b08a813cfa" }
                });
        }
    }
}

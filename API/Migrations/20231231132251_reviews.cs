using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserReviews",
                columns: new[] { "Id", "Comment", "ProductId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "The Quantum X Smartphone is impressive, especially the quantum computing capabilities!", 1, 4, 7 },
                    { 2, "I love the Retro Flip Phone. It combines nostalgia with modern features!", 2, 5, 8 },
                    { 3, "The Stealth Ninja Laptop lives up to its name. It's fast and silent!", 4, 4, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$13$XPJGFCaShmfLHj6xDN.XNe3npUBs19yU0ZnJWhgqo64l7YABNFAQK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$13$8HNVqE0on.SHmreKI5JY.OpmMs24k43DX7ctdEfc.FImI2AKsPzV.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$13$YgW/JEuhyzScUdh.aAGN9.Vvo8PO9erFv370vRe8A.36OV/ylJgFO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$13$rbBYyR.yBwndWek5AOZYpeHy6dbRheZwlewzjV3xWuK5jGL867Vvi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$13$Bq7rJDaeqBInSz94/M98nOK6t.BNO0SaVLc..hZC55qP8cM4g2dS6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$13$xEXUeB0qKRkTnRrLb0L64eyPKcS7np/Lp6trt1v91EKoza.2O7Lwm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$13$3gZavVfJpmXqsCfGVYA1PuNdSbbyCK31BP2ecibOokx8bFisYhzbW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$13$OTe4HqpjkZgVgeUm9sWZ8.9XENgn35VECLvVfX5LgtU2Iy97bAuce");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$13$mmYMAqsxjDLLKUlSa5vaTO0V8N3jDcB8KolIY.k5tX2tt9RhleAgC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$13$aW7a76ZUfgKvWlWFMFgc6O3zSmQoWaos8atHqZAS.6PGa1cUPTNIK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$13$MWygmF4ezPAjY8eCJY/czemuK3KFMtWUE2mqbjxpku5nCp0DuwFKG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$13$2.NJLyhrXMu.O.WhY6hyHOuNCPlCxUsC45NIOaWNxnOMbjQDmwg4q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$13$m.fyECIusH2mwQHnxAy8iO/Wcgk07ygiIy04pJo47PP49SKyseCHm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$13$6E2uyvRBhcvUeg0p2FsBgOd4FhL2bkgRRkACZ2ZAhwdaG9SySu46a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$13$cOdzDTyuqpoqmgi3VYCOU.1GTAjf8DGIgt91HjxsELDY/gjnkyz6y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$13$YoEvq6K1N4d9BRluNESZLOsMZUkVbiE1jSODYcEYdJszFNPiTXviC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$13$RjlToMuhdzf83J/kT0U54.lbGVkH0WbDyeEKTnXsFbP/3QiGOgfUO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$13$sRcgF9LCpX6CoORf77SBE.cNLNsqqZpMuwX.mASjAe/RXRTyqH2/y");
        }
    }
}

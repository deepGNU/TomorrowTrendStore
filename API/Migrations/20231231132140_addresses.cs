using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "AddressLine", "City", "Country", "PostalCode", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Computing Street", "London", 826, "SW1A 1AA", 1 },
                    { 2, "456 Code Avenue", "Cambridge", 826, "CB2 1TN", 2 },
                    { 3, "789 Analytical Drive", "London", 826, "WC2B 6JR", 3 },
                    { 4, "321 Rue de Paris", "Paris", 250, "75001", 4 },
                    { 5, "123 Hauptstraße", "Berlin", 276, "10115", 5 },
                    { 6, "789 Tech Street", "New York", 840, "10001", 6 },
                    { 7, "456 Sydney Road", "Sydney", 36, "2000", 7 },
                    { 8, "987 Maple Lane", "Toronto", 124, "M5J 2N8", 8 },
                    { 9, "654 Britannia Street", "London", 826, "WC1X 9JP", 9 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$13$p6oaUYIdANIM0jvdUhZ5g.mRIfxPFPPclhTbMd2ndAG8KuLj6V/o6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$13$Bc1bz9TnTI0xyYQTeV/lueffaIL1g80qd88Ta4GcAzGPeatucMooS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$13$6SGewBwa9NGywmex0b6AK.QvMa8fZ8.AGcbn2b8lSPyVaJ3N7CUJi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$13$9A4703xhTP6oUsEZdjKiZObMXQ.9JprRL9Nk5Le4EmHP/HGRs/S8S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$13$//LK6og3l8hCLFsK1lzvpucAF6kKsAgJZkJ4nLODe9dPgcqUVwyoe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$13$AFvumBoPbuMAOcYZcq32T.bJaaGRHTyjsTzLp5sdA/8uhddW5kJ8m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$13$uEp3CvPiTVgN3pVYu08UMuxhINIGjsyb4X0TKCZPDgvuMIfemb2lK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$13$zMj46gKuDVYpLLexNKlydu5M.FUCAtjJlF5pEYTOxQ5UiWJm9dZBq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$13$5oQ5gHZu1OBAbSBmS.oOTeFtKXMwQttyLWjjNQVZeY/jzXWiVxC8O");
        }
    }
}

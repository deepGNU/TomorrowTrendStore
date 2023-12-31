using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "ProfileImageURL", "Type", "Username" },
                values: new object[,]
                {
                    { 1, "ada@example.com", "Ada", "Lovelace", "$2a$13$p6oaUYIdANIM0jvdUhZ5g.mRIfxPFPPclhTbMd2ndAG8KuLj6V/o6", "888888888", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvUBANt6N-ada-lovelace-coding.png", 999, "AdaCoder" },
                    { 2, "alan@example.com", "Alan", "Turing", "$2a$13$Bc1bz9TnTI0xyYQTeV/lueffaIL1g80qd88Ta4GcAzGPeatucMooS", "999999999", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvU3Sp34D-alan-turing-doing-math.png", 999, "AnalyticalAlan" },
                    { 3, "charles@example.com", "Charles", "Babbage", "$2a$13$6SGewBwa9NGywmex0b6AK.QvMa8fZ8.AGcbn2b8lSPyVaJ3N7CUJi", "777777777", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTzyWF9X-charles-babbage%20building-analytical-engine.png", 999, "BabbageEngineer" },
                    { 4, "worker1@example.com", "Worker1", "LastName1", "$2a$13$9A4703xhTP6oUsEZdjKiZObMXQ.9JprRL9Nk5Le4EmHP/HGRs/S8S", "98765431", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTy4qQ8x-865056_electronic%20store%20worker%20_xl-1024-v1-0.png", 1, "worker1" },
                    { 5, "worker2@example.com", "Worker2", "LastName2", "$2a$13$//LK6og3l8hCLFsK1lzvpucAF6kKsAgJZkJ4nLODe9dPgcqUVwyoe", "98765432", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTy4qQ8x-865056_electronic%20store%20worker%20_xl-1024-v1-0.png", 1, "worker2" },
                    { 6, "worker3@example.com", "Worker3", "LastName3", "$2a$13$AFvumBoPbuMAOcYZcq32T.bJaaGRHTyjsTzLp5sdA/8uhddW5kJ8m", "98765433", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTy4qQ8x-865056_electronic%20store%20worker%20_xl-1024-v1-0.png", 1, "worker3" },
                    { 7, "customer1@example.com", "Customer1", "LastName1", "$2a$13$uEp3CvPiTVgN3pVYu08UMuxhINIGjsyb4X0TKCZPDgvuMIfemb2lK", "12345671", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTtNgM2b-773905_guy%20with%20sunglasses%20_xl-1024-v1-0.png", 0, "customer1" },
                    { 8, "customer2@example.com", "Customer2", "LastName2", "$2a$13$zMj46gKuDVYpLLexNKlydu5M.FUCAtjJlF5pEYTOxQ5UiWJm9dZBq", "12345672", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTtNgM2b-773905_guy%20with%20sunglasses%20_xl-1024-v1-0.png", 0, "customer2" },
                    { 9, "customer3@example.com", "Customer3", "LastName3", "$2a$13$5oQ5gHZu1OBAbSBmS.oOTeFtKXMwQttyLWjjNQVZeY/jzXWiVxC8O", "12345673", "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTtNgM2b-773905_guy%20with%20sunglasses%20_xl-1024-v1-0.png", 0, "customer3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

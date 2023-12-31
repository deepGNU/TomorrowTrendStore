using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShopOrders",
                columns: new[] { "Id", "OrderDate", "Status", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5181), "Delivered", 799.99m, 7 },
                    { 2, new DateTime(2023, 12, 12, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5306), "Delivered", 299.99m, 8 },
                    { 3, new DateTime(2023, 12, 21, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5311), "Delivered", 1999.99m, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$13$ymTlzWaScHKmTAk5IDPNKumnTglmOIi7vJUNhf/vpP/6Gp3tWRf6S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$13$/0YwBXyX35QHUm4tP.7hW.Lli.N/R1XFsZybVLmqqmAY0EjmpLnLO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$13$jjw.8hqysioNWfGZegmbz.ZMz6GcwDUYSnod1H9sSc/mDg36l9aQu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$13$FziTzqz06qVZ9NEZDu8Jkuryn4nlrTG8y5AUabI8IMonMpCRnA/Mq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$13$v7kdMGmyquOaTLDEOJJ8fOSq5USCM2OU0fNA/GNHuzLi0AY7idJvC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$13$tvrw7cM.FcVmLC6hYfqlue1qAzBJu1V9B7ltmc3wbsgekI3Hbm3Au");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$13$ocYeOxt6YqArURBbKR12/uuN3KXok3WaPMO3HIz0NygUi8oOYNAQK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$13$6cKP25M0fAuwHIVvVjnQ4OYf6mgfCfdE.3Rl/zWo.hXC9xJP2jMF.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$13$1URKnaPKpGrW6NFaG7iUAuCilh6Hi36vwdAVbHlcZAuHQ7FA8kt.q");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class order_lines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "Price", "ProductId", "Quantity", "ShopOrderId" },
                values: new object[,]
                {
                    { 1, 799.99m, 1, 1, 1 },
                    { 2, 299.99m, 2, 1, 2 },
                    { 3, 1999.99m, 4, 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 15, 25, 10, 144, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 27, 15, 25, 10, 144, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 12, 23, 15, 25, 10, 144, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$13$yf3nULHWW5Leg9sJCr6BXu17SgKdUgtHMWvV426WhMS23iWge1Hdu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$13$9I4XKZL6DiaEUCnhRk16Keol1ETlIcbe/3u2g3dast/li9bPLzyE6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$13$.r4gdDC9ENrmXGP.uky.JeliWl5emestKMtz5FHJWZnVYCzEkWI1O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$13$MZ4m/PoCvvXpwpTYhxRwHuScaxrCkwJkPFSFq7VDbUv770vcg5cUy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$13$HAh8WgT1eBSFTzWIScU6YOfiEO8LLY7CEe8ykbHdRrRgEuSXIlg5y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$13$dIkY0mjDMVV6q447lENLL.YckgIQTz3wQ8nUgnKL8kWBkw1NdRrB6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$13$Oatl32PBjBf/ww4JaVuPauq9po20oW.mw41TGj65BCAFKe9BO5h2a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$13$EvJm1ND89fwESE4R.j7gWeMwwyqyEyvMyLfNgMV6vKrRpWAAgvT5q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$13$N2btepB/oEeptvbCrjSx8uuKGzPQ28Hm1mr3IcNQdd6IfduFUC68y");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 13, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "ShopOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 12, 21, 15, 24, 5, 219, DateTimeKind.Local).AddTicks(5311));

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
    }
}

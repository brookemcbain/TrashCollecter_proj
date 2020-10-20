using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollecter.Data.Migrations
{
    public partial class globalrouting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84dc161f-6956-4263-9c50-e9cf8827a375");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ac86ec1-e9dc-404b-887a-0586128efa8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10bc8034-cbb6-443c-a0fc-346ec8d4efd3", "40c9223f-ef0f-4408-9742-97ad64926aae", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22901080-996d-40d7-9621-511af26b4b3f", "7425f2e8-a25c-4178-a4bd-ff57c7df0974", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10bc8034-cbb6-443c-a0fc-346ec8d4efd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22901080-996d-40d7-9621-511af26b4b3f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ac86ec1-e9dc-404b-887a-0586128efa8c", "b488dd85-97f5-4e27-b299-ac1e7193f96e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84dc161f-6956-4263-9c50-e9cf8827a375", "cd2f6a76-66fb-4901-ada3-eabac0fe7d6f", "Employee", "EMPLOYEE" });
        }
    }
}

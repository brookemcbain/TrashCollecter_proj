using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollecter.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0656bbd1-cc6c-47a6-b2cf-61cbb94def10", "fc65c885-6ba8-485b-9dbc-7be67b615379", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0656bbd1-cc6c-47a6-b2cf-61cbb94def10");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollecter.Migrations
{
    public partial class employeecontrollerfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d76e0b1f-626f-40aa-bb13-fe6d1e178c39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f769cd9a-23cf-4cb8-82f4-37da89a3ee00");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employees",
                newName: "IX_Employees_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7327dd04-6d26-458f-a2e4-176901abcf0b", "e277312a-f234-45c4-9c07-e025d697d18b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d28f41b-d6c7-4e65-96cd-2738cbe2f163", "9f8e7046-a8de-436e-8d8c-12dd3f24af4d", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d28f41b-d6c7-4e65-96cd-2738cbe2f163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7327dd04-6d26-458f-a2e4-176901abcf0b");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_IdentityUserId",
                table: "Employee",
                newName: "IX_Employee_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d76e0b1f-626f-40aa-bb13-fe6d1e178c39", "28e8f595-52ce-4988-835c-da998618a4b8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f769cd9a-23cf-4cb8-82f4-37da89a3ee00", "3d5127bd-c851-403d-973e-c106d5925469", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

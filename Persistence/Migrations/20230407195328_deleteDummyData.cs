using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarsModels",
                keyColumn: "Id",
                keyValue: 16);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarsModels",
                columns: new[] { "Id", "BrandName", "Created", "IsDeleted", "ModelName", "Modified" },
                values: new object[,]
                {
                    { 1, "AUDI", null, false, "A1", null },
                    { 2, "AUDI", null, false, "A3", null },
                    { 3, "AUDI", null, false, "A4", null },
                    { 4, "AUDI", null, false, "A5", null },
                    { 5, "AUDI", null, false, "A6", null },
                    { 6, "AUDI", null, false, "A7", null },
                    { 7, "AUDI", null, false, "A8", null },
                    { 8, "AUDI", null, false, "E-TRON", null },
                    { 9, "AUDI", null, false, "Q2", null },
                    { 10, "AUDI", null, false, "Q3", null },
                    { 11, "AUDI", null, false, "Q4", null },
                    { 12, "AUDI", null, false, "Q5", null },
                    { 13, "AUDI", null, false, "Q7", null },
                    { 14, "AUDI", null, false, "Q8", null },
                    { 15, "AUDI", null, false, "TT", null },
                    { 16, "AUDI", null, false, "R8", null }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DummyCarModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarsModels",
                columns: new[] { "Id", "BrandName", "Created", "ModelName", "Modified" },
                values: new object[,]
                {
                    { 1, "AUDI", null, "A1", null },
                    { 2, "AUDI", null, "A3", null },
                    { 3, "AUDI", null, "A4", null },
                    { 4, "AUDI", null, "A5", null },
                    { 5, "AUDI", null, "A6", null },
                    { 6, "AUDI", null, "A7", null },
                    { 7, "AUDI", null, "A8", null },
                    { 8, "AUDI", null, "E-TRON", null },
                    { 9, "AUDI", null, "Q2", null },
                    { 10, "AUDI", null, "Q3", null },
                    { 11, "AUDI", null, "Q4", null },
                    { 12, "AUDI", null, "Q5", null },
                    { 13, "AUDI", null, "Q7", null },
                    { 14, "AUDI", null, "Q8", null },
                    { 15, "AUDI", null, "TT", null },
                    { 16, "AUDI", null, "R8", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

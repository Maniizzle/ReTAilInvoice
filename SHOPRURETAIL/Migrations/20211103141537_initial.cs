using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOPRURETAIL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 55, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    IsPercentage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    CustomerTypeId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Customer" });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Affiliate" });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3L, "Employee" });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsPercentage", "Name", "Value" },
                values: new object[] { 1L, true, "Affiliate", 10m });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsPercentage", "Name", "Value" },
                values: new object[] { 2L, true, "Employee", 30m });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsPercentage", "Name", "Value" },
                values: new object[] { 3L, true, "Customer", 5m });

            migrationBuilder.InsertData(
                table: "DiscountType",
                columns: new[] { "Id", "IsPercentage", "Name", "Value" },
                values: new object[] { 4L, false, "100DollarBill", 5m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 1L, "Groceries", "OLoyin Beans", "Beans", 500m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 2L, "Electronics", "Beats by Dre Headset", "HeadSet", 5000m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 3L, "Groceries", "Power Oil", " Oil", 1500m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 4L, "Groceries", "Poundo Yam", "Poundo Yam", 7800m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 5L, "1 Crate of Raw Egg", "Poundo Yam", "Egg", 5600m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Description", "Name", "UnitPrice" },
                values: new object[] { 6L, "Electronics", "Binatone Standing Fan", "Binatone Fan", 9000m });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerTypeId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 1L, null, 1L, "Ebube@email.com", "Chukwu", "Ebube", "Ngozi", "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerTypeId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 2L, null, 1L, "Otee@email.com", "David", "Otee", "James", "12345678910" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerTypeId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 3L, null, 2L, "Nike@email.com", "Puma", "Nike", "Lanre", "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerTypeId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 4L, null, 2L, "boseayo@email.com", "Bose", "Ayo", null, "123456789" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CustomerTypeId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 5L, null, 3L, "bolajoko@email.com", "Bola", "Joko", null, "123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_Name",
                table: "CustomerType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountType_Name",
                table: "DiscountType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}

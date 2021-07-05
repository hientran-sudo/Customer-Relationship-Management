using Microsoft.EntityFrameworkCore.Migrations;

namespace HMT.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PDivs",
                columns: table => new
                {
                    PDivID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDivs", x => x.PDivID);
                });

            migrationBuilder.CreateTable(
                name: "PStores",
                columns: table => new
                {
                    PStoreID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PStores", x => x.PStoreID);
                });

            migrationBuilder.CreateTable(
                name: "PItems",
                columns: table => new
                {
                    PItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PStoreID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PDivID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PItems", x => x.PItemID);
                    table.ForeignKey(
                        name: "FK_PItems_PDivs_PDivID",
                        column: x => x.PDivID,
                        principalTable: "PDivs",
                        principalColumn: "PDivID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PItems_PStores_PStoreID",
                        column: x => x.PStoreID,
                        principalTable: "PStores",
                        principalColumn: "PStoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PDivs",
                columns: new[] { "PDivID", "Name" },
                values: new object[,]
                {
                    { "B", "Bag" },
                    { "S", "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "PStores",
                columns: new[] { "PStoreID", "Name" },
                values: new object[,]
                {
                    { "SO", "Store One" },
                    { "ST", "Store Two" }
                });

            migrationBuilder.InsertData(
                table: "PItems",
                columns: new[] { "PItemID", "Image", "PDivID", "PStoreID" },
                values: new object[,]
                {
                    { "1", "", "B", "SO" },
                    { "2", "", "S", "SO" },
                    { "3", "", "B", "ST" },
                    { "4", "", "S", "ST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PItems_PDivID",
                table: "PItems",
                column: "PDivID");

            migrationBuilder.CreateIndex(
                name: "IX_PItems_PStoreID",
                table: "PItems",
                column: "PStoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PItems");

            migrationBuilder.DropTable(
                name: "PDivs");

            migrationBuilder.DropTable(
                name: "PStores");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

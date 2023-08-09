using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbTablesToEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Bathrooms_BathroomsId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Categories_CategoryId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_FloorsNumbers_FloorsNumberId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Floors_FloorId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Rooms_RoomsNumberId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Statuses_StatusId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Types_TypeId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "Bathrooms");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "FloorsNumbers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Homes_BathroomsId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_CategoryId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_FloorId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_FloorsNumberId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_RoomsNumberId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_StatusId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_TypeId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "BathroomsId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Furniture",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Homes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Homes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RoomsNumberId",
                table: "Homes",
                newName: "RoomsQuantity");

            migrationBuilder.RenameColumn(
                name: "FloorsNumberId",
                table: "Homes",
                newName: "FloorsQuantity");

            migrationBuilder.RenameColumn(
                name: "FloorId",
                table: "Homes",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "BathroomsQuantity",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasFurniture",
                table: "Homes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BathroomsQuantity",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "HasFurniture",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Homes",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Homes",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "RoomsQuantity",
                table: "Homes",
                newName: "RoomsNumberId");

            migrationBuilder.RenameColumn(
                name: "FloorsQuantity",
                table: "Homes",
                newName: "FloorsNumberId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Homes",
                newName: "FloorId");

            migrationBuilder.AddColumn<int>(
                name: "BathroomsId",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Furniture",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bathrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BathroomsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bathrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorsNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorsNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_BathroomsId",
                table: "Homes",
                column: "BathroomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_CategoryId",
                table: "Homes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_FloorId",
                table: "Homes",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_FloorsNumberId",
                table: "Homes",
                column: "FloorsNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_RoomsNumberId",
                table: "Homes",
                column: "RoomsNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_StatusId",
                table: "Homes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_TypeId",
                table: "Homes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Bathrooms_BathroomsId",
                table: "Homes",
                column: "BathroomsId",
                principalTable: "Bathrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Categories_CategoryId",
                table: "Homes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_FloorsNumbers_FloorsNumberId",
                table: "Homes",
                column: "FloorsNumberId",
                principalTable: "FloorsNumbers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Floors_FloorId",
                table: "Homes",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Rooms_RoomsNumberId",
                table: "Homes",
                column: "RoomsNumberId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Statuses_StatusId",
                table: "Homes",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Types_TypeId",
                table: "Homes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

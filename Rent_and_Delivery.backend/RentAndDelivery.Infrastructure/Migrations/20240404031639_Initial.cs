using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentAndDelivery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Plate = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                    table.UniqueConstraint("UniqueKey_Plate", x => x.Plate);
                });

            migrationBuilder.CreateTable(
                name: "RentalPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlanDays = table.Column<int>(type: "integer", nullable: false),
                    CostPerDay = table.Column<float>(type: "real", nullable: false),
                    FineInPercentage = table.Column<float>(type: "real", nullable: false),
                    AdditionalValuePerDay = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LicenseNumberCNH = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LicenseType = table.Column<int>(type: "integer", nullable: false),
                    ImageCNH = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RaceValue = table.Column<float>(type: "real", nullable: false),
                    OrderStatusStatus = table.Column<int>(type: "integer", nullable: false),
                    DeliveryPersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    AcceptedOrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveredOrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryPersons_DeliveryPersonId",
                        column: x => x.DeliveryPersonId,
                        principalTable: "DeliveryPersons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehiclesRentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 100, nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 100, nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 100, nullable: false),
                    TotalAmount = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    DeliveryPersonId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesRentals_DeliveryPersons_DeliveryPersonId",
                        column: x => x.DeliveryPersonId,
                        principalTable: "DeliveryPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclesRentals_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotifications_DeliveryPersons_DeliveryPersonId",
                        column: x => x.DeliveryPersonId,
                        principalTable: "DeliveryPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderNotifications_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { new Guid("4faa9cab-f205-40cb-5953-08dc489cfb2d"), new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(2230), "Admin" });

            migrationBuilder.InsertData(
                table: "DeliveryPersons",
                columns: new[] { "Id", "BirthDate", "CNPJ", "CreatedOn", "ImageCNH", "LicenseNumberCNH", "LicenseType", "Name", "OrderId" },
                values: new object[] { new Guid("15ef9e35-e3af-4a70-826d-88edba8efcc0"), new DateTime(2004, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(3454), "74979006000199", new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(3463), "./images/imageCNH.jpg", "30222894101", 1, "John Doe Test", null });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "CreatedOn", "Model", "Plate", "Status", "Year" },
                values: new object[] { new Guid("6c31f522-56b1-4bc2-a8c9-585627c23318"), new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(4779), "Factor 125", "OFL0823", 1, 2023 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AcceptedOrderDate", "CreatedOn", "DeliveredOrderDate", "DeliveryPersonId", "OrderStatusStatus", "RaceValue" },
                values: new object[] { new Guid("814270d0-e6f8-4b95-b1c8-c74ba38e0381"), null, new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(5671), null, null, 1, 50f });

            migrationBuilder.InsertData(
                table: "RentalPlans",
                columns: new[] { "Id", "AdditionalValuePerDay", "CostPerDay", "CreatedOn", "FineInPercentage", "PlanDays", "PlanName" },
                values: new object[,]
                {
                    { new Guid("3531a2ac-015f-4b7e-95b6-8f6e54a040bb"), 50f, 30f, new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7848), 20f, 7, "7_Days" },
                    { new Guid("54b78006-d2c0-4041-ad81-5e88b84142c0"), 50f, 28f, new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7865), 40f, 15, "15_Days" },
                    { new Guid("5b17845c-d0a7-4a84-b380-a0ac18382b5a"), 50f, 22f, new DateTime(2024, 4, 4, 0, 16, 38, 779, DateTimeKind.Utc).AddTicks(7869), 60f, 30, "30_Days" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPersons_OrderId",
                table: "DeliveryPersons",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotifications_DeliveryPersonId",
                table: "OrderNotifications",
                column: "DeliveryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotifications_OrderId",
                table: "OrderNotifications",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryPersonId",
                table: "Orders",
                column: "DeliveryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesRentals_DeliveryPersonId",
                table: "VehiclesRentals",
                column: "DeliveryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesRentals_MotorcycleId",
                table: "VehiclesRentals",
                column: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryPersons_Orders_OrderId",
                table: "DeliveryPersons",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryPersons_Orders_OrderId",
                table: "DeliveryPersons");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "OrderNotifications");

            migrationBuilder.DropTable(
                name: "RentalPlans");

            migrationBuilder.DropTable(
                name: "VehiclesRentals");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryPersons");
        }
    }
}

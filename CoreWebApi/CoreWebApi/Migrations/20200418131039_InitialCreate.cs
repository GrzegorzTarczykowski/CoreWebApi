using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientIdCode = table.Column<string>(nullable: true),
                    ClientSecret = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    RefreshTokenLifeTime = table.Column<int>(nullable: false),
                    AllowedOrigin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissiondId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Permission", x => x.PermissiondId);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    RefreshTokenId = table.Column<string>(maxLength: 128, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    IssuedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProtectedTicket = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.RefreshTokenId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExecutionTimeInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Timetable",
                columns: table => new
                {
                    TimetableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfEmployeesForCustomer = table.Column<int>(nullable: false),
                    NumberOfEmployeesReservedForCustomer = table.Column<int>(nullable: false),
                    NumberOfEmployeesForManager = table.Column<int>(nullable: false),
                    NumberOfEmployeesReservedForManager = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetable", x => x.TimetableId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrand",
                columns: table => new
                {
                    VehicleBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrand", x => x.VehicleBrandId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColour",
                columns: table => new
                {
                    VehicleColourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColour", x => x.VehicleColourId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEngine",
                columns: table => new
                {
                    VehicleEngineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerKW = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CapacityCCM = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EngineCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEngine", x => x.VehicleEngineId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFuel",
                columns: table => new
                {
                    VehicleFuelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFuel", x => x.VehicleFuelId);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePart",
                columns: table => new
                {
                    VehiclePartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePart", x => x.VehiclePartId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.User_dbo.Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissiondId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VehicleBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_dbo.VehicleModel_dbo.VehicleBrand_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrand",
                        principalColumn: "VehicleBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTimetable",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TimetableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.UserTimetable", x => new { x.UserId, x.TimetableId });
                    table.ForeignKey(
                        name: "FK_dbo.UserTimetable_dbo.Timetable_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetable",
                        principalColumn: "TimetableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.UserTimetable_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineMileage = table.Column<int>(nullable: false),
                    RegistrationNumbers = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    VehicleEngineId = table.Column<int>(nullable: false),
                    VehicleFuelId = table.Column<int>(nullable: false),
                    VehicleModelId = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_dbo.Vehicle_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Vehicle_dbo.VehicleEngine_VehicleEngineId",
                        column: x => x.VehicleEngineId,
                        principalTable: "VehicleEngine",
                        principalColumn: "VehicleEngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Vehicle_dbo.VehicleFuel_VehicleFuelId",
                        column: x => x.VehicleFuelId,
                        principalTable: "VehicleFuel",
                        principalColumn: "VehicleFuelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Vehicle_dbo.VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Vehicle_dbo.VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartDateOfRepair = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDateOfRepair = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderStatusId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_dbo.Order_dbo.OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Order_dbo.Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    UserSenderId = table.Column<int>(nullable: false),
                    UserReceiverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_dbo.Message_dbo.Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Message_dbo.User_UserReceiverId",
                        column: x => x.UserReceiverId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Message_dbo.User_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.OrderService", x => new { x.OrderId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_dbo.OrderService_dbo.Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderService_dbo.Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderVehiclePart",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    VehiclePartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.OrderVehiclePart", x => new { x.OrderId, x.VehiclePartId });
                    table.ForeignKey(
                        name: "FK_dbo.OrderVehiclePart_dbo.Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderVehiclePart_dbo.VehiclePart_VehiclePartId",
                        column: x => x.VehiclePartId,
                        principalTable: "VehiclePart",
                        principalColumn: "VehiclePartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrder",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.UserOrder", x => new { x.UserId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_dbo.UserOrder_dbo.Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.UserOrder_dbo.User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderId",
                table: "Message",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReceiverId",
                table: "Message",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSenderId",
                table: "Message",
                column: "UserSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleId",
                table: "Order",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderId",
                table: "OrderService",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceId",
                table: "OrderService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderId",
                table: "OrderVehiclePart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartId",
                table: "OrderVehiclePart",
                column: "VehiclePartId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionId",
                table: "User",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderId",
                table: "UserOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "UserOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimetableId",
                table: "UserTimetable",
                column: "TimetableId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "UserTimetable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "Vehicle",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEngineId",
                table: "Vehicle",
                column: "VehicleEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFuelId",
                table: "Vehicle",
                column: "VehicleFuelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrandId",
                table: "VehicleModel",
                column: "VehicleBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "OrderVehiclePart");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserOrder");

            migrationBuilder.DropTable(
                name: "UserTimetable");

            migrationBuilder.DropTable(
                name: "VehicleColour");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "VehiclePart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Timetable");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VehicleEngine");

            migrationBuilder.DropTable(
                name: "VehicleFuel");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "VehicleBrand");
        }
    }
}

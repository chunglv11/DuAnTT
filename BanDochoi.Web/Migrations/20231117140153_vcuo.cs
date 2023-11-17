using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanDochoi.Web.Migrations
{
    public partial class vcuo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomeAdress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vote = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9078), "Bé", null, null, "Đồ chơi cho trẻ sơ sinh", null },
                    { 2, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9097), "Bé", null, null, "Đồ chơi thông minh", null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1, "TP Hà Nội" },
                    { 2, "TP Hồ Chí Minh" },
                    { 3, "An Giang" },
                    { 4, "Bà Rịa – Vũng Tàu" },
                    { 5, "Bắc Giang" },
                    { 6, "Bắc Kạn" },
                    { 7, "Bạc Liêu" },
                    { 8, "Bắc Ninh" },
                    { 9, "Bến Tre" },
                    { 10, "Bình Định" },
                    { 11, "Bình Dương" },
                    { 12, "Bình Phước" },
                    { 13, "Bình Thuận" },
                    { 14, "Cà Mau" },
                    { 15, "TP Cần Thơ" },
                    { 16, "Cao Bằng" },
                    { 17, "TP Đà Nẵng" },
                    { 18, "Đắk Lắk" },
                    { 19, "Đắk Nông" },
                    { 20, "Điện Biên" },
                    { 21, "Đồng Nai" },
                    { 22, "Đồng Tháp" },
                    { 23, "Gia Lai" },
                    { 24, "Hà Giang" },
                    { 25, "Hà Nam" },
                    { 26, "Hà Tĩnh" },
                    { 27, "Hải Dương" },
                    { 28, "TP Hải Phòng" },
                    { 29, "Hậu Giang" },
                    { 30, "Hòa Bình" },
                    { 31, "Hưng Yên" },
                    { 32, "Khánh Hòa" },
                    { 33, "Kiên Giang" },
                    { 34, "Kon Tum" },
                    { 35, "Lai Châu" },
                    { 36, "Lâm Đồng" },
                    { 37, "Lạng Sơn" },
                    { 38, "Lào Cai" },
                    { 39, "Long An" },
                    { 40, "Nam Định" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 41, "Nghệ An" },
                    { 42, "Ninh Bình" },
                    { 43, "Ninh Thuận" },
                    { 44, "Phú Thọ" },
                    { 45, "Phú Yên" },
                    { 46, "Quảng Bình" },
                    { 47, "Quảng Nam" },
                    { 48, "Quảng Ngãi" },
                    { 49, "Quảng Ninh" },
                    { 50, "Quảng Trị" },
                    { 51, "Sóc Trăng" },
                    { 52, "Sơn La" },
                    { 53, "Tây Ninh" },
                    { 54, "Thái Bình" },
                    { 55, "Thái Nguyên" },
                    { 56, "Thanh Hóa" },
                    { 57, "Thừa Thiên Huế" },
                    { 58, "Tiền Giang" },
                    { 59, "Trà Vinh" },
                    { 60, "Tuyên Quang" },
                    { 61, "Vĩnh Long" },
                    { 62, "Vĩnh Phúc" },
                    { 63, "Yên Bái" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9098), "Bé", null, null, "Đồ chơi xếp hình - lắp ráp", 1 },
                    { 4, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9100), "Bé", null, null, "Đồ chơi mô hình - điều khiển", 1 }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Quận Ba Đình" },
                    { 2, 1, "Quận Hoàn Kiếm" },
                    { 3, 1, "Quận Tây Hồ" },
                    { 4, 1, "Quận Long Biên" },
                    { 5, 1, "Quận Cầu Giấy" },
                    { 6, 1, "Quận Đống Đa" },
                    { 7, 1, "Quận Hai Bà Trưng" },
                    { 8, 1, "Quận Hoàng Mai" },
                    { 9, 1, "Quận Thanh Xuân" },
                    { 10, 1, "Quận Bắc Từ Liêm" },
                    { 11, 1, "Quận Nam Từ Liêm" },
                    { 12, 1, "Quận Hà Đông" },
                    { 13, 1, "Huyện Sóc Sơn" },
                    { 14, 1, "Huyện Đông Anh" },
                    { 15, 1, "Huyện Gia Lâm" },
                    { 16, 1, "Huyện Thanh Trì" },
                    { 17, 1, "Huyện Mê Linh" },
                    { 18, 1, "Thị xã Sơn Tây" },
                    { 19, 1, "Huyện Ba Vì" },
                    { 20, 1, "Huyện Phúc Thọ" },
                    { 21, 1, "Huyện Đan Phượng" },
                    { 22, 1, "Huyện Hoài Đức" },
                    { 23, 1, "Huyện Quốc Oai" },
                    { 24, 1, "Huyện Thạch Thất" },
                    { 25, 1, "Huyện Chương Mỹ" },
                    { 26, 1, "Huyện Thanh Oai" },
                    { 27, 1, "Huyện Thường Tín" },
                    { 28, 1, "Huyện Phú Xuyên" },
                    { 29, 1, "Huyện Mỹ Đức" },
                    { 30, 1, "Huyện Ứng Hòa" },
                    { 31, 2, "Quận 1" },
                    { 32, 2, "Quận 2" },
                    { 33, 2, "Quận 3" },
                    { 34, 2, "Quận 4" },
                    { 35, 2, "Quận 5" },
                    { 36, 2, "Quận 6" },
                    { 37, 2, "Quận 7" },
                    { 38, 2, "Quận 8" },
                    { 39, 2, "Quận 9" },
                    { 40, 2, "Quận 10" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 41, 2, "Quận 11" },
                    { 42, 2, "Quận 12" },
                    { 43, 2, "Quận Thủ Đức" },
                    { 44, 2, "Quận Gò Vấp" },
                    { 45, 2, "Quận Bình Thạnh" },
                    { 46, 2, "Quận Tân Bình" },
                    { 47, 2, "Quận Tân Phú" },
                    { 48, 2, "Quận Phú Nhuận" },
                    { 49, 2, "Quận Bình Tân" },
                    { 50, 2, "Huyện Củ Chi" },
                    { 51, 2, "Huyện Hóc Môn" },
                    { 52, 2, "Huyện Bình Chánh" },
                    { 53, 2, "Huyện Nhà Bè" },
                    { 54, 2, "Huyện Cần Giờ" },
                    { 55, 3, "Thành phố Long Xuyên" },
                    { 56, 3, "Thành phố Câu Đốc" },
                    { 57, 3, "Thị Xã Tân Châu" },
                    { 58, 3, "Huyện An Phú" },
                    { 59, 3, "Huyện Châu Phú" },
                    { 60, 3, "Huyện Châu Thành" },
                    { 61, 3, "Huyện Chợ Mới" },
                    { 62, 3, "Huyện Phú Tân" },
                    { 63, 3, "Huyện Thoại Sơn" },
                    { 64, 3, "Huyện Tịnh Biên" },
                    { 65, 3, "Huyện Tri Tôn" },
                    { 66, 4, "Thành phố Vũng Tàu" },
                    { 67, 4, "Thành phố Bà Rịa" },
                    { 68, 4, "Thị xã Phú Mỹ" },
                    { 69, 4, "Huyện Long Điền" },
                    { 70, 4, "Huyện Đất Đỏ" },
                    { 71, 4, "Huyện Châu Đức" },
                    { 72, 4, "Huyện Xuyên Mộc" },
                    { 73, 4, "Huyện Côn Đảo" },
                    { 74, 5, "Thành phố Bắc Giang" },
                    { 75, 5, "Huyện Hiệp Hòa" },
                    { 76, 5, "Huyện Lạng Giang" },
                    { 77, 5, "Huyện Lục Nam" },
                    { 78, 5, "Huyện Lục Ngạn" },
                    { 79, 5, "Huyện Sơn Động" },
                    { 80, 5, "Huyện Tân Yên" },
                    { 81, 5, "Huyện Việt Yên" },
                    { 82, 5, "Huyện Yên Dũng" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 83, 5, "Huyện Yên Thế" },
                    { 84, 6, "Thành Phố Bắc Kạn" },
                    { 85, 6, "Huyện Ba Bể" },
                    { 86, 6, "Huyện Bạch Thông" },
                    { 87, 6, "Huyện Chợ Đồn" },
                    { 88, 6, "Huyện Chợ Mới" },
                    { 89, 6, "Huyện Na Rì" },
                    { 90, 6, "Huyện Ngân Sơn" },
                    { 91, 6, "Huyện Pác Nặm" },
                    { 92, 7, "Thành phố Bạc Liêu" },
                    { 93, 7, "Thị xã Giá Rai" },
                    { 94, 7, "Huyện Phước Long" },
                    { 95, 7, "Huyện Hồng Dân" },
                    { 96, 7, "Huyện Vĩnh Lợi" },
                    { 97, 7, "Huyện Đông Hải" },
                    { 98, 7, "Huyện Hòa Bình" },
                    { 99, 8, "Thành phố Bắc Ninh" },
                    { 100, 8, "Thành phố Từ Sơn" },
                    { 101, 8, "Huyện Gia Bình" },
                    { 102, 8, "Huyện Lương Tài" },
                    { 103, 8, "Huyện Quế Võ" },
                    { 104, 8, "Huyện Thuận Thành" },
                    { 105, 8, "Huyện Tiên Du" },
                    { 106, 8, "Huyện Yên Phong" },
                    { 107, 9, "Thành phố Bến Tre" },
                    { 108, 9, "Huyện Ba Tri" },
                    { 109, 9, "Huyện Bình Đại" },
                    { 110, 9, "Huyện Châu Thành" },
                    { 111, 9, "Huyện Chợ Lách" },
                    { 112, 9, "Huyện Giồng Trôm" },
                    { 113, 9, "Huyện Mỏ Cày Nam" },
                    { 114, 9, "Huyện Thạnh Phú" },
                    { 115, 10, "Thành phố Quy Nhơn" },
                    { 116, 10, "Huyện An Lão" },
                    { 117, 10, "Thị xã An Nhơn" },
                    { 118, 10, "Huyện Hoài Ân" },
                    { 119, 10, "Thị xã Hoài Nhơn" },
                    { 120, 10, "Huyện Phù Cát" },
                    { 121, 10, "Huyện Phù Mỹ" },
                    { 122, 10, "Huyện Tuy Phước" },
                    { 123, 10, "Huyện Tây Sơn" },
                    { 124, 10, "Huyện Vân Canh" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 125, 10, "Huyện Vĩnh Thạnh" },
                    { 126, 11, "Thành phố Thủ Dầu Một" },
                    { 127, 11, "Thị xã Bến Cát" },
                    { 128, 11, "Huyện Dầu Tiếng" },
                    { 129, 11, "Huyện Bàu Bàng" },
                    { 130, 11, "Huyện Phú Giáo" },
                    { 131, 11, "Thị xã Tân Uyên" },
                    { 132, 11, "Thành phố Dĩ An" },
                    { 133, 11, "Huyện Bắc Tân Uyên" },
                    { 134, 11, "Thành phố Thuận An" },
                    { 135, 12, "Thành phố Đồng Xoài" },
                    { 136, 12, "Thị xã Bình Long" },
                    { 137, 12, "Thị xã Phước Long" },
                    { 138, 12, "Huyện Bù Đăng" },
                    { 139, 12, "Huyện Bù Đốp" },
                    { 140, 12, "Huyện Bù Gia Mập" },
                    { 141, 12, "Huyện Chơn Thành" },
                    { 142, 12, "Huyện Đồng Phú" },
                    { 143, 12, "Huyện Hớn Quản" },
                    { 144, 12, "Huyện Lộc Ninh" },
                    { 145, 12, "Huyện Phú Riềng" },
                    { 146, 13, "Thành phố Phan Thiết" },
                    { 147, 13, "Thị xã La Gi" },
                    { 148, 13, "Huyện Tuy Phong" },
                    { 149, 13, "Huyện Bắc Bình" },
                    { 150, 13, "Huyện Hàm Thuận Bắc" },
                    { 151, 13, "Huyện Hàm Thuận Nam" },
                    { 152, 13, "Huyện Tánh Linh" },
                    { 153, 13, "Huyện Hàm Tân" },
                    { 154, 13, "Huyện Đức Linh" },
                    { 155, 13, "Huyện đảo Phú Quý" },
                    { 156, 14, "Thành phố Cà Mau" },
                    { 157, 14, "Huyện Đầm Dơi" },
                    { 158, 14, "Huyện Ngọc Hiển" },
                    { 159, 14, "Huyện Cái Nước" },
                    { 160, 14, "Huyện Trần Văn Thời" },
                    { 161, 14, "Huyện U Minh" },
                    { 162, 14, "Huyện Thới Bình" },
                    { 163, 14, "Huyện Năm Căn" },
                    { 164, 14, "Huyện Phú Tân" },
                    { 165, 15, "Quận Ninh Kiều" },
                    { 166, 15, "Quận Bình Thủy" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 167, 15, "Quận Cái Răng" },
                    { 168, 15, "Quận Ô Môn" },
                    { 169, 15, "Quận Thốt Nốt" },
                    { 170, 15, "Quận Hưng Phú" },
                    { 171, 15, "Huyện Phong Điền" },
                    { 172, 15, "Huyện Cờ Đỏ" },
                    { 173, 15, "Huyện Thới Lai" },
                    { 174, 15, "Huyện Vĩnh Thạnh" },
                    { 175, 16, "Thành phố Cao Bằng" },
                    { 176, 16, "Huyện Bảo Lạc" },
                    { 177, 16, "Huyện Bảo Lâm" },
                    { 178, 16, "Huyện Hạ Lang" },
                    { 179, 16, "Huyện Hà Quảng" },
                    { 180, 16, "Huyện Hòa An" },
                    { 181, 16, "Huyện Nguyên Bình" },
                    { 182, 16, "Huyện Phục Hòa" },
                    { 183, 16, "Huyện Quảng Uyên" },
                    { 184, 16, "Huyện Thạch An" },
                    { 185, 16, "Huyện Thông Nông" },
                    { 186, 16, "Huyện Trà Lĩnh" },
                    { 187, 16, "Huyện Trùng Khánh" },
                    { 188, 16, "Huyện Quảng Hòa" },
                    { 189, 17, "Quận Hải Châu" },
                    { 190, 17, "Quận Thanh Khê" },
                    { 191, 17, "Quận Sơn Trà" },
                    { 192, 17, "Quận Ngũ Hành Sơn" },
                    { 193, 17, "Quận Liên Chiểu" },
                    { 194, 17, "Quận Cẩm Lệ" },
                    { 195, 17, "Huyện Hòa Vang" },
                    { 196, 17, "Huyện đảo Hoàng Sa" },
                    { 197, 18, "Thành phố Buôn Ma Thuột" },
                    { 198, 18, "Thị xã Buôn Hồ" },
                    { 199, 18, "Huyện Buôn Đôn" },
                    { 200, 18, "Huyện Cư Kuin" },
                    { 201, 18, "Huyện Cư M'gar" },
                    { 202, 18, "Huyện Ea H'leo" },
                    { 203, 18, "Huyện Ea Kar" },
                    { 204, 18, "Huyện Ea Súp" },
                    { 205, 18, "Huyện Krông Bông" },
                    { 206, 18, "Huyện Krông Búk" },
                    { 207, 18, "Huyện Krông Pắc" },
                    { 208, 18, "Huyện Lắk" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 209, 18, "Huyện M'Đrắk" },
                    { 210, 18, "Huyện Krông Ana" },
                    { 211, 18, "Huyện Krông Năng" },
                    { 212, 19, "Thành phố Gia Nghĩa" },
                    { 213, 19, "Huyện Cư Jút" },
                    { 214, 19, "Huyện Đắk Glong" },
                    { 215, 19, "Huyện Đắk Mil" },
                    { 216, 19, "Huyện Đắk R'Lấp" },
                    { 217, 19, "Huyện Đắk Song" },
                    { 218, 19, "Huyện Krông Nô" },
                    { 219, 19, "Huyện Tuy Đức" },
                    { 220, 20, "Thành phố Điện Biên Phủ" },
                    { 221, 20, "Thị xã Mường Lay" },
                    { 222, 20, "Huyện Điện Biên" },
                    { 223, 20, "Huyện Điện Biên Đông" },
                    { 224, 20, "Huyện Mường Ảng" },
                    { 225, 20, "Huyện Mường Chà" },
                    { 226, 20, "Huyện Mường Nhé" },
                    { 227, 20, "Huyện Tủa Chùa" },
                    { 228, 20, "Huyện Tuần Giáo" },
                    { 229, 20, "Huyện Nậm Pồ" },
                    { 230, 21, "Thành phố Biên Hòa" },
                    { 231, 21, "Thành phố Long Khánh" },
                    { 232, 21, "Huyện Định Quán" },
                    { 233, 21, "Huyện Long Thành" },
                    { 234, 21, "Huyện Nhơn Trạch" },
                    { 235, 21, "Huyện Tân Phú" },
                    { 236, 21, "Huyện Thống Nhất" },
                    { 237, 21, "Huyện Vĩnh Cửu" },
                    { 238, 21, "Huyện Xuân Lộc" },
                    { 239, 21, "Huyện Cẩm Mỹ" },
                    { 240, 21, "Huyện Trảng Bom" },
                    { 241, 22, "Thành phố Cao Lãnh" },
                    { 242, 22, "Thành phố Sa Đéc" },
                    { 243, 22, "Thành phố Hồng Ngự" },
                    { 244, 22, "Huyện Cao Lãnh" },
                    { 245, 22, "Huyện Châu Thành" },
                    { 246, 22, "Huyện Hồng Ngự" },
                    { 247, 22, "Huyện Lai Vung" },
                    { 248, 22, "Huyện Lấp Vò" },
                    { 249, 22, "Huyện Tam Nông" },
                    { 250, 22, "Huyện Tân Hồng" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 251, 22, "Huyện Thanh Bình" },
                    { 252, 22, "Huyện Tháp Mười" },
                    { 253, 23, "Thành phố Pleiku" },
                    { 254, 23, "Thị xã An Khê" },
                    { 255, 23, "Thị xã Ayun Pa" },
                    { 256, 23, "Huyện Chư Păh" },
                    { 257, 23, "Huyện Chư Prông" },
                    { 258, 23, "Huyện Chư Sê" },
                    { 259, 23, "Huyện Đăk Đoa" },
                    { 260, 23, "Huyện Đăk Pơ" },
                    { 261, 23, "Huyện Đức Cơ" },
                    { 262, 23, "Huyện Ia Grai" },
                    { 263, 23, "Huyện Ia Pa" },
                    { 264, 23, "Huyện K'Bang" },
                    { 265, 23, "Huyện Kông Chro" },
                    { 266, 23, "Huyện Krông Pa" },
                    { 267, 23, "Huyện Mang Yang" },
                    { 268, 23, "Huyện Phú Thiện" },
                    { 269, 23, "Huyện Chư Pưh" },
                    { 270, 24, "Thành phố Hà Giang" },
                    { 271, 24, "Huyện Bắc Mê" },
                    { 272, 24, "Huyện Bắc Quang" },
                    { 273, 24, "Huyện Đồng Văn" },
                    { 274, 24, "Huyện Hoàng Su Phì" },
                    { 275, 24, "Huyện Mèo Vạc" },
                    { 276, 24, "Huyện Quản Bạ" },
                    { 277, 24, "Huyện Quang Bình" },
                    { 278, 24, "Huyện Vị Xuyên" },
                    { 279, 24, "Huyện Xín Mần" },
                    { 280, 24, "Huyện Yên Minh" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Price", "ProductName", "Quantity", "Summary" },
                values: new object[,]
                {
                    { 6, 2, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9115), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 4340000m, "mothercare - Lục lạc hình voi", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 7, 2, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9117), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 2550000m, "Bộ đồ chơi vận động liên hoàn", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 8, 2, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9118), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 3860000m, "đồ chơi sắp xếp hình dạng bằng gồ ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 9, 1, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9119), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 4340000m, "sư tử bập bênh ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 10, 1, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9122), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 6550000m, "Gấu bông lovable bear lớn ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "FileName", "ProductId" },
                values: new object[,]
                {
                    { 16, "do-choi-chu-cua-hermit-sieu-quay-1.jpg", 6 },
                    { 17, "do-choi-chu-cua-hermit-sieu-quay-1.jpg", 6 },
                    { 18, "do-choi-ga-con-phat-sang-co-nhac-4.jpg", 6 },
                    { 19, "do-choi-ga-con-phat-sang-co-nhac-4.jpg", 7 },
                    { 20, "do-choi-ga-con-phat-sang-co-nhac-4.jpg", 7 },
                    { 21, "do-choi-ga-con-phat-sang-co-nhac-4.jpg", 7 },
                    { 22, "do-choi-nimo-cau-ca-1.jpg", 8 },
                    { 23, "do-choi-nimo-cau-ca-1.jpg", 8 },
                    { 24, "do-choi-nimo-o-to-cho-be-1.jpg", 8 },
                    { 25, "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", 9 },
                    { 26, "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", 9 },
                    { 27, "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", 9 },
                    { 28, "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", 10 },
                    { 29, "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", 10 },
                    { 30, "do-choi-xe-day-hinh-thu-lac-lu-6.jpg", 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Price", "ProductName", "Quantity", "Summary" },
                values: new object[,]
                {
                    { 1, 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9106), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 1100000m, "Thú bông voi con", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 2, 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9109), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 1670000m, "Đồ chơi thổi bóng hình gấu nâu 2023A", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 3, 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9111), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 760000m, "Đồ chơi thổi bong bóng", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 4, 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9112), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 820000m, "Đồ chơi đất nặn 8 màu 100g", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 5, 3, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9113), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 870000m, "Kệ chữ A xúc xắc Sato", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 11, 4, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9123), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 4340000m, "Set 3 lục lạc lovable bear ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 12, 4, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9125), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 6550000m, "Gấu nhồi bông lovable bear ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." },
                    { 13, 4, "Admin", new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9126), "<div><h3>Thông tin sản phẩm</h3><ul><li><strong>Thương hiệu:</strong> Nimo</li><li><strong>Nơi sản xuất:</strong> Trung Quốc</li><li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li><li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li></ul></div><div><h3>Mô tả sản phẩm</h3><p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p></div>", null, null, 7860000m, "Treo nôi phát ra nhạc lovable bear ", 35, "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé." }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "FileName", "ProductId" },
                values: new object[,]
                {
                    { 1, "ban-bi-lac-da-bong.jpg", 1 },
                    { 2, "ban-bi-lac-da-bong.jpg", 1 },
                    { 3, "ban-bi-lac-da-bong.jpg", 1 },
                    { 4, "bo-roi-5-ngon-tay-hinh-vit.jpg", 2 },
                    { 5, "bo-roi-5-ngon-tay-hinh-vit.jpg", 2 },
                    { 6, "bo-roi-5-ngon-tay-hinh-vit.jpg", 2 },
                    { 7, "do-choi-con-bay.jpg", 3 },
                    { 8, "do-choi-con-bay.jpg", 3 },
                    { 9, "do-choi-con-bay.jpg", 3 },
                    { 10, "do-choi-cot-do.jpg", 4 },
                    { 11, "do-choi-cot-do.jpg", 4 },
                    { 12, "do-choi-cot-do.jpg", 4 },
                    { 13, "do-choi-cot-trang.jpg", 5 },
                    { 14, "do-choi-cot-trang.jpg", 5 },
                    { 15, "do-choi-chu-cua-hermit-sieu-quay-1.jpg", 5 },
                    { 31, "rau-con-mau-xanh-do.jpg", 11 },
                    { 32, "rau-con-mau-xanh-do.jpg", 11 },
                    { 33, "rau-con-mau-xanh-do.jpg", 11 },
                    { 34, "robot-nm19-62-n608a-trang-cam-120307.jpg", 12 },
                    { 35, "robot-nm19-62-n608a-trang-cam-120307.jpg", 12 },
                    { 36, "robot-nm19-62-n608a-trang-cam-120307.jpg", 12 },
                    { 37, "vit-con-abc-2.jpg", 13 },
                    { 38, "vit-con-abc-2.jpg", 13 },
                    { 39, "vit-con-abc-2.jpg", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DistrictId",
                table: "Orders",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanDochoi.Web.Migrations
{
    public partial class vcuoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "ShortDescription", "Title" },
                values: new object[] { 1, "Tiệm đồ chơi được biết đến là cửa hàng bán đồ chơi an toàn cho trẻ em đồng thời bán với giá cả hợp lý, là cửa hàng chuyên bán sỉ, bán lẻ các sản phẩm đồ chơi cao cấp cho các bé từ 1 đến 7 tuổi.\r\n\r\n  \r\n\r\n \r\n\r\nChúng tôi làm việc với phương châm vì con yêu của bạn nên mỗi sản phẩm sẽ luôn đảm bảo:\r\n- Những đồ chơi tại cửa hàng Chibica Shop đang bán đều được nhập từ các nhà sản xuất có uy tín, nguyên liệu, chất liệu tạo ra những món đồ chơi, đồ dùng rất an toàn cho làn da của bé, không gây hại hay làm tổn hại đến hệ hô hấp của con mà nó còn giúp cho trẻ phát triển kỹ năng tư duy và óc sáng tạo.\r\n- Những sản phẩm của chúng tôi được lựa chọn tính toán kỹ lưỡng để bé có được nhiều món đồ chơi tốt mà bố mẹ cũng không quá đau ví tiền của mình.\r\n- Cửa hàng chúng tôi cũng cung cấp rất đa dạng về chủng loại và mẫu mã từ đồ chơi bằng gỗ, đồ chơi bằng nhựa an toàn, các món đồ chơi kích thích trí tuệ và mang tính giáo dục cho bé như: bộ đồ chơi rút gỗ, bộ bàn tính đa năng, bộ giáo cụ hình học, bộ thẻ học thông minh 16 chủ đề… hay các món đồ tăng cường tự lập cho bé như: bộ đồ chơi nấu ăn kitchen, bộ đồ chơi nhà bếp 31 chi tiết... và rất nhiều bộ sản phẩm khác có tính công nghệ và nghề nghiệp giúp trẻ phát triển năng động ngay từ nhỏ.\r\n\r\n \r\n\r\n\r\n \r\n\r\n \r\n\r\n Hình ảnh bộ đồ chơi được làm từ chất liệu an toàn cho bé\r\n\r\n\r\n\r\nVới đội ngũ nhân viên làm việc chuyên nghiệp và nhiệt tình quý phụ huynh sẽ hài lòng và yên tâm hơn khi lựa chọn các sản phẩm đồ chơi, đồ dùng trẻ em tại hệ thống cửa hầng Chibica Shop. Cùng với kinh nghiệm làm việc trên 6 năm bán hàng, cửa hàng Chibica Shop đang là lựa chọn thông minh cho các bâc phụ huynh có con em nhỏ. Bởi, trên thị trường đang có rất nhiều sản phẩm đồ chơi được bày bán và chúng tôi khuyên các bậc phụ huynh nên lựa chọn những sản phẩm uy tín và chất lượng tốt nhất theo sở thích và tính cách của trẻ nhỏ, để trẻ có thể phát triển toàn diện trí tuệ và óc sáng tạo của mình.", "Admin", new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7250), null, null, "Mô tả test", "Chào mừng quý khách hàng đã đến với Tiemdochoi.vn!" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 25, 18, 85, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd866dd5-a4af-406b-a945-239f978608fc", "f02b2cf9-aa6c-41ec-8fb2-0bebef52d8d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "HomeAdress", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "abe3ffa0-434e-4038-9181-f0baaa623fd6", 0, null, "69764072-b4f5-4a00-9e7b-11a07ddfe031", "admin@gmail.com", true, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEOAM+WYJ8ex0oIuJJM4IOiNa528Qp/+Md86uy+zcd8B49OGDEjyN25Z6x/N5lzjl+Q==", null, false, "578da166-f18b-43a0-a1cd-d7b24d43b9cf", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cd866dd5-a4af-406b-a945-239f978608fc", "abe3ffa0-434e-4038-9181-f0baaa623fd6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd866dd5-a4af-406b-a945-239f978608fc", "abe3ffa0-434e-4038-9181-f0baaa623fd6" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd866dd5-a4af-406b-a945-239f978608fc");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "abe3ffa0-434e-4038-9181-f0baaa623fd6");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 17, 21, 1, 53, 664, DateTimeKind.Local).AddTicks(9126));
        }
    }
}

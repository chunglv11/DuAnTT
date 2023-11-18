using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System;
using Microsoft.AspNetCore.Identity;
using BanDochoi.Web.Models;
using System.Runtime.InteropServices;
using Org.BouncyCastle.Utilities;
using MessagePack;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using BanDochoi.Web.Areas.Identity.Data;

namespace BanDochoi.Web.Data
{
    public static class DbInit
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Tạo và thêm role vào database
            var roleManager = modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "cd866dd5-a4af-406b-a945-239f978608fc", Name = "Admin", NormalizedName = "ADMIN" }
            );
            var hasher = new PasswordHasher<AppUser>();
            var userManager = modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = "abe3ffa0-434e-4038-9181-f0baaa623fd6",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(null, "@Admin123"),
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "cd866dd5-a4af-406b-a945-239f978608fc", UserId = "abe3ffa0-434e-4038-9181-f0baaa623fd6" } // Gán role "Admin" cho user 
        );
            string d = "<div>" +
                        "<h3>Thông tin sản phẩm</h3>" +
                        "<ul>" +
                            "<li><strong>Thương hiệu:</strong> Nimo</li>" +
                            "<li><strong>Nơi sản xuất:</strong> Trung Quốc</li>" +
                            "<li><strong>Độ tuổi sử dụng:</strong> Trên 18 tháng</li>" +
                            "<li><strong>Kích thước sản phẩm (D x R x C):</strong> 10 x 7 x 8cm</li>" +
                        "</ul>" +
                    "</div>" +
                    "<div>" +
                        "<h3>Mô tả sản phẩm</h3>" +
                        "<p>Đồ chơi lật đật biết chạy hình thú đáng yêu 116-2A với tạo hình dễ thương cùng thiết kế thông minh chính là món đồ chơi không thể thiếu trong giai đoạn tuổi thơ của bé. Khi di chuyển, lật đật sẽ dang tay sang 2 bên và lắc lư trái phải cực ngộ nghĩnh tạo nên sự thích thú cho bé yêu. Bên cạnh đó, nhờ tạo hình đáng yêu cùng khả năng di chuyển thú vị của mình, sản phẩm sẽ tạo sự cuốn hút đối với bé, kích thích bé bò theo nhờ đó quá trình tập bò trở nên dễ dàng hơn.</p>" +
                    "</div>";

            List<City> citys = new List<City>()
            {
                new City { Id=1,CityName = "TP Hà Nội" },
                new City { Id=2,CityName = "TP Hồ Chí Minh" },
                new City { Id=3,CityName = "An Giang" },
                new City { Id=4,CityName = "Bà Rịa – Vũng Tàu" },
                new City { Id=5,CityName = "Bắc Giang" },
                new City { Id=6,CityName = "Bắc Kạn" },
                new City { Id=7,CityName = "Bạc Liêu" },
                new City { Id=8,CityName = "Bắc Ninh" },
                new City { Id=9,CityName = "Bến Tre" },
                new City { Id=10,CityName = "Bình Định" },
                new City { Id=11,CityName = "Bình Dương" },
                new City { Id=12,CityName = "Bình Phước" },
                new City { Id=13,CityName = "Bình Thuận" },
                new City { Id=14,CityName = "Cà Mau" },
                new City { Id=15,CityName = "TP Cần Thơ" },
                new City { Id=16,CityName = "Cao Bằng" },
                new City { Id=17,CityName = "TP Đà Nẵng" },
                new City { Id=18,CityName = "Đắk Lắk" },
                new City { Id=19,CityName = "Đắk Nông" },
                new City { Id=20,CityName = "Điện Biên" },
                new City { Id=21,CityName = "Đồng Nai" },
                new City { Id=22,CityName = "Đồng Tháp" },
                new City { Id=23,CityName = "Gia Lai" },
                new City { Id=24,CityName = "Hà Giang" },
                new City { Id=25,CityName = "Hà Nam" },
                new City { Id=26,CityName = "Hà Tĩnh" },
                new City { Id=27,CityName = "Hải Dương" },
                new City { Id=28,CityName = "TP Hải Phòng" },
                new City { Id=29,CityName = "Hậu Giang" },
                new City { Id=30,CityName = "Hòa Bình" },
                new City { Id=31,CityName = "Hưng Yên" },
                new City { Id=32,CityName = "Khánh Hòa" },
                new City { Id=33,CityName = "Kiên Giang" },
                new City { Id=34,CityName = "Kon Tum" },
                new City { Id=35,CityName = "Lai Châu" },
                new City { Id=36,CityName = "Lâm Đồng" },
                new City { Id=37,CityName = "Lạng Sơn" },
                new City { Id=38,CityName = "Lào Cai" },
                new City { Id=39,CityName = "Long An" },
                new City { Id=40,CityName = "Nam Định" },
                new City { Id=41,CityName = "Nghệ An" },
                new City { Id=42,CityName = "Ninh Bình" },
                new City { Id=43,CityName = "Ninh Thuận" },
                new City { Id=44,CityName = "Phú Thọ" },
                new City { Id=45,CityName = "Phú Yên" },
                new City { Id=46,CityName = "Quảng Bình" },
                new City { Id=47,CityName = "Quảng Nam" },
                new City { Id=48,CityName = "Quảng Ngãi" },
                new City { Id=49,CityName = "Quảng Ninh" },
                new City { Id=50,CityName = "Quảng Trị" },
                new City { Id=51,CityName = "Sóc Trăng" },
                new City { Id=52,CityName = "Sơn La" },
                new City { Id=53,CityName = "Tây Ninh" },
                new City { Id=54,CityName = "Thái Bình" },
                new City { Id=55,CityName = "Thái Nguyên" },
                new City { Id=56,CityName = "Thanh Hóa" },
                new City { Id=57,CityName = "Thừa Thiên Huế" },
                new City { Id=58,CityName = "Tiền Giang" },
                new City { Id=59,CityName = "Trà Vinh" },
                new City { Id=60,CityName = "Tuyên Quang" },
                new City { Id=61,CityName = "Vĩnh Long" },
                new City { Id=62,CityName = "Vĩnh Phúc" },
                new City { Id=63,CityName = "Yên Bái" }
            };
            List<District> districts = new List<District>()
            {
                new District(){Name="Quận Ba Đình", CityId=1},
                new District(){Name="Quận Hoàn Kiếm", CityId=1},
                new District(){Name="Quận Tây Hồ", CityId=1},
                new District(){Name="Quận Long Biên", CityId=1},
                new District(){Name="Quận Cầu Giấy", CityId=1},
                new District(){Name="Quận Đống Đa", CityId=1},
                new District(){Name="Quận Hai Bà Trưng", CityId=1},
                new District(){Name="Quận Hoàng Mai", CityId=1},
                new District(){Name="Quận Thanh Xuân", CityId=1},
                new District(){Name="Quận Bắc Từ Liêm", CityId=1},
                new District(){Name="Quận Nam Từ Liêm", CityId=1},
                new District(){Name="Quận Hà Đông", CityId=1},
                new District(){Name="Huyện Sóc Sơn", CityId=1},
                new District(){Name="Huyện Đông Anh", CityId=1},
                new District(){Name="Huyện Gia Lâm", CityId=1},
                new District(){Name="Huyện Thanh Trì", CityId=1},
                new District(){Name="Huyện Mê Linh", CityId=1},
                new District(){Name="Thị xã Sơn Tây", CityId=1},
                new District(){Name="Huyện Ba Vì", CityId=1},
                new District(){Name="Huyện Phúc Thọ", CityId=1},
                new District(){Name="Huyện Đan Phượng", CityId=1},
                new District(){Name="Huyện Hoài Đức", CityId=1},
                new District(){Name="Huyện Quốc Oai", CityId=1},
                new District(){Name="Huyện Thạch Thất", CityId=1},
                new District(){Name="Huyện Chương Mỹ", CityId=1},
                new District(){Name="Huyện Thanh Oai", CityId=1},
                new District(){Name="Huyện Thường Tín", CityId=1},
                new District(){Name="Huyện Phú Xuyên", CityId=1},
                new District(){Name="Huyện Mỹ Đức", CityId=1},
                new District(){Name="Huyện Ứng Hòa", CityId=1},
                // tại thành phố hcm
                new District(){Name="Quận 1", CityId=2},
                new District(){Name="Quận 2", CityId=2},
                new District(){Name="Quận 3", CityId=2},
                new District(){Name="Quận 4", CityId=2},
                new District(){Name="Quận 5", CityId=2},
                new District(){Name="Quận 6", CityId=2},
                new District(){Name="Quận 7", CityId=2},
                new District(){Name="Quận 8", CityId=2},
                new District(){Name="Quận 9", CityId=2},
                new District(){Name="Quận 10", CityId=2},
                new District(){Name="Quận 11", CityId=2},
                new District(){Name="Quận 12", CityId=2},
                new District(){Name="Quận Thủ Đức", CityId=2},
                new District(){Name="Quận Gò Vấp", CityId=2},
                new District(){Name="Quận Bình Thạnh", CityId=2},
                new District(){Name="Quận Tân Bình", CityId=2},
                new District(){Name="Quận Tân Phú", CityId=2},
                new District(){Name="Quận Phú Nhuận", CityId=2},
                new District(){Name="Quận Bình Tân", CityId=2},
                new District(){Name="Huyện Củ Chi", CityId=2},
                new District(){Name="Huyện Hóc Môn", CityId=2},
                new District(){Name="Huyện Bình Chánh", CityId=2},
                new District(){Name="Huyện Nhà Bè", CityId=2},
                new District(){Name="Huyện Cần Giờ", CityId=2},
                // tại an giang
                new District(){Name="Thành phố Long Xuyên", CityId=3},
                new District(){Name="Thành phố Câu Đốc", CityId=3},
                new District(){Name="Thị Xã Tân Châu", CityId=3},
                new District(){Name="Huyện An Phú", CityId=3},
                new District(){Name="Huyện Châu Phú", CityId=3},
                new District(){Name="Huyện Châu Thành", CityId=3},
                new District(){Name="Huyện Chợ Mới", CityId=3},
                new District(){Name="Huyện Phú Tân", CityId=3},
                new District(){Name="Huyện Thoại Sơn", CityId=3},
                new District(){Name="Huyện Tịnh Biên", CityId=3},
                new District(){Name="Huyện Tri Tôn", CityId=3},
                // Bà Rịa Vũng Tàu
                new District(){Name="Thành phố Vũng Tàu", CityId=4},
                new District(){Name="Thành phố Bà Rịa", CityId=4},
                new District(){Name="Thị xã Phú Mỹ", CityId=4},
                new District(){Name="Huyện Long Điền", CityId=4},
                new District(){Name="Huyện Đất Đỏ", CityId=4},
                new District(){Name="Huyện Châu Đức", CityId=4},
                new District(){Name="Huyện Xuyên Mộc", CityId=4},
                new District(){Name="Huyện Côn Đảo", CityId=4},
                //bắc giang
                new District(){Name="Thành phố Bắc Giang", CityId=5},
                new District(){Name="Huyện Hiệp Hòa", CityId=5},
                new District(){Name="Huyện Lạng Giang", CityId=5},
                new District(){Name="Huyện Lục Nam", CityId=5},
                new District(){Name="Huyện Lục Ngạn", CityId=5},
                new District(){Name="Huyện Sơn Động", CityId=5},
                new District(){Name="Huyện Tân Yên", CityId=5},
                new District(){Name="Huyện Việt Yên", CityId=5},
                new District(){Name="Huyện Yên Dũng", CityId=5},
                new District(){Name="Huyện Yên Thế", CityId=5},
                //bắc cạn
                new District(){Name="Thành Phố Bắc Kạn", CityId=6},
                new District(){Name="Huyện Ba Bể", CityId=6},
                new District(){Name="Huyện Bạch Thông", CityId=6},
                new District(){Name="Huyện Chợ Đồn", CityId=6},
                new District(){Name="Huyện Chợ Mới", CityId=6},
                new District(){Name="Huyện Na Rì", CityId=6},
                new District(){Name="Huyện Ngân Sơn", CityId=6},
                new District(){Name="Huyện Pác Nặm", CityId=6},
                // bạc liêu
                new District(){Name="Thành phố Bạc Liêu", CityId=7},
                new District(){Name="Thị xã Giá Rai", CityId=7},
                new District(){Name="Huyện Phước Long", CityId=7},
                new District(){Name="Huyện Hồng Dân", CityId=7},
                new District(){Name="Huyện Vĩnh Lợi", CityId=7},
                new District(){Name="Huyện Đông Hải", CityId=7},
                new District(){Name="Huyện Hòa Bình", CityId=7},
                // Bắc Ninh
                new District(){Name="Thành phố Bắc Ninh", CityId=8},
                new District(){Name="Thành phố Từ Sơn", CityId=8},
                new District(){Name="Huyện Gia Bình", CityId=8},
                new District(){Name="Huyện Lương Tài", CityId=8},
                new District(){Name="Huyện Quế Võ", CityId=8},
                new District(){Name="Huyện Thuận Thành", CityId=8},
                new District(){Name="Huyện Tiên Du", CityId=8},
                new District(){Name="Huyện Yên Phong", CityId=8},
                //Bến Tre
                new District(){Name="Thành phố Bến Tre", CityId=9},
                new District(){Name="Huyện Ba Tri", CityId=9},
                new District(){Name="Huyện Bình Đại", CityId=9},
                new District(){Name="Huyện Châu Thành", CityId=9},
                new District(){Name="Huyện Chợ Lách", CityId=9},
                new District(){Name="Huyện Giồng Trôm", CityId=9},
                new District(){Name="Huyện Mỏ Cày Nam", CityId=9},
                new District(){Name="Huyện Thạnh Phú", CityId=9},
                // bình định
                new District(){Name="Thành phố Quy Nhơn", CityId=10},
                new District(){Name="Huyện An Lão", CityId=10},
                new District(){Name="Thị xã An Nhơn", CityId=10},
                new District(){Name="Huyện Hoài Ân", CityId=10},
                new District(){Name="Thị xã Hoài Nhơn", CityId=10},
                new District(){Name="Huyện Phù Cát", CityId=10},
                new District(){Name="Huyện Phù Mỹ", CityId=10},
                new District(){Name="Huyện Tuy Phước", CityId=10},
                new District(){Name="Huyện Tây Sơn", CityId=10},
                new District(){Name="Huyện Vân Canh", CityId=10},
                new District(){Name="Huyện Vĩnh Thạnh", CityId=10},
                // bình dương
                new District(){Name="Thành phố Thủ Dầu Một", CityId=11},
                new District(){Name="Thị xã Bến Cát", CityId=11},
                new District(){Name="Huyện Dầu Tiếng", CityId=11},
                new District(){Name="Huyện Bàu Bàng", CityId=11},
                new District(){Name="Huyện Phú Giáo", CityId=11},
                new District(){Name="Thị xã Tân Uyên", CityId=11},
                new District(){Name="Thành phố Dĩ An", CityId=11},
                new District(){Name="Huyện Bắc Tân Uyên", CityId=11},
                new District(){Name="Thành phố Thuận An", CityId=11},
                // Bình Phước
                new District(){Name="Thành phố Đồng Xoài", CityId=12},
                new District(){Name="Thị xã Bình Long", CityId=12},
                new District(){Name="Thị xã Phước Long", CityId=12},
                new District(){Name="Huyện Bù Đăng", CityId=12},
                new District(){Name="Huyện Bù Đốp", CityId=12},
                new District(){Name="Huyện Bù Gia Mập", CityId=12},
                new District(){Name="Huyện Chơn Thành", CityId=12},
                new District(){Name="Huyện Đồng Phú", CityId=12},
                new District(){Name="Huyện Hớn Quản", CityId=12},
                new District(){Name="Huyện Lộc Ninh", CityId=12},
                new District(){Name="Huyện Phú Riềng", CityId=12},
                // Bình Thuận
                new District(){Name="Thành phố Phan Thiết", CityId=13},
                new District(){Name="Thị xã La Gi", CityId=13},
                new District(){Name="Huyện Tuy Phong", CityId=13},
                new District(){Name="Huyện Bắc Bình", CityId=13},
                new District(){Name="Huyện Hàm Thuận Bắc", CityId=13},
                new District(){Name="Huyện Hàm Thuận Nam", CityId=13},
                new District(){Name="Huyện Tánh Linh", CityId=13},
                new District(){Name="Huyện Hàm Tân", CityId=13},
                new District(){Name="Huyện Đức Linh", CityId=13},
                new District(){Name="Huyện đảo Phú Quý", CityId=13},
                // Cà mau
                new District(){Name="Thành phố Cà Mau", CityId=14},
                new District(){Name="Huyện Đầm Dơi", CityId=14},
                new District(){Name="Huyện Ngọc Hiển", CityId=14},
                new District(){Name="Huyện Cái Nước", CityId=14},
                new District(){Name="Huyện Trần Văn Thời", CityId=14},
                new District(){Name="Huyện U Minh", CityId=14},
                new District(){Name="Huyện Thới Bình", CityId=14},
                new District(){Name="Huyện Năm Căn", CityId=14},
                new District(){Name="Huyện Phú Tân", CityId=14},
                // cần thơ
                new District(){Name="Quận Ninh Kiều", CityId=15},
                new District(){Name="Quận Bình Thủy", CityId=15},
                new District(){Name="Quận Cái Răng", CityId=15},
                new District(){Name="Quận Ô Môn", CityId=15},
                new District(){Name="Quận Thốt Nốt", CityId=15},
                new District(){Name="Quận Hưng Phú", CityId=15},
                new District(){Name="Huyện Phong Điền", CityId=15},
                new District(){Name="Huyện Cờ Đỏ", CityId=15},
                new District(){Name="Huyện Thới Lai", CityId=15},
                new District(){Name="Huyện Vĩnh Thạnh", CityId=15},
                //cao bằng
                new District(){Name="Thành phố Cao Bằng", CityId=16},
                new District(){Name="Huyện Bảo Lạc", CityId=16},
                new District(){Name="Huyện Bảo Lâm", CityId=16},
                new District(){Name="Huyện Hạ Lang", CityId=16},
                new District(){Name="Huyện Hà Quảng", CityId=16},
                new District(){Name="Huyện Hòa An", CityId=16},
                new District(){Name="Huyện Nguyên Bình", CityId=16},
                new District(){Name="Huyện Phục Hòa", CityId=16},
                new District(){Name="Huyện Quảng Uyên", CityId=16},
                new District(){Name="Huyện Thạch An", CityId=16},
                new District(){Name="Huyện Thông Nông", CityId=16},
                new District(){Name="Huyện Trà Lĩnh", CityId=16},
                new District(){Name="Huyện Trùng Khánh", CityId=16},
                new District(){Name="Huyện Quảng Hòa", CityId=16},
                // đà nẵng
                new District(){Name="Quận Hải Châu", CityId=17},
                new District(){Name="Quận Thanh Khê", CityId=17},
                new District(){Name="Quận Sơn Trà", CityId=17},
                new District(){Name="Quận Ngũ Hành Sơn", CityId=17},
                new District(){Name="Quận Liên Chiểu", CityId=17},
                new District(){Name="Quận Cẩm Lệ", CityId=17},
                new District(){Name="Huyện Hòa Vang", CityId=17},
                new District(){Name="Huyện đảo Hoàng Sa", CityId=17},
                //Đắk Lắk
                new District(){Name="Thành phố Buôn Ma Thuột", CityId=18},
                new District(){Name="Thị xã Buôn Hồ", CityId=18},
                new District(){Name="Huyện Buôn Đôn", CityId=18},
                new District(){Name="Huyện Cư Kuin", CityId=18},
                new District(){Name="Huyện Cư M'gar", CityId=18},
                new District(){Name="Huyện Ea H'leo", CityId=18},
                new District(){Name="Huyện Ea Kar", CityId=18},
                new District(){Name="Huyện Ea Súp", CityId=18},
                new District(){Name="Huyện Krông Bông", CityId=18},
                new District(){Name="Huyện Krông Búk", CityId=18},
                new District(){Name="Huyện Krông Pắc", CityId=18},
                new District(){Name="Huyện Lắk", CityId=18},
                new District(){Name="Huyện M'Đrắk", CityId=18},
                new District(){Name="Huyện Krông Ana", CityId=18},
                new District(){Name="Huyện Krông Năng", CityId=18},
                //Đắk Nông
                new District(){Name="Thành phố Gia Nghĩa", CityId=19},
                new District(){Name="Huyện Cư Jút", CityId=19},
                new District(){Name="Huyện Đắk Glong", CityId=19},
                new District(){Name="Huyện Đắk Mil", CityId=19},
                new District(){Name="Huyện Đắk R'Lấp", CityId=19},
                new District(){Name="Huyện Đắk Song", CityId=19},
                new District(){Name="Huyện Krông Nô", CityId=19},
                new District(){Name="Huyện Tuy Đức", CityId=19},
                //Điện biên
                new District(){Name="Thành phố Điện Biên Phủ", CityId=20},
                new District(){Name="Thị xã Mường Lay", CityId=20},
                new District(){Name="Huyện Điện Biên", CityId=20},
                new District(){Name="Huyện Điện Biên Đông", CityId=20},
                new District(){Name="Huyện Mường Ảng", CityId=20},
                new District(){Name="Huyện Mường Chà", CityId=20},
                new District(){Name="Huyện Mường Nhé", CityId=20},
                new District(){Name="Huyện Tủa Chùa", CityId=20},
                new District(){Name="Huyện Tuần Giáo", CityId=20},
                new District(){Name="Huyện Nậm Pồ", CityId=20},
                //Đồng Nai
                new District(){Name="Thành phố Biên Hòa", CityId=21},
                new District(){Name="Thành phố Long Khánh", CityId=21},
                new District(){Name="Huyện Định Quán", CityId=21},
                new District(){Name="Huyện Long Thành", CityId=21},
                new District(){Name="Huyện Nhơn Trạch", CityId=21},
                new District(){Name="Huyện Tân Phú", CityId=21},
                new District(){Name="Huyện Thống Nhất", CityId=21},
                new District(){Name="Huyện Vĩnh Cửu", CityId=21},
                new District(){Name="Huyện Xuân Lộc", CityId=21},
                new District(){Name="Huyện Cẩm Mỹ", CityId=21},
                new District(){Name="Huyện Trảng Bom", CityId=21},
                //Đồng Tháp
                new District(){Name="Thành phố Cao Lãnh", CityId=22},
                new District(){Name="Thành phố Sa Đéc", CityId=22},
                new District(){Name="Thành phố Hồng Ngự", CityId=22},
                new District(){Name="Huyện Cao Lãnh", CityId=22},
                new District(){Name="Huyện Châu Thành", CityId=22},
                new District(){Name="Huyện Hồng Ngự", CityId=22},
                new District(){Name="Huyện Lai Vung", CityId=22},
                new District(){Name="Huyện Lấp Vò", CityId=22},
                new District(){Name="Huyện Tam Nông", CityId=22},
                new District(){Name="Huyện Tân Hồng", CityId=22},
                new District(){Name="Huyện Thanh Bình", CityId=22},
                new District(){Name="Huyện Tháp Mười", CityId=22},
                //Gia Lai
                new District(){Name="Thành phố Pleiku", CityId=23},
                new District(){Name="Thị xã An Khê", CityId=23},
                new District(){Name="Thị xã Ayun Pa", CityId=23},
                new District(){Name="Huyện Chư Păh", CityId=23},
                new District(){Name="Huyện Chư Prông", CityId=23},
                new District(){Name="Huyện Chư Sê", CityId=23},
                new District(){Name="Huyện Đăk Đoa", CityId=23},
                new District(){Name="Huyện Đăk Pơ", CityId=23},
                new District(){Name="Huyện Đức Cơ", CityId=23},
                new District(){Name="Huyện Ia Grai", CityId=23},
                new District(){Name="Huyện Ia Pa", CityId=23},
                new District(){Name="Huyện K'Bang", CityId=23},
                new District(){Name="Huyện Kông Chro", CityId=23},
                new District(){Name="Huyện Krông Pa", CityId=23},
                new District(){Name="Huyện Mang Yang", CityId=23},
                new District(){Name="Huyện Phú Thiện", CityId=23},
                new District(){Name="Huyện Chư Pưh", CityId=23},
                // Hà Giang
                new District(){Name="Thành phố Hà Giang", CityId=24},
                new District(){Name="Huyện Bắc Mê", CityId=24},
                new District(){Name="Huyện Bắc Quang", CityId=24},
                new District(){Name="Huyện Đồng Văn", CityId=24},
                new District(){Name="Huyện Hoàng Su Phì", CityId=24},
                new District(){Name="Huyện Mèo Vạc", CityId=24},
                new District(){Name="Huyện Quản Bạ", CityId=24},
                new District(){Name="Huyện Quang Bình", CityId=24},
                new District(){Name="Huyện Vị Xuyên", CityId=24},
                new District(){Name="Huyện Xín Mần", CityId=24},
                new District(){Name="Huyện Yên Minh", CityId=24},
            };
            int length = districts.Count();
            for (int i = 0; i < length; i++)
            {
                districts[i].Id = i + 1;
            }
            List<Category> categories = new List<Category>
            {
                new Category() {Id=1, Name="Đồ chơi cho trẻ sơ sinh", Description="Bé", ParentCategoryId=null, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Category() {Id=2, Name="Đồ chơi thông minh", Description="Bé", ParentCategoryId=null, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Category() {Id=3, Name="Đồ chơi xếp hình - lắp ráp", Description="Bé", ParentCategoryId=1, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Category() {Id=4, Name="Đồ chơi mô hình - điều khiển", Description="Bé", ParentCategoryId=1, CreatedBy="Admin", CreatedDate=DateTime.Now},


            };
            string c1 = "Món đồ chơi tạo điều kiện cho con khám phá các giác quan sớm, món đồ chơi này sẽ khiến bé thích thú bởi âm thanh sống động và vui nhộn. Mẹ có thể gắn vào cũi, nôi, hoặc thậm chí là xe đẩy cho con, cùng bé khám phá món đồ chơi này mẹ nhé.";


            List<Product> products = new List<Product>()
            {
                // đồ chs xếp hình
                new Product(){Id=1,ProductName="Thú bông voi con", Summary= c1, Price= 1100000, Quantity= 35, Description= d, CategoryId=3, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=2,ProductName="Đồ chơi thổi bóng hình gấu nâu 2023A", Summary= c1, Price= 1670000, Quantity= 35, Description= d, CategoryId=3, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=3,ProductName="Đồ chơi thổi bong bóng", Summary= c1, Price= 760000, Quantity= 35, Description= d, CategoryId=3, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=4,ProductName="Đồ chơi đất nặn 8 màu 100g", Summary= c1, Price= 820000, Quantity= 35, Description= d, CategoryId=3, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=5,ProductName="Kệ chữ A xúc xắc Sato", Summary= c1, Price= 870000, Quantity= 35, Description= d, CategoryId=3, CreatedBy="Admin", CreatedDate=DateTime.Now},
                
                

                // đồ chs thông minh
                new Product(){Id=6,ProductName="mothercare - Lục lạc hình voi", Summary= c1, Price= 4340000, Quantity= 35, Description= d, CategoryId=2, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=7,ProductName="Bộ đồ chơi vận động liên hoàn", Summary= c1, Price= 2550000, Quantity= 35, Description= d, CategoryId=2, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=8,ProductName="đồ chơi sắp xếp hình dạng bằng gồ ", Summary= c1, Price= 3860000, Quantity= 35, Description= d, CategoryId=2, CreatedBy="Admin", CreatedDate=DateTime.Now},
                

                // lắp rap

                new Product(){Id=9,ProductName="sư tử bập bênh ", Summary= c1, Price= 4340000, Quantity= 35, Description= d, CategoryId=1, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=10,ProductName="Gấu bông lovable bear lớn ", Summary= c1, Price= 6550000, Quantity= 35, Description= d, CategoryId=1, CreatedBy="Admin", CreatedDate=DateTime.Now},
                
                

                // Diêu khien
                new Product(){Id=11,ProductName="Set 3 lục lạc lovable bear ", Summary= c1, Price= 4340000, Quantity= 35, Description= d, CategoryId=4, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=12,ProductName="Gấu nhồi bông lovable bear ", Summary= c1, Price= 6550000, Quantity= 35, Description= d, CategoryId=4, CreatedBy="Admin", CreatedDate=DateTime.Now},
                new Product(){Id=13,ProductName="Treo nôi phát ra nhạc lovable bear ", Summary= c1, Price= 7860000, Quantity= 35, Description= d, CategoryId=4, CreatedBy="Admin", CreatedDate=DateTime.Now}

            };
            List<ProductImage> productImages = new List<ProductImage>()
            {
                // Casio
                new ProductImage() {Id=1,FileName = "ban-bi-lac-da-bong.jpg", ProductId= 1},
                new ProductImage() {Id=2,FileName = "ban-bi-lac-da-bong.jpg", ProductId= 1},
                new ProductImage() {Id=3,FileName = "ban-bi-lac-da-bong.jpg", ProductId= 1},
                new ProductImage() {Id=4,FileName = "bo-roi-5-ngon-tay-hinh-vit.jpg", ProductId= 2},
                new ProductImage() {Id=5,FileName = "bo-roi-5-ngon-tay-hinh-vit.jpg", ProductId= 2},
                new ProductImage() {Id=6,FileName = "bo-roi-5-ngon-tay-hinh-vit.jpg", ProductId= 2},
                new ProductImage() {Id=7,FileName = "do-choi-con-bay.jpg", ProductId= 3},
                new ProductImage() {Id=8,FileName = "do-choi-con-bay.jpg", ProductId= 3},
                new ProductImage() {Id=9,FileName = "do-choi-con-bay.jpg", ProductId= 3},
                new ProductImage() {Id=10,FileName = "do-choi-cot-do.jpg", ProductId= 4},
                new ProductImage() {Id=11,FileName = "do-choi-cot-do.jpg", ProductId= 4},
                new ProductImage() {Id=12,FileName = "do-choi-cot-do.jpg", ProductId= 4},
                new ProductImage() {Id=13,FileName = "do-choi-cot-trang.jpg", ProductId= 5},
                new ProductImage() {Id=14,FileName = "do-choi-cot-trang.jpg", ProductId= 5},
                new ProductImage() {Id=15,FileName = "do-choi-chu-cua-hermit-sieu-quay-1.jpg", ProductId= 5},
                new ProductImage() {Id=16,FileName = "do-choi-chu-cua-hermit-sieu-quay-1.jpg", ProductId= 6},
                new ProductImage() {Id=17,FileName = "do-choi-chu-cua-hermit-sieu-quay-1.jpg", ProductId= 6},
                new ProductImage() {Id=18,FileName = "do-choi-ga-con-phat-sang-co-nhac-4.jpg", ProductId= 6},
                new ProductImage() {Id=19,FileName = "do-choi-ga-con-phat-sang-co-nhac-4.jpg", ProductId= 7},
                new ProductImage() {Id=20,FileName = "do-choi-ga-con-phat-sang-co-nhac-4.jpg", ProductId= 7},
                new ProductImage() {Id=21,FileName = "do-choi-ga-con-phat-sang-co-nhac-4.jpg", ProductId= 7},
                new ProductImage() {Id=22,FileName = "do-choi-nimo-cau-ca-1.jpg", ProductId= 8},
                new ProductImage() {Id=23,FileName = "do-choi-nimo-cau-ca-1.jpg", ProductId= 8},
                new ProductImage() {Id=24,FileName = "do-choi-nimo-o-to-cho-be-1.jpg", ProductId= 8},
                new ProductImage() {Id=25,FileName = "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", ProductId= 9},
                new ProductImage() {Id=26,FileName = "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", ProductId= 9},
                new ProductImage() {Id=27,FileName = "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", ProductId= 9},
                new ProductImage() {Id=28,FileName = "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", ProductId= 10},
                new ProductImage() {Id=29,FileName = "do-choi-nimo-xuc-xac-cho-be-test-moi.jpg", ProductId= 10},
                new ProductImage() {Id=30,FileName = "do-choi-xe-day-hinh-thu-lac-lu-6.jpg", ProductId= 10},
                new ProductImage() {Id=31,FileName = "rau-con-mau-xanh-do.jpg", ProductId= 11},
                new ProductImage() {Id=32,FileName = "rau-con-mau-xanh-do.jpg", ProductId= 11},
                new ProductImage() {Id=33,FileName = "rau-con-mau-xanh-do.jpg", ProductId= 11},
                new ProductImage() {Id=34,FileName = "robot-nm19-62-n608a-trang-cam-120307.jpg", ProductId= 12},
                new ProductImage() {Id=35,FileName = "robot-nm19-62-n608a-trang-cam-120307.jpg", ProductId= 12},
                new ProductImage() {Id=36,FileName = "robot-nm19-62-n608a-trang-cam-120307.jpg", ProductId= 12},
                new ProductImage() {Id=37,FileName = "vit-con-abc-2.jpg", ProductId= 13},
                new ProductImage() {Id=38,FileName = "vit-con-abc-2.jpg", ProductId= 13},
                new ProductImage() {Id=39,FileName = "vit-con-abc-2.jpg", ProductId= 13},

            };
            Post ps = new Post();
            ps.Id = 1;
            ps.Title = "Chào mừng quý khách hàng đã đến với Tiemdochoi.vn!";
            ps.ShortDescription = "Mô tả test";
            ps.Content = "Tiệm đồ chơi được biết đến là cửa hàng bán đồ chơi an toàn cho trẻ em đồng thời bán với giá cả hợp lý, là cửa hàng chuyên bán sỉ, bán lẻ các sản phẩm đồ chơi cao cấp cho các bé từ 1 đến 7 tuổi.\r\n\r\n  \r\n\r\n \r\n\r\nChúng tôi làm việc với phương châm vì con yêu của bạn nên mỗi sản phẩm sẽ luôn đảm bảo:\r\n- Những đồ chơi tại cửa hàng Chibica Shop đang bán đều được nhập từ các nhà sản xuất có uy tín, nguyên liệu, chất liệu tạo ra những món đồ chơi, đồ dùng rất an toàn cho làn da của bé, không gây hại hay làm tổn hại đến hệ hô hấp của con mà nó còn giúp cho trẻ phát triển kỹ năng tư duy và óc sáng tạo.\r\n- Những sản phẩm của chúng tôi được lựa chọn tính toán kỹ lưỡng để bé có được nhiều món đồ chơi tốt mà bố mẹ cũng không quá đau ví tiền của mình.\r\n- Cửa hàng chúng tôi cũng cung cấp rất đa dạng về chủng loại và mẫu mã từ đồ chơi bằng gỗ, đồ chơi bằng nhựa an toàn, các món đồ chơi kích thích trí tuệ và mang tính giáo dục cho bé như: bộ đồ chơi rút gỗ, bộ bàn tính đa năng, bộ giáo cụ hình học, bộ thẻ học thông minh 16 chủ đề… hay các món đồ tăng cường tự lập cho bé như: bộ đồ chơi nấu ăn kitchen, bộ đồ chơi nhà bếp 31 chi tiết... và rất nhiều bộ sản phẩm khác có tính công nghệ và nghề nghiệp giúp trẻ phát triển năng động ngay từ nhỏ.\r\n\r\n \r\n\r\n\r\n \r\n\r\n \r\n\r\n Hình ảnh bộ đồ chơi được làm từ chất liệu an toàn cho bé\r\n\r\n\r\n\r\nVới đội ngũ nhân viên làm việc chuyên nghiệp và nhiệt tình quý phụ huynh sẽ hài lòng và yên tâm hơn khi lựa chọn các sản phẩm đồ chơi, đồ dùng trẻ em tại hệ thống cửa hầng Chibica Shop. Cùng với kinh nghiệm làm việc trên 6 năm bán hàng, cửa hàng Chibica Shop đang là lựa chọn thông minh cho các bâc phụ huynh có con em nhỏ. Bởi, trên thị trường đang có rất nhiều sản phẩm đồ chơi được bày bán và chúng tôi khuyên các bậc phụ huynh nên lựa chọn những sản phẩm uy tín và chất lượng tốt nhất theo sở thích và tính cách của trẻ nhỏ, để trẻ có thể phát triển toàn diện trí tuệ và óc sáng tạo của mình.";
            ps.CreatedDate = DateTime.Now;
            ps.CreatedBy = "Admin";
            modelBuilder.Entity<City>().HasData(citys);
            modelBuilder.Entity<District>().HasData(districts);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductImage>().HasData(productImages);
            modelBuilder.Entity<Post>().HasData(ps);
        }
    }
}

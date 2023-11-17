namespace BanDochoi.Web.Models.Enums
{
    public enum Status
    {
        Unprogressed, // 0 chưa xử lý
        Confirmed, // 1 đã xác nhận
        Shipping, // 2 đã giao hàng
        Success, // 3 thành công
        Canceled // 4 thất bại
    }
}

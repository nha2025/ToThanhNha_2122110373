namespace ToThanhNha_2122110373.Model
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        // Khóa ngoại tới bảng Orders
        public int OrderID { get; set; }
        public Order? Order { get; set; } // Đảm bảo nullable để tránh lỗi

        // Khóa ngoại tới bảng Products
        public int ProductID { get; set; }
        public Product? Product { get; set; } // Đảm bảo nullable để tránh lỗi

        public int Quantity { get; set; }
    }
}

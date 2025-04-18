using System.ComponentModel.DataAnnotations.Schema;

namespace ToThanhNha_2122110373.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; } // ✅ Cho phép null ở đây
    }
}

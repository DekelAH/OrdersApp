using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Core.Entities
{
    public class Order
    {
        #region Properties

        [Key]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Order Number can't be blank")]
        [RegularExpression(@"^(?i)ORD_\d{4}_\d+$", ErrorMessage = "Order Number must start with ORD following by _ + 4 digits following by _ + 1 digit")]
        public string? OrderNumber { get; set; }

        [Required(ErrorMessage = "Customer Name can't be blank")]
        [StringLength(50, ErrorMessage = "The Customer Name field must not exceed 50 characters")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Order Date can't be blank")]
        public DateTime OrderDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The Total Amount field must be a positive number")]
        public decimal TotalAmount { get; set; }

        #endregion
    }
}

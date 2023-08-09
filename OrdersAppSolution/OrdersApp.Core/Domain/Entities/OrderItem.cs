using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace OrdersApp.Core.Domain.Entities
{
    public class OrderItem
    {
        #region Properties

        [Key]
        public Guid OrderItemID { get; set; }

        [Required(ErrorMessage = "OrderID can't be blank")]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Product Name can't be blank")]
        [StringLength(50, ErrorMessage = "The Product Name field must not exceed 50 characters.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Name can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity has to have a positive value")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit Price can't be blank")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit Price has to have a positive value")]
        public double? UnitPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total Price has to have a positive value")]
        public double? TotalPrice { get; set; }

        #endregion
    }
}

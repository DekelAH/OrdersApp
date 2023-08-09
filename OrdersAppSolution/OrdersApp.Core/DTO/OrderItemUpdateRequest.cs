using OrdersApp.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Core.DTO
{
    public class OrderItemUpdateRequest
    {
        #region Properties

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

        #region Methods

        public OrderItem ToOrderItem()
        {
            return new OrderItem()
            {
                OrderItemID = OrderItemID,
                OrderID = OrderID,
                ProductName = ProductName,
                Quantity = Quantity,
                UnitPrice = UnitPrice
            };
        }

        #endregion
    }
}

using OrdersApp.Core.Domain.Entities;

namespace OrdersApp.Core.DTO
{
    public class OrderResponse
    {
        #region Properties

        public Guid OrderID { get; set; }

        public string? OrderNumber { get; set; }

        public string? CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        public List<OrderItemResponse> OrderItems { get; set; } = new List<OrderItemResponse>();

        #endregion

        #region Methods

        public Order ToOrder()
        {
            return new Order()
            {
                OrderID = OrderID,
                OrderNumber = OrderNumber,
                CustomerName = CustomerName,
                OrderDate = OrderDate,
                TotalAmount = TotalAmount
            };
        }

        #endregion
    }

    public static class OrderExtensionMethods
    {
        #region Methods

        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse()
            {
                OrderID = order.OrderID,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount
            };
        }

        #endregion
    }
}

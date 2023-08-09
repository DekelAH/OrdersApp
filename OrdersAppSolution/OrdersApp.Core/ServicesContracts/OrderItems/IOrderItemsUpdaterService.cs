using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.OrderItems
{
    public interface IOrderItemsUpdaterService
    {
        #region Methods

        /// <summary>
        /// Updating existing OrderItem object
        /// </summary>
        /// <param name="orderItemUpdateRequest">new OrderItem object to update</param>
        /// <returns>Updated OrderItem object</returns>
        Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest);

        #endregion
    }
}

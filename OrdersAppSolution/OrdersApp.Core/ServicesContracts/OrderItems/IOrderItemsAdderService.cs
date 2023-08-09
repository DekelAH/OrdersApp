using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.OrderItems
{
    public interface IOrderItemsAdderService
    {
        #region Methods

        /// <summary>
        /// Sending new OrderItem object to OrderItemsRepository
        /// </summary>
        /// <param name="newOrderItemAddRequest">new OrderItem object to add</param>
        /// <returns>New added OrderItem object</returns>
        Task<OrderItemResponse> AddNewOrderItem(OrderItemAddRequest newOrderItemAddRequest);

        #endregion
    }
}

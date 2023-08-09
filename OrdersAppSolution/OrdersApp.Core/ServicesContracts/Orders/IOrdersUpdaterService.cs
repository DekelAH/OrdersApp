using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.Orders
{
    public interface IOrdersUpdaterService
    {
        #region Methods

        /// <summary>
        /// Updating existing Order object
        /// </summary>
        /// <param name="orderToUpdate">new Order object to add</param>
        /// <returns>Updated Order object</returns>
        Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderToUpdate);

        #endregion
    }
}

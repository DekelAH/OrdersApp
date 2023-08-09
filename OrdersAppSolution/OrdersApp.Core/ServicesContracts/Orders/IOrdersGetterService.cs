using OrdersApp.Core.Domain.Entities;

namespace OrdersApp.Core.ServicesContracts.Orders
{
    public interface IOrdersGetterService
    {
        #region Methods

        /// <summary>
        /// Get all the orders from Orders repository
        /// </summary>
        /// <returns>List of all the orders</returns>
        Task<List<Order>> GetAllOrders();

        /// <summary>
        /// Get specific Order object by OrderID
        /// </summary>
        /// <param name="orderID">OrderID to search</param>
        /// <returns>Matching Order object</returns>
        Task<Order?> GetOrderById(Guid orderID);

        #endregion
    }
}

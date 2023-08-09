using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.Orders
{
    public interface IOrdersGetterService
    {
        #region Methods

        /// <summary>
        /// Get all the orders from Orders repository
        /// </summary>
        /// <returns>List of all the orders</returns>
        Task<List<OrderResponse>> GetAllOrders();

        /// <summary>
        /// Get specific Order object by OrderID
        /// </summary>
        /// <param name="orderID">OrderID to search</param>
        /// <returns>Matching Order object</returns>
        Task<OrderResponse?> GetOrderById(Guid orderID);

        #endregion
    }
}

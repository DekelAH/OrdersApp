using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.OrderItems
{
    public interface IOrderItemsGetterService
    {
        #region Methods

        /// <summary>
        /// Get all the OrderItems from database
        /// </summary>
        /// <returns>List of all the OrderItems</returns>
        Task<List<OrderItemResponse>> GetAllOrderItems();

        /// <summary>
        /// Get specific OrderItem object by orderID
        /// </summary>
        /// <param name="orderID">orderID to search</param>
        /// <returns>Matching OrderItem object</returns>
        Task<OrderItemResponse?> GetOrderItemById(Guid orderID);

        /// <summary>
        /// Get all the matching OrderItems by orderID
        /// </summary>
        /// <param name="orderID">orderID to search</param>
        /// <returns>List of all matching OrderItem objects</returns>
        Task<List<OrderItemResponse>> GetMatchingOrderItemsByOrderID(Guid orderID);

        #endregion
    }
}

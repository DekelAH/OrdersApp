using OrdersApp.Core.Domain.Entities;

namespace OrdersApp.Core.Domain.RepositoryContracts
{
    public interface IOrdersRepository
    {
        #region Methods

        /// <summary>
        /// Get all the orders from database
        /// </summary>
        /// <returns>List of all the orders</returns>
        Task<List<Order>> GetAllOrders();

        /// <summary>
        /// Get specific Order object by OrderID
        /// </summary>
        /// <param name="orderID">OrderID to search</param>
        /// <returns>Matching Order object</returns>
        Task<Order?> GetOrderById(Guid orderID);

        /// <summary>
        /// Adding new Order object to the database
        /// </summary>
        /// <param name="newOrder">new Order object to add</param>
        /// <returns>New added Order object</returns>
        Task<Order> AddNewOrder(Order newOrder);

        /// <summary>
        /// Updating existing Order object
        /// </summary>
        /// <param name="orderToUpdate">new Order object to add</param>
        /// <returns>Updated Order object</returns>
        Task<Order> UpdateOrder(Order orderToUpdate);

        /// <summary>
        /// Deleting an existing Order object by orderID
        /// </summary>
        /// <param name="orderID">orderID to search</param>
        /// <returns>True if deleted successfuly or false if not</returns>
        Task<bool> DeleteOrder(Guid orderID);

        #endregion
    }
}

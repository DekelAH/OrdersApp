﻿using OrdersApp.Core.Domain.Entities;

namespace OrdersApp.Core.Domain.RepositoryContracts
{
    public interface IOrderItemsRepository
    {
        #region Methods

        /// <summary>
        /// Get all the OrderItems from database
        /// </summary>
        /// <returns>List of all the OrderItems</returns>
        Task<List<OrderItem>> GetOrderItems();

        /// <summary>
        /// Get specific OrderItem object by orderItemID
        /// </summary>
        /// <param name="orderItemID">OrderID to search</param>
        /// <returns>Matching OrderItem object</returns>
        Task<OrderItem> GetOrderItemById(Guid orderItemID);

        /// <summary>
        /// Get all the matching OrderItems by orderID
        /// </summary>
        /// <param name="orderID">orderID to search</param>
        /// <returns>List of all matching OrderItem objects</returns>
        Task<List<OrderItem>> GetMatchingOrderItemsByOrderID(Guid orderID);

        /// <summary>
        /// Adding new OrderItem object to the database
        /// </summary>
        /// <param name="newOrderItem">new OrderItem object to add</param>
        /// <returns>New added OrderItem object</returns>
        Task<OrderItem> AddNewOrderItem(Order newOrderItem);

        /// <summary>
        /// Updating existing OrderItem object
        /// </summary>
        /// <param name="orderItemToUpdate">new OrderItem object to add</param>
        /// <returns>Updated OrderItem object</returns>
        Task<Order> UpdateOrderItem(Order orderItemToUpdate);

        /// <summary>
        /// Deleting an existing OrderItem object by orderItemID
        /// </summary>
        /// <param name="orderItemID">orderItemID to search</param>
        /// <returns>True if deleted successfuly or false if not</returns>
        Task<bool> DeleteOrderItem(Guid orderItemID);

        #endregion
    }
}

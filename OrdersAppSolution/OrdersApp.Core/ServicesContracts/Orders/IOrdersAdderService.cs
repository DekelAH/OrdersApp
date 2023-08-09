using OrdersApp.Core.DTO;

namespace OrdersApp.Core.ServicesContracts.Orders
{
    public interface IOrdersAdderService
    {
        #region Methods

        /// <summary>
        /// Adding new Order object to the database
        /// </summary>
        /// <param name="newOrder">new Order object to add</param>
        /// <returns>New added Order object</returns>
        Task<OrderResponse> AddNewOrder(OrderAddRequest newOrder);

        #endregion
    }
}

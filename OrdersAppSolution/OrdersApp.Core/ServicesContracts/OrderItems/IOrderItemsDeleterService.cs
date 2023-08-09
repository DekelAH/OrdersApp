namespace OrdersApp.Core.ServicesContracts.OrderItems
{
    public interface IOrderItemsDeleterService
    {
        #region Methods

        /// <summary>
        /// Deleting an existing OrderItem object by orderItemID
        /// </summary>
        /// <param name="orderItemID">orderItemID to search</param>
        /// <returns>True if deleted successfuly or false if not</returns>
        Task<bool> DeleteOrderItem(Guid orderItemID);

        #endregion
    }
}

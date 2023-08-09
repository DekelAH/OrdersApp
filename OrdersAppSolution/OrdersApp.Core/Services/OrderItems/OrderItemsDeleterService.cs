using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.ServicesContracts.OrderItems;

namespace OrdersApp.Core.Services.OrderItems
{
    public class OrderItemsDeleterService : IOrderItemsDeleterService
    {
        #region Fields

        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsDeleterService> _logger;

        #endregion

        #region Ctors

        public OrderItemsDeleterService
            (
            IOrderItemsRepository orderItemsRepository,
            ILogger<OrderItemsDeleterService> logger
            )
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<bool> DeleteOrderItem(Guid orderItemID)
        {
            _logger.LogInformation("Searching matching OrderItem to delete...");
            var matchingOrderItem = await _orderItemsRepository.GetOrderItemById(orderItemID);
            if (matchingOrderItem == null)
            {
                _logger.LogInformation($"Order with given id: {orderItemID} has not been found.");
                return false;
            }

            await _orderItemsRepository.DeleteOrderItem(orderItemID);
            _logger.LogInformation($"OrderItem with given id: {matchingOrderItem.OrderItemID} deleted successfuly");
            return true;
        }

        #endregion
    }
}

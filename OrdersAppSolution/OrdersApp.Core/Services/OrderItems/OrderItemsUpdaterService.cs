using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.OrderItems;

namespace OrdersApp.Core.Services.OrderItems
{
    public class OrderItemsUpdaterService : IOrderItemsUpdaterService
    {
        #region Fields

        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsUpdaterService> _logger;

        #endregion

        #region Ctors

        public OrderItemsUpdaterService
            (
            IOrderItemsRepository orderItemsRepository,
            ILogger<OrderItemsUpdaterService> logger
            )
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            _logger.LogInformation("Updating orderItem...");

            var orderItem = orderItemUpdateRequest.ToOrderItem();
            await _orderItemsRepository.UpdateOrderItem(orderItem);
            var updatedOrderItemResponse = orderItem.ToOrderItemResponse();

            _logger.LogInformation($"OrderItem: {orderItem.OrderItemID} updated successfuly.");
            return updatedOrderItemResponse;
        }

        #endregion
    }
}

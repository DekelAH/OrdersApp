using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.OrderItems;

namespace OrdersApp.Core.Services.OrderItems
{
    public class OrderItemsAdderService : IOrderItemsAdderService
    {
        #region Fields

        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsAdderService> _logger;

        #endregion

        #region Ctors

        public OrderItemsAdderService
            (
            IOrderItemsRepository orderItemsRepository,
            ILogger<OrderItemsAdderService> logger
            )
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<OrderItemResponse> AddNewOrderItem(OrderItemAddRequest newOrderItemAddRequest)
        {
            _logger.LogInformation($"Sending newOrderItem to add to the repository ...");

            var orderItem = newOrderItemAddRequest.ToOrderItem();
            orderItem.OrderItemID = Guid.NewGuid();

            await _orderItemsRepository.AddNewOrderItem(orderItem);
            var orderItemResponse = orderItem.ToOrderItemResponse();

            _logger.LogInformation($"OrderItem: {orderItem.OrderItemID} added successfuly");

            return orderItemResponse;
        }

        #endregion
    }
}

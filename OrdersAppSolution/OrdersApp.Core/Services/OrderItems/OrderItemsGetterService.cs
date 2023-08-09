using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.OrderItems;

namespace OrdersApp.Core.Services.OrderItems
{
    public class OrderItemsGetterService : IOrderItemsGetterService
    {
        #region Fields

        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsGetterService> _logger;

        #endregion

        #region Ctors

        public OrderItemsGetterService
            (
            IOrderItemsRepository orderItemsRepository,
            ILogger<OrderItemsGetterService> logger
            )
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<List<OrderItemResponse>> GetAllOrderItems()
        {
            _logger.LogInformation("Getting all OrderItems ...");

            var allOrderItems = await _orderItemsRepository.GetAllOrderItems();
            var allOrderItemsResponse = allOrderItems.Select(order => order.ToOrderItemResponse()).ToList();

            _logger.LogInformation($"Retrieved {allOrderItemsResponse.Count} OrderItems");
            return allOrderItemsResponse;
        }

        public async Task<OrderItemResponse?> GetOrderItemById(Guid orderID)
        {
            _logger.LogInformation($"Searching OrderItem by OrderID: {orderID} ...");

            var orderItem = await _orderItemsRepository.GetOrderItemById(orderID);
            if (orderItem == null)
            {
                _logger.LogInformation($"OrderItem with the given OrderID {orderID} is not found...");
                return null;
            }
            var orderItemResponse = orderItem.ToOrderItemResponse();
            return orderItemResponse;
        }

        public async Task<List<OrderItemResponse>> GetMatchingOrderItemsByOrderID(Guid orderID)
        {
            _logger.LogInformation($"Searching OrderItems by OrderID: {orderID} ...");

            var orderItems = await _orderItemsRepository.GetMatchingOrderItemsByOrderID(orderID);
            var matchingOrderItemsResponse = orderItems.Select(orderItem => orderItem.ToOrderItemResponse()).ToList();

            _logger.LogInformation($"Retrieved {matchingOrderItemsResponse.Count} OrderItems");

            return matchingOrderItemsResponse;
        }

        #endregion
    }
}

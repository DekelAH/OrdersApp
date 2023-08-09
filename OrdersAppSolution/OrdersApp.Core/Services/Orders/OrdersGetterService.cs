using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.OrderItems;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services.Orders
{
    public class OrdersGetterService : IOrdersGetterService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsGetterService _orderItemGetterService;
        private readonly ILogger<OrdersGetterService> _logger;

        #endregion

        #region Ctors

        public OrdersGetterService
            (
            IOrdersRepository ordersRepository,
            ILogger<OrdersGetterService> logger,
            IOrderItemsGetterService orderItemGetterService
            )
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
            _orderItemGetterService = orderItemGetterService;
        }

        #endregion

        #region Methods

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            _logger.LogInformation("Getting all orders...");
            var allOrders = await _ordersRepository.GetAllOrders();
            var allOrdersResponse = allOrders.Select(order => order.ToOrderResponse()).ToList();
            foreach (var orderResponse in allOrdersResponse)
            {
                orderResponse.OrderItems = await _orderItemGetterService.GetMatchingOrderItemsByOrderID(orderResponse.OrderID);
            }
            _logger.LogInformation($"Retrieved {allOrders.Count} orders");

            return allOrdersResponse;
        }

        public async Task<OrderResponse?> GetOrderById(Guid orderID)
        {
            _logger.LogInformation($"Getting Order by orderID: {orderID}...");
            var matchingOrder = await _ordersRepository.GetOrderById(orderID);
            var matchingOrderResponse = matchingOrder.ToOrderResponse();
            matchingOrderResponse.OrderItems = await _orderItemGetterService.GetMatchingOrderItemsByOrderID(orderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with orderID: {orderID} not found.");
            }
            else
            {
                _logger.LogInformation($"Order with orderID: {orderID} found successfuly.");
            }

            return matchingOrderResponse;
        }

        #endregion
    }
}

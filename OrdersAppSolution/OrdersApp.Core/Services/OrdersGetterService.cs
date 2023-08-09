using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services
{
    public class OrdersGetterService : IOrdersGetterService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersGetterService> _logger;

        #endregion

        #region Ctors

        public OrdersGetterService(IOrdersRepository ordersRepository, ILogger<OrdersGetterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<List<Order>> GetAllOrders()
        {
            _logger.LogInformation("Getting all orders...");
            var allOrders = await _ordersRepository.GetAllOrders();
            _logger.LogInformation($"Retrieved {allOrders.Count} orders");

            return allOrders;
        }

        public async Task<Order?> GetOrderById(Guid orderID)
        {
            _logger.LogInformation($"Getting Order by orderID: {orderID}...");
            var matchingOrder = await _ordersRepository.GetOrderById(orderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with orderID: {orderID} not found.");
            }
            else
            {
                _logger.LogInformation($"Order with orderID: {orderID} found successfuly.");
            }

            return matchingOrder;
        }

        #endregion
    }
}

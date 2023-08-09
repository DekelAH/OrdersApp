using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services
{
    public class OrdersDeleterService : IOrdersDeleterService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersDeleterService> _logger;

        #endregion

        #region Ctors

        public OrdersDeleterService(IOrdersRepository ordersRepository, ILogger<OrdersDeleterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<bool> DeleteOrder(Guid orderID)
        {
            _logger.LogInformation("Searching matching Order to delete...");
            var matchingOrder = await _ordersRepository.GetOrderById(orderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with given id: {orderID} has not been found.");
                return false;
            }

            await _ordersRepository.DeleteOrder(orderID);
            _logger.LogInformation($"Order with given id: {matchingOrder.OrderID} deleted successfuly");
            return true;
        }

        #endregion
    }
}

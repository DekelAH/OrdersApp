using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services
{
    public class OrdersUpdaterService : IOrdersUpdaterService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersUpdaterService> _logger;

        #endregion

        #region Ctors

        public OrdersUpdaterService(IOrdersRepository ordersRepository, ILogger<OrdersUpdaterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<Order> UpdateOrder(Order orderToUpdate)
        {
            _logger.LogInformation("Updating order...");
            var matchingOrder = await _ordersRepository.GetOrderById(orderToUpdate.OrderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with id: {orderToUpdate.OrderID} is not found.");
                return orderToUpdate;
            }

            matchingOrder.OrderNumber = orderToUpdate.OrderNumber;
            matchingOrder.OrderDate = orderToUpdate.OrderDate;
            matchingOrder.CustomerName = orderToUpdate.CustomerName;
            matchingOrder.TotalAmount = orderToUpdate.TotalAmount;
            await _ordersRepository.UpdateOrder(matchingOrder);

            _logger.LogInformation($"Order with id: {matchingOrder.OrderID} updated successfuly.");
            return matchingOrder;
        }

        #endregion
    }
}

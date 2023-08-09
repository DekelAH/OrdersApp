using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services
{
    public class OrdersAdderService : IOrdersAdderService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersAdderService> _logger;

        #endregion

        #region Ctors

        public OrdersAdderService(IOrdersRepository ordersRepository, ILogger<OrdersAdderService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<Order> AddNewOrder(Order newOrder)
        {
            _logger.LogInformation("Adding new Order...");
            await _ordersRepository.AddNewOrder(newOrder);
            _logger.LogInformation($"New Order: {newOrder} added successfuly");
            return newOrder;
        }

        #endregion
    }
}

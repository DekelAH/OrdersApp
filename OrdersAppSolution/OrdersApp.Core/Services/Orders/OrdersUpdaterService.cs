using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services.Orders
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

        public async Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderToUpdate)
        {
            _logger.LogInformation("Updating order...");

            var order = orderToUpdate.ToOrder();
            var updatedOrder = await _ordersRepository.UpdateOrder(order);
            var orderResponse = updatedOrder.ToOrderResponse();

            _logger.LogInformation($"Order with id: {orderResponse.OrderID} updated successfuly.");
            return orderResponse;
        }

        #endregion
    }
}

using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.Core.Services.Orders
{
    public class OrdersAdderService : IOrdersAdderService
    {
        #region Fields

        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrdersAdderService> _logger;

        #endregion

        #region Ctors

        public OrdersAdderService
            (
            IOrdersRepository ordersRepository,
            ILogger<OrdersAdderService> logger,
            IOrderItemsRepository orderItemsRepository
            )
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
            _orderItemsRepository = orderItemsRepository;
        }

        #endregion

        #region Methods

        public async Task<OrderResponse> AddNewOrder(OrderAddRequest newOrderAddRequest)
        {
            _logger.LogInformation("Adding new Order...");
            var newOrder = newOrderAddRequest.ToOrder();
            newOrder.OrderID = Guid.NewGuid();

            await _ordersRepository.AddNewOrder(newOrder);
            var addedOrderResponse = newOrder.ToOrderResponse();

            foreach (var orderItemResponse in addedOrderResponse.OrderItems)
            {
                var orderItem = orderItemResponse.ToOrderItem();
                orderItem.OrderItemID = Guid.NewGuid();
                orderItem.OrderID = addedOrderResponse.OrderID;

                await _orderItemsRepository.AddNewOrderItem(orderItem);
                addedOrderResponse.OrderItems.Add(orderItemResponse);
            }

            _logger.LogInformation($"New Order: {newOrder} added successfuly");
            return addedOrderResponse;
        }

        #endregion
    }
}

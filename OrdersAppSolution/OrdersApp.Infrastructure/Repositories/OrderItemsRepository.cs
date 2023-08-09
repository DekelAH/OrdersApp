using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Infrastructure.DataBaseContext;

namespace OrdersApp.Infrastructure.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        #region Fields

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<OrderItemsRepository> _logger;

        #endregion

        #region Ctors

        public OrderItemsRepository(ApplicationDbContext applicationDbContext, ILogger<OrderItemsRepository> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<OrderItem> AddNewOrderItem(OrderItem newOrderItem)
        {
            _logger.LogInformation("Adding new OrderItem...");
            await _applicationDbContext.OrderItems.AddAsync(newOrderItem);
            await _applicationDbContext.SaveChangesAsync();
            _logger.LogInformation($"New OrderItem: {newOrderItem} added successfuly");
            return newOrderItem;
        }

        public async Task<bool> DeleteOrderItem(Guid orderItemID)
        {
            _logger.LogInformation("Searching matching OrderItem to delete...");
            var matchingOrderItem = await _applicationDbContext.OrderItems.FindAsync(orderItemID);
            if (matchingOrderItem == null)
            {
                _logger.LogInformation($"OrderItem with given id: {orderItemID} has not been found.");
                return false;
            }

            _applicationDbContext.OrderItems.Remove(matchingOrderItem);
            await _applicationDbContext.SaveChangesAsync();
            _logger.LogInformation($"OrderItem with given id: {matchingOrderItem.OrderItemID} deleted successfuly");
            return true;
        }

        public async Task<List<OrderItem>> GetMatchingOrderItemsByOrderID(Guid orderID)
        {
            _logger.LogInformation("Searching matching OrderItems...");
            var matchingOrderItems = await _applicationDbContext.OrderItems.Where(orderItem => 
                                                                            orderItem.OrderID == orderID).ToListAsync();
            if(matchingOrderItems.Count == 0)
            {
                _logger.LogInformation("No matching OrderItems has been found.");
            }

            _logger.LogInformation($"{matchingOrderItems.Count} matching OrderItems has been found.");
            return matchingOrderItems;
        }

        public async Task<OrderItem?> GetOrderItemById(Guid orderItemID)
        {
            _logger.LogInformation($"Getting OrderItem by orderItemID: {orderItemID}...");
            var matchingOrderItem = await _applicationDbContext.OrderItems.FindAsync(orderItemID);
            if (matchingOrderItem == null)
            {
                _logger.LogInformation($"Order with orderID: {orderItemID} not found.");
            }
            else
            {
                _logger.LogInformation($"Order with orderID: {orderItemID} found successfuly.");
            }

            return matchingOrderItem;
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            _logger.LogInformation("Getting all orderItems...");
            var allOrderItems = await _applicationDbContext.OrderItems.OrderByDescending(orderItem =>
                                                                                    orderItem.ProductName).ToListAsync();
            _logger.LogInformation($"Retrieved {allOrderItems.Count} orderItems");

            return allOrderItems;
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItemToUpdate)
        {
            _logger.LogInformation("Updating orderItem...");
            var matchingOrderItem = await _applicationDbContext.OrderItems.FindAsync(orderItemToUpdate.OrderItemID);
            if (matchingOrderItem == null)
            {
                _logger.LogInformation($"OrderItem with id: {orderItemToUpdate.OrderItemID} is not found.");
                return orderItemToUpdate;
            }

            matchingOrderItem.OrderID = orderItemToUpdate.OrderID;
            matchingOrderItem.ProductName = orderItemToUpdate.ProductName;
            matchingOrderItem.Quantity = orderItemToUpdate.Quantity;
            matchingOrderItem.UnitPrice = orderItemToUpdate.UnitPrice;
            matchingOrderItem.TotalPrice = orderItemToUpdate.TotalPrice;
            await _applicationDbContext.SaveChangesAsync();

            _logger.LogInformation($"OrderItem with id: {matchingOrderItem.OrderItemID} updated successfuly.");
            return matchingOrderItem;
        }

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Infrastructure.DataBaseContext;

namespace OrdersApp.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        #region Fields

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<OrdersRepository> _logger;

        #endregion

        #region Ctors

        public OrdersRepository(ApplicationDbContext applicationDbContext, ILogger<OrdersRepository> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<Order> AddNewOrder(Order newOrder)
        {
            _logger.LogInformation("Adding new Order...");
            await _applicationDbContext.Orders.AddAsync(newOrder);
            await _applicationDbContext.SaveChangesAsync();
            _logger.LogInformation($"New Order: {newOrder} added successfuly");
            return newOrder;
        }

        public async Task<bool> DeleteOrder(Guid orderID)
        {
            _logger.LogInformation("Searching matching Order to delete...");
            var matchingOrder = await _applicationDbContext.Orders.FindAsync(orderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with given id: {orderID} has not been found.");
                return false;
            }

            _applicationDbContext.Orders.Remove(matchingOrder);
            await _applicationDbContext.SaveChangesAsync();
            _logger.LogInformation($"Order with given id: {matchingOrder.OrderID} deleted successfuly");
            return true;
        }

        public async Task<Order?> GetOrderById(Guid orderID)
        {
            _logger.LogInformation($"Getting Order by orderID: {orderID}...");
            var matchingOrder = await _applicationDbContext.Orders.FindAsync(orderID);
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

        public async Task<List<Order>> GetAllOrders()
        {
            _logger.LogInformation("Getting all orders...");
            var allOrders = await _applicationDbContext.Orders.OrderByDescending(order => order.OrderDate).ToListAsync();
            _logger.LogInformation($"Retrieved {allOrders.Count} orders");

            return allOrders;
        }

        public async Task<Order> UpdateOrder(Order orderToUpdate)
        {
            _logger.LogInformation("Updating order...");
            var matchingOrder = await _applicationDbContext.Orders.FindAsync(orderToUpdate.OrderID);
            if (matchingOrder == null)
            {
                _logger.LogInformation($"Order with id: {orderToUpdate.OrderID} is not found.");
                return orderToUpdate;
            }

            matchingOrder.OrderNumber = orderToUpdate.OrderNumber;
            matchingOrder.OrderDate = orderToUpdate.OrderDate;
            matchingOrder.CustomerName = orderToUpdate.CustomerName;
            matchingOrder.TotalAmount = orderToUpdate.TotalAmount;
            await _applicationDbContext.SaveChangesAsync();

            _logger.LogInformation($"Order with id: {matchingOrder.OrderID} updated successfuly.");
            return matchingOrder;
        }

        #endregion
    }
}

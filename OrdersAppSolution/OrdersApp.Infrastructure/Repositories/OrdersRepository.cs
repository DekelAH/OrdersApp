using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Domain.RepositoryContracts;
using OrdersApp.Infrastructure.DataBaseContext;

namespace OrdersApp.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        #region Fields

        private readonly ApplicationDbContext _applicationDbContext;

        #endregion

        #region Ctors

        public OrdersRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #endregion

        #region Methods

        public async Task<Order> AddNewOrder(Order newOrder)
        {
            await _applicationDbContext.Orders.AddAsync(newOrder);
            await _applicationDbContext.SaveChangesAsync();
            return newOrder;
        }

        public async Task<bool> DeleteOrder(Guid orderID)
        {
            var matchingOrder = await _applicationDbContext.Orders.FindAsync(orderID);
            if (matchingOrder == null)
            {
                return false;
            }

            _applicationDbContext.Orders.Remove(matchingOrder);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetOrderById(Guid orderID)
        {
            var matchingOrder = await _applicationDbContext.Orders.FindAsync(orderID);
            if (matchingOrder == null)
            {
                
            }

            return matchingOrder;
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

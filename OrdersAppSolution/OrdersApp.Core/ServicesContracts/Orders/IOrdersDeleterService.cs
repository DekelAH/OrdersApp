using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Core.ServicesContracts.Orders
{
    public interface IOrdersDeleterService
    {
        #region Methods

        /// <summary>
        /// Deleting an existing Order object by orderID
        /// </summary>
        /// <param name="orderID">orderID to search</param>
        /// <returns>True if deleted successfuly or false if not</returns>
        Task<bool> DeleteOrder(Guid orderID);

        #endregion
    }
}

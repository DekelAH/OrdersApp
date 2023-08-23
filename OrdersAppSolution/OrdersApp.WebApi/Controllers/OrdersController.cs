using Microsoft.AspNetCore.Mvc;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.DTO;
using OrdersApp.Core.ServicesContracts.Orders;

namespace OrdersApp.WebApi.Controllers
{
    public class OrdersController : CustomControllerBase
    {
        #region Fields

        private readonly IOrdersGetterService _ordersGetterService;
        private readonly IOrdersUpdaterService _ordersUpdaterService;
        private readonly IOrdersAdderService _ordersAdderService;
        private readonly IOrdersDeleterService _ordersDeleterService;

        private readonly ILogger<OrdersController> _logger;

        #endregion

        #region Ctors

        public OrdersController
            (
            IOrdersGetterService ordersGetterService,
            IOrdersUpdaterService ordersUpdaterService,
            IOrdersAdderService ordersAdderService,
            IOrdersDeleterService ordersDeleterService,
            ILogger<OrdersController> logger
            )
        {
            _ordersGetterService = ordersGetterService;
            _ordersUpdaterService = ordersUpdaterService;
            _ordersAdderService = ordersAdderService;
            _ordersDeleterService = ordersDeleterService;
            _logger = logger;
        }

        #endregion

        #region Action Methods

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            _logger.LogInformation("Getting all orders...");

            var allOrders = await _ordersGetterService.GetAllOrders();
            if (allOrders == null || allOrders.Count == 0)
            {
                return NotFound();
            }

            _logger.LogInformation($"Retrieved {allOrders.Count} orders successfuly.");
            return Ok(allOrders);
        }

        // GET: api/Orders/5
        [HttpGet("{orderID}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(Guid orderID)
        {
            _logger.LogInformation($"Searching Order: {orderID}...");

            OrderResponse? orderResponse = await _ordersGetterService.GetOrderById(orderID);
            if (orderResponse == null)
            {
                return Problem(detail: "Invalid orderID", statusCode: 404, title: "Order search");
            }

            _logger.LogInformation($"Order: {orderResponse.OrderID} retrieved successfuly.");
            return Ok(orderResponse);
        }

        // PUT: api/Orders/5
        [HttpPut("{orderID}")]
        public async Task<IActionResult> PutOrder(Guid orderID, OrderUpdateRequest orderUpdateRequest)
        {
            _logger.LogInformation($"Searching for matching Order to update ...");

            if (orderID != orderUpdateRequest.OrderID)
            {
                return BadRequest();
            }

            var matchingOrder = await _ordersGetterService.GetOrderById(orderID);
            if (matchingOrder == null)
            {
                return Problem(detail: "Invalid orderID", statusCode: 404, title: "Order search");
            }

            _logger.LogInformation($"Matching order found, updating Order: {matchingOrder.OrderID}...");

            var updatedOrderResponse = await _ordersUpdaterService.UpdateOrder(orderUpdateRequest);

            _logger.LogInformation($"Order: {updatedOrderResponse.OrderID} updated successfuly.");
            return Ok(updatedOrderResponse);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderAddRequest orderAddRequest)
        {
            _logger.LogInformation($"Adding new Order...");

            if (orderAddRequest == null)
            {
                return Problem(detail: "Invalid Order details.", statusCode: 400, title: "Add Order");
            }
            var addedOrderResponse = await _ordersAdderService.AddNewOrder(orderAddRequest);

            _logger.LogInformation($"Order: {addedOrderResponse.OrderID} added successfuly.");
            return CreatedAtAction("GetOrder", new { id = addedOrderResponse.OrderID }, addedOrderResponse);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{orderID}")]
        public async Task<IActionResult> DeleteOrder(Guid orderID)
        {
            _logger.LogInformation($"Searching matching Order to delete...");

            var matchingOrder = await _ordersGetterService.GetOrderById(orderID);
            if (matchingOrder == null)
            {
                return Problem(detail: "Invalid Order ID.", statusCode: 404, title: "Delete Order");
            }
            var isDeleted = await _ordersDeleterService.DeleteOrder(matchingOrder.OrderID);

            _logger.LogInformation($"Order: {matchingOrder.OrderID} deleted successfuly.");
            return Ok(isDeleted);
        }

        #endregion
    }
}

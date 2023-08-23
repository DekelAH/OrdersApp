using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Core.Domain.Entities;
using OrdersApp.Core.Identity;

namespace OrdersApp.Infrastructure.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        #region Fields

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        #endregion

        #region Ctors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public ApplicationDbContext()
        {

        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CreateOrderModelsData(modelBuilder);
            CreateOrderItemModelsData(modelBuilder);
        }

        private static void CreateOrderModelsData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order()
            {
                OrderID = Guid.Parse("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                OrderNumber = "ORD_0001",
                CustomerName = "Jane Mole",
                OrderDate = DateTime.Now,
                TotalAmount = 42.2,
            });
            modelBuilder.Entity<Order>().HasData(new Order()
            {
                OrderID = Guid.Parse("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                OrderNumber = "ORD_0002",
                CustomerName = "Chris Jankins",
                OrderDate = DateTime.Now,
                TotalAmount = 22.2,
            });
        }

        private static void CreateOrderItemModelsData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem()
            {
                OrderItemID = Guid.Parse("80192c06-c6da-4f14-acc5-5aaa944f0006"),
                ProductName = "Razor Keyboard",
                Quantity = 5000,
                UnitPrice = 8400,
                OrderID = Guid.Parse("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                TotalPrice = 42000000
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem()
            {
                OrderItemID = Guid.Parse("31143d81-5b90-4cf6-bcf6-13be124a8aba"),
                ProductName = "Razor Mouse",
                Quantity = 5000,
                UnitPrice = 2400,
                OrderID = Guid.Parse("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                TotalPrice = 12000000
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem()
            {
                OrderItemID = Guid.Parse("5d30db88-6ec9-49d3-ac09-b4a926fede2c"),
                ProductName = "Samsung PC Screen",
                Quantity = 1000,
                UnitPrice = 3400,
                OrderID = Guid.Parse("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                TotalPrice = 3400000
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem()
            {
                OrderItemID = Guid.Parse("b6f94083-1c2d-49ca-930b-bca3cc1ee53b"),
                ProductName = "HyperX Headphones",
                Quantity = 500,
                UnitPrice = 1400,
                OrderID = Guid.Parse("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                TotalPrice = 700000
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem()
            {
                OrderItemID = Guid.Parse("8ae24980-58a4-49ed-8c65-5d3aca583801"),
                ProductName = "ASUS Laptop",
                Quantity = 1000,
                UnitPrice = 10400,
                OrderID = Guid.Parse("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                TotalPrice = 10400000
            });
        }

        #endregion
    }
}

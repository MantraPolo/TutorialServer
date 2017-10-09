using Microsoft.EntityFrameworkCore;

namespace TutorialServer.Models
{
    public class OrderDetailContext : DbContext
    {
        public OrderDetailContext(DbContextOptions<OrderDetailContext> options)
            : base(options)
        {
        }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }

}

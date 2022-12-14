using Microsoft.EntityFrameworkCore;

namespace DashboardDoorfl.Models
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MessagesModel> IncomingMessages { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace My_Task_.Server.Data
{
    public class My_Task_ServerContext : DbContext
    {
        public My_Task_ServerContext(DbContextOptions<My_Task_ServerContext> options)
            : base(options)
        {
        }

        public DbSet<My_Task_.Shared.TaskItem> TaskItem { get; set; } = default!;
    }
}

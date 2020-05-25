namespace Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
namespace Demo.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    public static class DbContextInitializer
    {
        public static void Initialize(AppDataContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}

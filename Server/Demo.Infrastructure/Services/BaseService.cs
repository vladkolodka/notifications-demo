namespace Demo.Infrastructure.Services
{
    using Data;

    public class BaseService
    {
        public AppDataContext DbContext { get; }

        public BaseService(AppDataContext dataContext)
        {
            DbContext = dataContext;
        }
    }
}
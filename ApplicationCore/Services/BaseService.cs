namespace ApplicationCore.Services
{
    using Infrastructure.Data;

    public class BaseService
    {
        public AppDataContext DbContext { get; }

        public BaseService(AppDataContext dataContext)
        {
            DbContext = dataContext;
        }
    }
}
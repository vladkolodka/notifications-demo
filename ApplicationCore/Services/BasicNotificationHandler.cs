namespace ApplicationCore.Services
{
    using Infrastructure.Data;
    using Interfaces.Services;
    using Microsoft.Extensions.Logging;

    public class BasicNotificationHandler : BaseService, INotificationHandler
    {
        private readonly ILogger<INotificationHandler> _logger;

        public BasicNotificationHandler(AppDataContext dataContext, ILogger<INotificationHandler> logger) : base(dataContext)
        {
            _logger = logger;
        }

        
        public void Handle(string message)
        {
//            throw new System.NotImplementedException();
        }
    }
}
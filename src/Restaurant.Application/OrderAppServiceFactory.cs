using Restaurant.Application.Services;
using Restaurant.Domain.Repository;

namespace Restaurant.Application
{
    public class OrderAppServiceFactory : IOrderAppServiceFactory
    {
        private readonly IDishRepository _dishRepository;

        public OrderAppServiceFactory(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public BaseOrderAppService ResolveServiceFrom(string inputOrder)
        {
            return inputOrder.ToLower().Contains("morning")
                ? (BaseOrderAppService) new MorningOrderAppService(_dishRepository) 
                : new NightOrderAppService(_dishRepository);
        }
    }
}
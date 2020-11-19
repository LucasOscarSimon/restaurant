namespace Restaurant.Application.Services
{
    public interface IOrderAppServiceFactory
    {
        BaseOrderAppService ResolveServiceFrom(string inputOrder);
    }
}
using System.Threading.Tasks;

namespace Restaurant.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
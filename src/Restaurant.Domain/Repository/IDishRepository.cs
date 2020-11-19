using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Data;

namespace Restaurant.Domain.Repository
{
    public interface IDishRepository : IRepository<Dish>
    {
        Task<IReadOnlyCollection<Dish>> GetDishesAsync();
        Task<Dish> GetDishByIdAsync(int dishId);
        Task<string> GetDishByDishTypeAsync(string timeOfDay, DishType dishType);
        Task CreateDishAsync(Dish dish);
        void UpdateDish(Dish dish);
    }
}
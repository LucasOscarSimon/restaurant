using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Data;
using Restaurant.Domain;
using Restaurant.Domain.Repository;

namespace Restaurant.Infra.Data.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly DishContext _context;

        public DishRepository(DishContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;
        public async Task<IReadOnlyCollection<Dish>> GetDishesAsync()
        {
            return await _context.Dish.ToListAsync().ConfigureAwait(true);
        }

        public async Task<string> GetDishByDishTypeAsync(string timeOfDay, DishType dishType)
        {
            var timeDay = await _context.TimeOfDay.FirstOrDefaultAsync(t => t.Description.Equals(timeOfDay)).ConfigureAwait(true);

            var dish = await _context.Dish.FirstOrDefaultAsync(d =>
                d.TimeOfDayId.Equals(timeDay.Id) && d.DishTypeId.Equals((int)dishType)).ConfigureAwait(true);
            return dish == null ? string.Empty : dish.Description;
        }

        public async Task<Dish> GetDishByIdAsync(int dishId)
        {
            return await _context.Dish.FirstOrDefaultAsync(p => p.Id == dishId);
        }

        public async Task CreateDishAsync(Dish dish)
        {
            await _context.Dish.AddAsync(dish).ConfigureAwait(true);
        }

        public void UpdateDish(Dish dish)
        {
            _context.Dish.Update(dish);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
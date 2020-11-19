using Restaurant.Core.DomainObjects;

namespace Restaurant.Domain
{
    public class Dish: Entity, IAggregateRoot
    {
        public string Description { get; set; }
        public int DishTypeId { get; set; }
        public int TimeOfDayId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Restaurant.Domain;
using Restaurant.Domain.Repository;

namespace Restaurant.Application
{
    public class MorningOrderAppService : BaseOrderAppService
    {
        public MorningOrderAppService(IDishRepository dishRepository) : base(dishRepository)
        {
        }

        protected override IEnumerable<int> GetArray(string inputOrder)
        {
            var ordersStr = inputOrder.Remove(0, 7).Remove(0,1).Split(',');
            var orders = Array.ConvertAll(ordersStr, Convert.ToInt32);
            return orders;
        }

        protected override bool IsInvalidElement(DishType dishType, ICollection<int> duplicatesList, int dish, string dishDb)
        {
            return IsEmptyElement(dishDb) || dishType == DishType.Dessert || IsDuplicateElement(dishType, duplicatesList, dish);
        }

        protected bool IsDuplicateElement(DishType dishType, ICollection<int> duplicatesList, int dish)
        {
            return dishType != DishType.Drink && duplicatesList.Contains(dish);
        }

        private bool IsEmptyElement(string dishDb)
        {
            return string.IsNullOrEmpty(dishDb);
        }
    }
}
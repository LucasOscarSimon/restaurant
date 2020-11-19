using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Restaurant.Domain;
using Restaurant.Domain.Repository;

namespace Restaurant.Application
{
    public abstract class BaseOrderAppService
    {
        private readonly IDishRepository _dishRepository;

        protected BaseOrderAppService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<string> ResolveOrdersFromAsync(string inputOrder)
        {
            var timeOfDay = GetTimeOfDay(inputOrder);
            var strBuilder = new StringBuilder();
            var duplicatesList = new List<int>();

            foreach (var dish in GetArray(inputOrder))
            {
                var dishType = (DishType) dish;
                var dishDb = await GetDishDbAsync(timeOfDay, dishType);
                
                if(!IsInvalidElement(dishType, duplicatesList, dish, dishDb))
                    BuildString(strBuilder, dishDb, duplicatesList, dish);
                else
                    return AddErrorToString(strBuilder);
            }

            var finalStr = RemoveCommaFromString(strBuilder);
            return finalStr;
        }
        private static string GetTimeOfDay(string inputOrder)
        {
            var timeOfDay = inputOrder.ToLower().Contains("morning")
                ? inputOrder.Substring(0, 7)
                : inputOrder.Substring(0, 5);
            return timeOfDay;
        }

        private static string RemoveCommaFromString(StringBuilder strBuilder)
        {
            var finalStr = strBuilder.ToString();
            var commaIndex = finalStr.LastIndexOf(',');
            finalStr = finalStr.Remove(commaIndex, 1);
            return finalStr;
        }

        private string AddErrorToString(StringBuilder strBuilder)
        {
            strBuilder.Append("error");
            return strBuilder.ToString();
        }

        private void BuildString(StringBuilder strBuilder, string dishDb, ICollection<int> duplicatesList, int dish)
        {
            duplicatesList.Add(dish);



            strBuilder.Append(dishDb);
            strBuilder.Append(", ");
        }

        private async Task<string> GetDishDbAsync(string timeOfDay, DishType dishType)
        {
            return await _dishRepository.GetDishByDishTypeAsync(timeOfDay, dishType).ConfigureAwait(true);
        }

        protected abstract IEnumerable<int> GetArray(string inputOrder);

        protected abstract bool IsInvalidElement(DishType dishType, ICollection<int> duplicatesList, int dish,
            string dishDb);
    }
}
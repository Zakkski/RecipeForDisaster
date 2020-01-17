using System.Collections.Generic;
using Disaster.API.Models;
using Disaster.API.Models.ViewModels;

namespace Disaster.API.Data
{
    public interface IIngredientRepository
    {
        IEnumerable<ViewIngredient> Index();
        List<Ingredient> AddIngredients(List<Ingredient> ingredients);
    }
}
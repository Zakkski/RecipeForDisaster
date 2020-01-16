using System.Collections.Generic;
using Disaster.API.Models.ViewModels;

namespace Disaster.API.Data
{
    public interface IIngredientRepository
    {
        IEnumerable<ViewIngredient> Index();
    }
}
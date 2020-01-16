using System.Threading.Tasks;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public interface IIngredientRepository
    {
        Task<Ingredient[]> ListIngredients(int listId);
    }
}
using System.Threading.Tasks;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _context;
        public IngredientRepository(DataContext context)
        {
            _context = context;
        }
        
        public Task<Ingredient[]> ListIngredients(int listId)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disaster.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Data
{
    public class UserListRepository : IUserListRepository
    {
        private readonly DataContext _context;
        public UserListRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<object> GetUserLists(int userId, bool selectRecipes)
        {
            // https://blog.zhaytam.com/2019/03/14/generic-repository-pattern-csharp/
            // https://entityframeworkcore.com/knowledge-base/44555186/self-referencing-loop-from-newtonsoft-jsonserializer-using-entity-framework-core
            // Mystery, when this method is async it throws a json loop exception
            // var lists = _context.UserLists.Where(x => x.UserId == userId && x.List.IsRecipe == selectRecipes).Include(x => x.List).ThenInclude(x => x.ListItems).ToList();
            // Cost of this method is it only goes one layer deep but it doesn't loop that way
            var lists = _context.UserLists.Where(x => x.UserId == userId && x.List.IsRecipe == selectRecipes)
                                            .Include(x => x.List)
                                            .ThenInclude(x => x.ListItems)
                                            .ThenInclude(x => x.Ingredient)
                                            .Select(x => new {
                                                x.List.Name,
                                                x.List.ListItems,
                                                x.List.Id,
                                                x.List.IsRecipe
                                            });
            // var lists = _context.Lists.Include(x => x.ListItems).ThenInclude(x => x.Ingredient).Select(x => new {
            //     x.Id,
            //     x.Name,
            //     x.ListItems
            // }).ToList();

            return lists;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disaster.API.Models;
using Disaster.API.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Data
{
    public class UserListRepository : IUserListRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserListRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IQueryable<List> AddUserList(int userId, List list)
        {
            _context.Add(list);
            _context.SaveChanges();

            _context.Add(new UserList{
                UserId = userId,
                ListId = list.Id
            });
            _context.SaveChanges();

            return null;
        }

        public bool DeleteList(int listId)
        {
            var entity = _context.Lists.Where(x => x.Id == listId).FirstOrDefault();
            _context.Lists.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public object GetList(int listId)
        {
            var list = _context.Lists.Where(x => x.Id == listId)
                                    .Include(x => x.ListItems)
                                    .ThenInclude(x => x.Ingredient)
                                    .Include(x => x.Creator)
                                    .Select(x => _mapper.Map<List, ViewList>(x)).FirstOrDefault();

            return list;
        }

        public IQueryable<List> GetUserList(int listId)
        {
            var list = _context.Lists.Where(x => x.Id == listId)
                                    .Include(x => x.ListItems)
                                    .ThenInclude(x => x.Ingredient);

            return list;
        }

        public IEnumerable<object> GetUserLists(int userId, bool selectRecipes)
        {
            // Mystery, when this method is async it throws a json loop exception
            // May have been fixed by mapping. Haven't checked
            var lists = _context.UserLists.Where(x => x.UserId == userId && x.List.IsRecipe == selectRecipes)
                                            .Include(x => x.List)
                                            .ThenInclude(x => x.ListItems)
                                            .ThenInclude(x => x.Ingredient)
                                            .Include(x => x.List).ThenInclude(x => x.Creator)
                                            .Select(x => _mapper.Map<List, ViewList>(x.List)).ToList();

            return lists;
        }
    }
}
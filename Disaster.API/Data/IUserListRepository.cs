using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public interface IUserListRepository
    {
        // If true grab user recipes if false grab shopping lists
        IEnumerable<object> GetUserLists(int userId, bool selectRecipeLists);
        object GetList(int listId);
        IQueryable<List> GetUserList(int listId);
        IQueryable<List> AddUserList(int userId, List list);
        bool DeleteList(int listId);
    }
}
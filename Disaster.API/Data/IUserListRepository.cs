using System.Collections.Generic;
using System.Threading.Tasks;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public interface IUserListRepository
    {
        // If true grab user recipes if false grab shopping lists
        IEnumerable<object> GetUserLists(int userId, bool selectRecipeLists);
    }
}
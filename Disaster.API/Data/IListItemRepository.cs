using System.Collections.Generic;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public interface IListItemRepository
    {
        bool UpdateListItems(IEnumerable<ListItem> listItems);
        ListItem AddListItem(ListItem listItem);
        bool DeleteListItem(int listItemId);
        bool ClearList(int listId);
    }
}
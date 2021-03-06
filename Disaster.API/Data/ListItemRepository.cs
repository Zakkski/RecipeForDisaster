using System.Collections.Generic;
using System.Linq;
using Disaster.API.Models;

namespace Disaster.API.Data
{
    public class ListItemRepository : IListItemRepository
    {
        private readonly DataContext _context;
        public ListItemRepository(DataContext context)
        {
            _context = context;
        }
        public ListItem AddListItem(ListItem listItem)
        {
            _context.Add(listItem);
            _context.SaveChanges();
            return listItem;
        }

        public bool UpdateListItems(IEnumerable<ListItem> listItems)
        {
            foreach (var item in listItems)
            {
                var entity = _context.ListItems.Where(x => x.Id == item.Id).Single();
                if (entity == null)
                {
                    return false;
                }

                _context.Entry(entity).CurrentValues.SetValues(item);

            }
            return _context.SaveChanges() > 0;
        }

        public bool DeleteListItem(int listItemId)
        {
            var entity = _context.ListItems.Where(x => x.Id == listItemId).FirstOrDefault();
            _context.ListItems.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool ClearList(int listId)
        {
            var entities = _context.ListItems.Where(x => x.ListId == listId);
            _context.ListItems.RemoveRange(entities);
            return _context.SaveChanges() > 0;
        }
    }
}
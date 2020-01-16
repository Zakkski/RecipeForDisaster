using System.Collections.Generic;

namespace Disaster.API.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Creator { get; set; }
        public int? CreatorId { get; set; }
        public bool IsRecipe { get; set; }
        public ICollection<ListItem> ListItems { get; set; }
    }
}
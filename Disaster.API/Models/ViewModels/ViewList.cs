using System.Collections.Generic;

namespace Disaster.API.Models.ViewModels
{
    public class ViewList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ViewListItem> ListItems { get; set; }
        public ViewUser Creator { get; set; }
        public bool IsRecipe { get; set; }
    }
}
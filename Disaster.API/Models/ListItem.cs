namespace Disaster.API.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public List List { get; set; }
        public int ListId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
    }
}
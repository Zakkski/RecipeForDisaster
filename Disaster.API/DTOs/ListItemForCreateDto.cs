using System.ComponentModel.DataAnnotations;

namespace Disaster.API.DTOs
{
    public class ListItemForCreateDto
    {
        [Required]

        public int ListId { get; set; }
        [Required]
        public int IngredientId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
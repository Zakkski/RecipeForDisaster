using System.ComponentModel.DataAnnotations;

namespace Disaster.API.DTOs
{
    public class ListForCreateDto
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public bool IsRecipe { get; set; }
        [Required]
        public int CreatorId { get; set; }
    }
}
using Disaster.API.Data;
using Disaster.API.DTOs;
using Disaster.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Disaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {
        private readonly IListItemRepository _repo;
        public ListItemsController(IListItemRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddListItem(ListItemForCreateDto listItemForCreate)
        {
            var newListItem = new ListItem 
            {
                ListId = listItemForCreate.ListId,
                IngredientId = listItemForCreate.IngredientId,
                Amount = listItemForCreate.Amount
            };

            _repo.AddListItem(newListItem);

            return Ok();
        }
    }
}
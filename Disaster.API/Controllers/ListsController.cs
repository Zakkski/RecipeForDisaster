using System.Collections.Generic;
using System.Linq;
using Disaster.API.Data;
using Disaster.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Disaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IUserListRepository _listRepo;
        private readonly IListItemRepository _listItemRepo;
        public ListsController(IUserListRepository listRepo, IListItemRepository listItemRepo)
        {
            _listRepo = listRepo;
            _listItemRepo = listItemRepo;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id, [FromQuery] bool selectRecipes)
        {
            var lists = _listRepo.GetUserLists(id, selectRecipes);
            return Ok(lists);
        }

        [HttpGet("user/{id}")]
        public IActionResult Show(int id)
        {
            var list = _listRepo.GetList(id);
            return Ok(list);
        }

        [HttpPost("port/{id}/{recipeId}")]
        public IActionResult Port(int id, int recipeId)
        {
            var shoppingList = _listRepo.GetUserList(id).FirstOrDefault();
            var recipe = _listRepo.GetUserList(recipeId).FirstOrDefault();


            foreach(var shoppingItem in shoppingList.ListItems)
            {
                var recipeItem = recipe.ListItems.Where(x => x.IngredientId == shoppingItem.IngredientId).Single();
                if (recipeItem != null)
                {
                    shoppingItem.Amount += recipeItem.Amount;
                }
            }

            _listItemRepo.UpdateListItems(shoppingList.ListItems);


            foreach(var recipeItem in recipe.ListItems)
            {
                var shoppingItem = shoppingList.ListItems.Where(x => x.IngredientId == recipeItem.IngredientId).FirstOrDefault();
                if (shoppingItem == null)
                {
                    _listItemRepo.AddListItem(new ListItem()
                        {
                            Amount = recipeItem.Amount,
                            ListId = id,
                            IngredientId = recipeItem.IngredientId
                        }
                    );
                }
            }

            return Ok();
        }
    }
}
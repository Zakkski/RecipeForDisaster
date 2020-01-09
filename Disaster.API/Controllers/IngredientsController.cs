using System.Linq;
using Disaster.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Controllers
{
    // Causes everything here to be an authorized request, need to give it an authentication middleware in startup
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly DataContext _context;
        public IngredientsController(DataContext context)
        {
            _context = context;
        }

        // api/ingredients
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var ingredients = _context.Ingredients.ToList();

            return Ok(ingredients);
        }    

        // api/ingredients/:id
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var ingredient = _context.Ingredients.Where(x => x.IngredientId == id);

            return Ok(ingredient);
        }
    }
}

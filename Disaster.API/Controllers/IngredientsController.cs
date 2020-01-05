using System.Linq;
using Disaster.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly DataContext _context;
        public IngredientsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // api/ingredients
        public IActionResult Get()
        {
            var ingredients = _context.Ingredients.ToList();

            return Ok(ingredients);
        }    
    }
}

using System.Linq;
using Disaster.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Controllers
{
    // Causes everything here to be an authorized request, need to give it an authentication middleware in startup
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository _repo;
        public IngredientsController(IIngredientRepository repo)
        {
            _repo = repo;
        }

        // api/ingredients
        // Skips auth
        // [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var ingredients = _repo.Index();

            return Ok(ingredients);
        }    
    }
}

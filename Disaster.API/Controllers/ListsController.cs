using Disaster.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Disaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IUserListRepository _repo;
        public ListsController(IUserListRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id, [FromQuery] bool selectRecipes)
        {
            var lists = _repo.GetUserLists(id, selectRecipes);
            return Ok(lists);
        }
    }
}
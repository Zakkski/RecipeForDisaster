using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Disaster.API.Data;
using Disaster.API.DTOs;
using Disaster.API.Models;
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
        private readonly IMapper _mapper;
        public IngredientsController(IIngredientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult AddIngredients(List<IngredientForCreate> ingredientsForCreate)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(IngredientForCreate item in ingredientsForCreate)
            {
                ingredients.Add(_mapper.Map<Ingredient>(item));
            }
            _repo.AddIngredients(ingredients);
            return Ok(ingredients);
        }
    }
}

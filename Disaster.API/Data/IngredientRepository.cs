using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disaster.API.Models.ViewModels;
using Disaster.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Data
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public IngredientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  IEnumerable<ViewIngredient> Index()
        {
            return  _context.Ingredients.Select(ingredient => _mapper.Map<Ingredient, ViewIngredient>(ingredient)).ToList();
        }

    }
}
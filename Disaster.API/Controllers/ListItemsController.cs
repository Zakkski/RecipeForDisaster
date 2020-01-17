using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public ListItemsController(IListItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        [HttpPost("multiple")]
        public IActionResult AddListItems(List<ListItemForCreateDto> listItemsForCreate)
        {
            List<ListItem> listItems = new List<ListItem>();
            foreach(var listItem in listItemsForCreate)
            {
                listItems.Add(_mapper.Map<ListItem>(listItem));
            }

            _repo.AddListItems(listItems);

            return Ok();
        }
    }
}
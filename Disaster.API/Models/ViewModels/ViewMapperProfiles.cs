using AutoMapper;
using Disaster.API.DTOs;

namespace Disaster.API.Models.ViewModels
{
    public class ViewMapperProfiles : Profile
    {
        public ViewMapperProfiles()
        {
            CreateMap<Ingredient, ViewIngredient>();
            CreateMap<User, ViewUser>();
            CreateMap<List, ViewList>();
            CreateMap<ListItem, ViewListItem>();
            CreateMap<ListItemForCreateDto, ListItem>();
            CreateMap<IngredientForCreate, Ingredient>();
        }
    }
}

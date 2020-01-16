using AutoMapper;

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
        }
    }
}

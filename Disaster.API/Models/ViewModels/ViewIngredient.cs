using System;
using System.Linq.Expressions;

namespace Disaster.API.Models.ViewModels
{
    public class ViewIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Count { get; set; }
    }
}

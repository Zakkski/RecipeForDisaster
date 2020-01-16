using System;
using System.Linq.Expressions;

namespace Disaster.API.Models.ViewModels
{
    public class ViewUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static Expression<Func<User, ViewUser>> Projection
        {
            get
            {
                return x => new ViewUser()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email
                };
            }
        }
    }
}
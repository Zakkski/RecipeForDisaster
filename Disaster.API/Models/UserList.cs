namespace Disaster.API.Models
{
    public class UserList
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List List { get; set; }
        public int ListId { get; set; }
    }
}
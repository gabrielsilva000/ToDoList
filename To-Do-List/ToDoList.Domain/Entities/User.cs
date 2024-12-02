using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now.ToLocalTime();
    }
}

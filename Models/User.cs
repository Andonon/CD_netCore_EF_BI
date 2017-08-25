using System;
using System.Collections.Generic;

namespace brightideas.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public List<Like> Likes { get; set; }
        public User()
        {
            Likes = new List<Like>();
        }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }      
    }
}
using System;
using System.Collections.Generic;

namespace brightideas.Models
{
    public class Idea : BaseEntity
    {
        public int IdeaId { get; set; }
        public string IdeaText { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public List<Like> Likes { get; set; }
        public Idea()
        {
            Likes = new List<Like>();
        }     
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
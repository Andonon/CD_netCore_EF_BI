using System;
namespace brightideas.Models
{
    public class ideas : BaseEntity
    {
        public int Id { get; set; }
        public string Idea { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }      
    }
}
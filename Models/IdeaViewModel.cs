using System.ComponentModel.DataAnnotations;

namespace brightideas.Models
{
    public class IdeaViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Idea is required.")]
        [StringLength(1000, ErrorMessage = "Idea must be betwen 10 and 1000 characters", MinimumLength = 10)]
        public string Idea { get; set; }   
    }
}
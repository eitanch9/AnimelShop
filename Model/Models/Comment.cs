using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "Comment Id:")]
        [Required(ErrorMessage = "Please enter Comment Id.")]
        public int CommentId { get; set; }

        [ForeignKey("AnimalId")]
        [Display(Name = "Animal Id:")]
        [Required(ErrorMessage = "Please enter Animal Id.")]
        public int AnimalId { get; set; }

        [Display(Name = "Comment Text:")]
        [Required(ErrorMessage = "Please enter Comment Text.")]
        public string? CommentText { get; set; }



    }
}

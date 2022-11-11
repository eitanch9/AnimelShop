using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category Id:")]
        [Required(ErrorMessage = "Please enter Category Id.")]
        public int CategoryId { get; set; }

        [MaxLength(25)]
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter Name.")]
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Category)) return false;
            var other = obj as Category;
            if (this.CategoryId != other!.CategoryId) return false;
            return true;
        }

     
    }
}

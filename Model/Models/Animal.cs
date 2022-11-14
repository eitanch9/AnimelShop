using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models

{
    public class Animal
    {



        [Key]
        [Display(Name = "ID:")]
        [Required(ErrorMessage = "Please enter ID")]
        public int AnimalId { get; set; }

        [MaxLength(25)]
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter Name.")]
        public string? Name { get; set; }


        [Range(0, 120)]
        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter Age.")]
        public int Age { get; set; }


        [Display(Name = "Description:")]
        [Required(ErrorMessage = "Please enter Description.")]
        public string? Description { get; set; }

        [Display(Name = "Picture Link:")]
        [Required(ErrorMessage = "Please enter Picture Link.")]
        public string? PictureLink { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Category id:")]
        [Required(ErrorMessage = "Please enter Category.")]
        public int CategoryId { get; set; }

        [Display(Name = "Category:")]
        [Required(ErrorMessage = "Category")]
        public virtual Category? Category { get; set; }

        public virtual List<Comment>? Comments { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Animal)) return false;
            var other = obj as Animal;
            if (this.Name != other!.Name) return false;
            if (this.Age != other!.Age) return false;
            if (this.Description != other!.Description) return false;
            if (!this.Category!.Equals(other!.Category)) return false;
            return true;

        }
    }

}

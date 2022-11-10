namespace WebApplicationAnimel.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

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

namespace Model.Models

{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? PictureLink { get; set; }
        public string? Description { get; set; }

        public Category? Category { get; set; }

        public List<Comment>? Comments { get; set; }


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

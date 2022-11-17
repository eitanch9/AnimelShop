using Model.DAL;
using Model.Models;

namespace Model.Repository
{
    public class CommentRepoditory : MyRepository<Comment, AnimalsContext>
    {
        public CommentRepoditory(AnimalsContext Data) : base(Data) { }

        public override bool Edit(Comment entity, int Id)
        {
            if (entity == null) { return false; }

            var oldComment = _data.Set<Comment>().Where(comment => comment.CommentId == Id).SingleOrDefault();
            if (oldComment != null && !oldComment.Equals(entity))
            {
                _data.Set<Comment>().Remove(oldComment);
                _data.Set<Comment>().Add(entity);
                Save();
                return true;
            }
            return false;
        }

        public override Comment? FindById(int Id) => _data.Comments.FirstOrDefault(c => c.CommentId == Id);
    }
}

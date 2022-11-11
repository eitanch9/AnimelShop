using Microsoft.EntityFrameworkCore;
using Model.DAL;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model.Repository
{
    public class CommentRepoditory : MyRepository<Comment, AnimalsContext>
    {
        private AnimalsContext _data { get; set; }
        public CommentRepoditory(AnimalsContext Data) : base(Data) { _data = Data; }

        public override bool Edit(Comment entity)
        {
            if (entity == null) { return false; }

            var oldComment = _data.Set<Comment>().Where(comment => comment.CommentId == entity.CommentId).SingleOrDefault();
            if (oldComment != null && !oldComment.Equals(entity))
            {
                _data.Set<Comment>().Remove(oldComment);
                _data.Set<Comment>().Add(entity);
                Save();
                return true;
            }
            return false;
        }
    }
}

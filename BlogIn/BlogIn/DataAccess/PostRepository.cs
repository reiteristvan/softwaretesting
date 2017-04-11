using System;
using System.Collections.Generic;

namespace BlogIn.DataAccess
{
    public interface IPostRepository
    {
        IEnumerable<Post> All();
        Post FindById(Guid id);
        void Create(Post entity);
        void Update(Post entity);
        void Delete(Post entity);
    }

    public sealed class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public override void Create(Post entity)
        {
            entity.PublicationDate = DateTimeOffset.Now;
            base.Create(entity);
        }
    }
}
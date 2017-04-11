using System;
using System.Collections.Generic;
using System.Linq;
using BlogIn.DataAccess;

namespace BlogIn.Services
{
    public interface IBlogService
    {
        List<Post> All();
        Post Get(Guid id);
        Guid Create(Post post);
    }

    public sealed class BlogService : IBlogService
    {
        private readonly IPostRepository _postRepository;
        //private readonly BlogInDbContext _dbContext;

        public BlogService(IPostRepository postRepository)
        {
            //_dbContext = new BlogInDbContext();
            _postRepository = postRepository;
        }

        public List<Post> All()
        {
            return _postRepository.All().OrderByDescending(p => p.PublicationDate).ToList();
            //return _dbContext.Posts.OrderByDescending(p => p.PublicationDate).ToList();
        }

        public Post Get(Guid id)
        {
            return _postRepository.FindById(id);
            //return _dbContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public Guid Create(Post post)
        {
            //post.PublicationDate = DateTimeOffset.Now;

            _postRepository.Create(post);

            //_dbContext.Posts.Add(post);
            //_dbContext.SaveChanges();

            // other tasks:
            // - notify subscribers
            // - index content for searching

            return post.Id;
        }
    }
}
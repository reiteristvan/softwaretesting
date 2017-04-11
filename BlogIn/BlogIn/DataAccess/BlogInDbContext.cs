using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogIn.DataAccess
{
    public sealed class BlogInDbContext : DbContext
    {
        public BlogInDbContext()
            : base("BlogInDbConnection")
        {
            
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }

    public sealed class Tag : EntityBase
    {
        public string Name { get; set; }
    }

    public sealed class Post : EntityBase
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        public string Title { get; set; }
        public DateTimeOffset PublicationDate { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; } 
    }
}
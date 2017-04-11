using System;
using System.Collections.Generic;
using BlogIn.DataAccess;
using BlogIn.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Blogin.UnitTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void ListPosts()
        {
            // Arrange
            List<Post> posts = new List<Post>
            {
                new Post { Author = "Test Mester", Content = "Test Content", PublicationDate = DateTimeOffset.Now, Title = "Test"}
            };

            Mock<IBlogService> blogServiceMock = new Mock<IBlogService>();
            blogServiceMock
                .Setup(blogService => blogService.All())
                .Returns(() => posts);

            // Act
            List<Post> postList = blogServiceMock.Object.All();

            // Assert
            Assert.IsNotNull(postList);
            Assert.AreEqual(postList.Count, posts.Count);
        }
    }
}

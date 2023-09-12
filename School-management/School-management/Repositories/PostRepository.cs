using Microsoft.EntityFrameworkCore;
using School_management.DataAccess;
using School_management.Interfaces;
using School_management.Models;
using schoolManagement.Models;

namespace School_management.Repositories
{
    public class PostRepository : IPost
    {
        private readonly MyAppContext context;

        public PostRepository( MyAppContext context)
        {
            this.context = context;
        }

        public Post DeletePost(Guid PostId)
        {
            var post = context.Posts
                .Find(PostId);
            if (post == null)
            {
                return null;
            }

            context.Posts.Remove(post);
            context.SaveChanges();

            return post;
        }

        public Post GetPost(Guid PostId)
        {
            var post = context.Posts.Where(p => p.PostId == PostId).FirstOrDefault();
            if (post == null)
            { return null; }
            return post;
        }

        public IList<Post> GetPosts()
        {
            return  context.Posts.ToList();
        }

        public Post InsertPost(Post objPost)
        {
            context.Posts.Add(objPost);
            context.SaveChanges();

            return (objPost);
        }

        public Post UpdatePost(Guid PostId, Post objPost)
        {
            var post = context.Posts.Find(PostId);

            if (post == null)
            {
                return null;
            }
            post.PostName = objPost.PostName;
            post.DatePost = DateTime.UtcNow;

           

            context.Posts.Update(post);
            context.SaveChanges();
            return objPost;
        }
    }
}

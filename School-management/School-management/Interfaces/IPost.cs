using School_management.Models;
using schoolManagement.Models;

namespace School_management.Interfaces
{
    public interface IPost
    {

       IList<Post> GetPosts();
        Post GetPost(Guid PostId);
        Post InsertPost(Post objPost);
        Post UpdatePost(Guid PostId, Post objPost);
        Post DeletePost(Guid PostId);
    }
}

using System.Threading.Tasks;

namespace Spike.Jane.Blog.Service.Domain
{
    public interface IWordpressClient
    {
        Task<WordpressPost[]> ListPostsAsync();
        Task<WordpressPost> RetrievePostAsync(int postId);
        Task<WordpressCategory[]> ListCategoriesAsync();
        Task<WordpressCategory> RetrieveCategoryAsync(int categoryId);
        Task<WordpressTag[]> ListTagsAsync();
        Task<WordpressTag> RetrieveTagAsync(int tagId);
    }
}
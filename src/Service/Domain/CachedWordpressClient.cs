using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spike.Jane.Blog.Service.Domain
{
    public class CachedWordpressClient : IWordpressClient
    {
        private static IDictionary<int, WordpressPost> _posts;
        private static IDictionary<int, WordpressCategory> _categories;
        private readonly IWordpressClient _client;

        public CachedWordpressClient(IWordpressClient client)
        {
            _client = client;
            Parallel.Invoke(
                () => _posts ??= _client.ListPostsAsync().Result.ToDictionary(p => p.Id),
                () => _categories ??= _client.ListCategoriesAsync().Result.ToDictionary(c => c.Id));
        }

        public Task<WordpressPost[]> ListPostsAsync()
        {
            return Task.FromResult(_posts.Values.ToArray());
        }

        public Task<WordpressPost> RetrievePostAsync(int postId)
        {
            return Task.FromResult(_posts[postId]);
        }

        public Task<WordpressCategory[]> ListCategoriesAsync()
        {
            return Task.FromResult(_categories.Values.ToArray());
        }

        public Task<WordpressCategory> RetrieveCategoryAsync(int categoryId)
        {
            return Task.FromResult(_categories[categoryId]);
        }

        public Task<WordpressTag[]> ListTagsAsync() => _client.ListTagsAsync();

        public Task<WordpressTag> RetrieveTagAsync(int tagId) => _client.RetrieveTagAsync(tagId);
    }
}
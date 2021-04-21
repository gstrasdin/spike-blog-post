using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Spike.Jane.Blog.Service.Domain
{
    public class WordpressClient : IWordpressClient
    {
        private readonly HttpClient _client;

        public WordpressClient(HttpClient client)
        {
            _client = client;
        }

        public Task<WordpressPost[]> ListPostsAsync()
        {
            var after = new DateTime(2021, 1, 1);
            var page = 1;
            var perPage = 20;

            return _client.GetFromJsonAsync<WordpressPost[]>($"https://jane.com/blog/wp-json/wp/v2/posts?after={after:O}&page={page}&per_page={perPage}");
        }

        public Task<WordpressPost> RetrievePostAsync(int postId)
        {
            return _client.GetFromJsonAsync<WordpressPost>($"https://jane.com/blog/wp-json/wp/v2/posts/{postId}");
        }

        public Task<WordpressCategory[]> ListCategoriesAsync()
        {
            return _client.GetFromJsonAsync<WordpressCategory[]>($"https://jane.com/blog/wp-json/wp/v2/categories");
        }

        public Task<WordpressCategory> RetrieveCategoryAsync(int categoryId)
        {
            return _client.GetFromJsonAsync<WordpressCategory>($"https://jane.com/blog/wp-json/wp/v2/categories/{categoryId}");
        }

        public Task<WordpressTag[]> ListTagsAsync()
        {
            return _client.GetFromJsonAsync<WordpressTag[]>($"https://jane.com/blog/wp-json/wp/v2/tags");
        }

        public Task<WordpressTag> RetrieveTagAsync(int tagId)
        {
            return _client.GetFromJsonAsync<WordpressTag>($"https://jane.com/blog/wp-json/wp/v2/tags/{tagId}");
        }
    }
}

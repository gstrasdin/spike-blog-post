using System;
using System.Text.Json.Serialization;

namespace Spike.Jane.Blog.Service.Domain
{
    public class WordpressPost
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Slug { get; set; }
        public WordpressObject Title { get; set; }
        public WordpressObject Content { get; set; }
        public WordpressObject Excerpt { get; set; }
        public int[] Categories { get; set; }
        public int[] Tags { get; set; }
        [JsonPropertyName("jetpack_featured_media_url")]
        public Uri MediaUrl { get; set; }
        [JsonPropertyName("_links")]
        public WordpressLinks Links { get; set; }
    }

    public class WordpressObject
    {
        public string Rendered { get; set; }
        public bool Protected { get; set; }
    }

    public class WordpressLinks
    {
        public WordpressLinkObject[] Self { get; set; }
        public WordpressLinkObject[] Collection { get; set; }
        public WordpressLinkObject[] About { get; set; }
        public WordpressLinkObject[] Author { get; set; }
        public WordpressLinkObject[] Replies { get; set; }
        [JsonPropertyName("version-history")]
        public WordpressLinkObject[] VersionHistory { get; set; }
        [JsonPropertyName("predecessor-version")]
        public WordpressLinkObject[] PredecessorVersion { get; set; }
        [JsonPropertyName("wp:featuredmedia")]
        public WordpressLinkObject[] FeaturedMedia { get; set; }
        [JsonPropertyName("wp:attachment")]
        public WordpressLinkObject[] Attachment { get; set; }
        [JsonPropertyName("wp:term")]
        public WordpressLinkObject[] Terms { get; set; }
        [JsonPropertyName("wp:post_type")]
        public WordpressLinkObject[] PostType { get; set; }
        public WordpressLinkObject[] Curies { get; set; }
    }

    public class WordpressLinkObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Taxonomy { get; set; }
        public bool? Embeddable { get; set; }
        public Uri Href { get; set; }
    }

    public class WordpressCategory
    {
        public int Id { get; set; }
        [JsonPropertyName("parent")]
        public int ParentId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Taxonomy { get; set; }
        public Uri Link { get; set; }
        [JsonPropertyName("_links")]
        public WordpressLinks Links { get; set; }
    }

    public class WordpressTag
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Taxonomy { get; set; }
        public Uri Link { get; set; }
        [JsonPropertyName("_links")]
        public WordpressLinks Links { get; set; }
    }
}

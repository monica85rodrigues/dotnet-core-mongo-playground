using System;

namespace Api.Models
{
    public class Bookmark
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
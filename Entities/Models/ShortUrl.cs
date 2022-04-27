using System;

namespace Entities.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string ShortenUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
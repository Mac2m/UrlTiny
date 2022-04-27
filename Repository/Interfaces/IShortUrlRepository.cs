using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Interface
{
    public interface IShortUrlRepository
    {
        Task<IEnumerable<ShortUrl>> GetAllAsync();
        Task<ShortUrl> GetByShortUrlAsync(string shortUrl);
        Task<ShortUrl> GetByLongUrlAsync(string longUrl);
        Task<ShortUrl> CreateAsync(string longUrl);
    }
}
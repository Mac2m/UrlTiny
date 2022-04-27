using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Utils;

namespace Repository.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly SqlContext _context;

        public ShortUrlRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShortUrl>> GetAllAsync()
        {
            return await _context.ShortUrls.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ShortUrl> GetByShortUrlAsync(string shortUrl)
        {
            return await _context.ShortUrls.FirstOrDefaultAsync(x => x.ShortenUrl == shortUrl).ConfigureAwait(false);
        }

        public async Task<ShortUrl> GetByLongUrlAsync(string longUrl)
        {
            return await _context.ShortUrls.FirstOrDefaultAsync(x => x.LongUrl == longUrl).ConfigureAwait(false);
        }

        public async Task<ShortUrl> CreateAsync(string longUrl)
        {
            var shortUrl = new ShortUrl
            {
                LongUrl = longUrl,
                ShortenUrl = Generator.GenerateShortUrl(6)
            };

            await _context.ShortUrls.AddAsync(shortUrl).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return await _context.ShortUrls.FirstOrDefaultAsync(x => x.LongUrl == longUrl).ConfigureAwait(false);
        }
    }
}
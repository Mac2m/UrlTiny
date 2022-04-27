using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interface;
using Services.Dto;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class UrlTinyService : IUrlTinyService
    {
        private readonly IShortUrlRepository _repository;

        public UrlTinyService(IShortUrlRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<ServiceResponse<IEnumerable<ShortUrlDto>>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return new ServiceResponse<IEnumerable<ShortUrlDto>>(list.Select(x => new ShortUrlDto()
            {
                LongUrl = x.LongUrl,
                ShortUrl = x.ShortenUrl
            }));
        }

        public async Task<ServiceResponse<ShortUrlDto>> GetShortUrlByShortCode(string shortCode)
        {
            var shortUrl = await _repository.GetByShortUrlAsync(shortCode);
            if (shortUrl == null)
            {
                return new ServiceResponse<ShortUrlDto>("Short url not found");
            }
            return new ServiceResponse<ShortUrlDto>(new ShortUrlDto()
            {
                LongUrl = shortUrl.LongUrl,
                ShortUrl = shortUrl.ShortenUrl
            });
        }

        public async Task<ServiceResponse<ShortUrlDto>> GetShortUrlByLongUrl(string longUrl)
        {
            var shortUrl = await _repository.GetByLongUrlAsync(longUrl);
            return new ServiceResponse<ShortUrlDto>(new ShortUrlDto()
            {
                LongUrl = shortUrl.LongUrl,
                ShortUrl = shortUrl.ShortenUrl
            });
        }

        public async Task<ServiceResponse<ShortUrlDto>> CreateShortUrl(string longUrl)
        {
            var shortUrl = await _repository.CreateAsync(longUrl);
            if (shortUrl == null)
                return new ServiceResponse<ShortUrlDto>("Error creating short url");

            return new ServiceResponse<ShortUrlDto>(new ShortUrlDto()
            {
                LongUrl = shortUrl.LongUrl,
                ShortUrl = shortUrl.ShortenUrl
            });
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Dto;
using Services.Models;

namespace Services.Interfaces
{
    public interface IUrlTinyService
    {
        Task<ServiceResponse<IEnumerable<ShortUrlDto>>> GetAll();
        Task<ServiceResponse<ShortUrlDto>> GetShortUrlByShortCode(string shortCode);
        Task<ServiceResponse<ShortUrlDto>> GetShortUrlByLongUrl(string longUrl);
        Task<ServiceResponse<ShortUrlDto>> CreateShortUrl(string longUrl);
    }
}
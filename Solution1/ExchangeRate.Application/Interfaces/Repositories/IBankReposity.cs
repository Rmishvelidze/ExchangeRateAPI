using ExchangeRate.Application.DTOs.Banks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankReposity
    {
        Task<List<BanksDTO>> GetBanksAsync();
    }
}

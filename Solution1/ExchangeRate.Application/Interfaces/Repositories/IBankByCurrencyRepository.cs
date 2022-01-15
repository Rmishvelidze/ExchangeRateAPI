using ExchangeRate.Application.DTOs.Banks;

namespace ExchangeRate.Application.Interfaces.Repositories
{
    public interface IBankByCurrencyRepository
    {
        Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string currency, ICollection<string> banks, DateTime stratDate, DateTime endDate);
    }
}

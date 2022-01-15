using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace ExchangeRate.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Bank> Banks { get; set; }
        DbSet<Currency> Currencys { get; set; }
        DbSet<BankCurrency> BankCurrencys { get; set;}
        DbSet<ExchangeRateData> ExchangeRates { get; set; }
    }
}

﻿using AspNetCoreHero.Results;
using ExchangeRate.Application.DTOs.Banks;
using ExchangeRate.Application.Interfaces.Repositories;
using ExchangeRate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class BankByCurrencyRepository : IBankByCurrencyRepository
    {
        private readonly IRepositoryAsync<ExchangeRateData> _repository;
        private readonly IDistributedCache _distributedCache;

        public BankByCurrencyRepository(IRepositoryAsync<ExchangeRateData> repository, IDistributedCache distributedCache)
        {
            _repository = repository;   
            _distributedCache = distributedCache;
        }

        public IQueryable<ExchangeRateData> Banks => _repository.Entities;
        public async Task<List<BankByCurrencyDTO>> GetBankByCurrenciesAsync
            (string firstCurrency, string secondCurrency, ICollection<string> banks, DateTime stratDate, DateTime endDate)
        {
            Expression<Func<ExchangeRateData, BankByCurrencyDTO>> expression = e => new BankByCurrencyDTO
            {
                BankCode = e.Bank.BankCode,
                Date = e.Date,
                BuyRate = e.BuyRate,
                SellRate = e.SellRate
            };

            var exchangeRateData = _repository.Entities.Where
                (x => x.Date >= stratDate && x.Date <= endDate &&
                x.BuyCurrency.CurrencyName == firstCurrency && x.SellCurrency.CurrencyName == secondCurrency);
            var collection = exchangeRateData.Select(expression).ToListAsync();
            return  await collection;
        }
    }
}

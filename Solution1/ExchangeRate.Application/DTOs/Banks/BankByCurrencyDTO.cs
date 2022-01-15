﻿namespace ExchangeRate.Application.DTOs.Banks
{
    public class BankByCurrencyDTO
    {
        public string? BankCode { get; set; }
        public decimal? BuyRate { get; set; }
        public decimal? SellRate { get; set; }
        public DateTime Date { get; set; }
    }
}

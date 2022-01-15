namespace ExchangeRate.Application.DTOs.Banks
{
    public class BanksDTO
    {
        public string BankCode { get; set; }
        public string BankName { get; set;}
        public ICollection<string> Currencies { get; set; }
    }
}

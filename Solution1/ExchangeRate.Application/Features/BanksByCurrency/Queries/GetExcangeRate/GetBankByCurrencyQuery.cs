using AspNetCoreHero.Results;
using AutoMapper;
using ExchangeRate.Application.Interfaces.Repositories;
using MediatR;

namespace ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate
{
    public class GetBankByCurrencyQuery : IRequest<Result<GetBankByCurrencyResponce>>
    {
        public string Currency { get; set; }
        public ICollection<string> Banks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public class GetBankByCurrencyQueryHandler : IRequestHandler<GetBankByCurrencyQuery, Result<GetBankByCurrencyResponce>>
        {
            private readonly IBankByCurrencyRepository _bankByCurrency;
            private readonly IMapper _mapper;

            public GetBankByCurrencyQueryHandler(IBankByCurrencyRepository bankByCurrency, IMapper mapper)
            {
                _bankByCurrency = bankByCurrency;
                _mapper = mapper;
            }

            public async Task<Result<GetBankByCurrencyResponce>> Handle(GetBankByCurrencyQuery query, CancellationToken cancellationToken)
            {
                var bankByCurrency = await _bankByCurrency.GetBankByCurrenciesAsync
                    (query.Currency, query.Banks, query.StartDate, query.EndDate);
                var mappedBankByCurrency = _mapper.Map< GetBankByCurrencyResponce>(bankByCurrency);
                return Result<GetBankByCurrencyResponce>.Success(mappedBankByCurrency);
            }
        }
    }
}

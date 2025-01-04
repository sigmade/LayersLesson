using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataLayer.CurrencyServices
{
    public class BestExcangeService : ICurrenceExchange
    {
        private readonly IOptionsMonitor<Options> _optionsMonitor;
        private readonly ILogger<BestExcangeService> _logger;

        public BestExcangeService(IOptionsMonitor<Options> optionsMonitor, ILogger<BestExcangeService> logger)
        {
            _optionsMonitor = optionsMonitor;
            _logger = logger;
        }


        public decimal GetCoeff()
        {
            if (!_optionsMonitor.CurrentValue.ServiceEnabled)
            {
                throw new Exception();
            }
            _logger.LogInformation("KDM is added");
            return 0.7M;
        }
    }
}

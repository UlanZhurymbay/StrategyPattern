using StrategyPattern.Enums;
using StrategyPattern.Services.PaymentMethods;

namespace StrategyPattern.Services
{
    public class PaymentStrategyEnumerable
    {
        private readonly IEnumerable<IPaymentStrategy> _paymentStrategies;

        public PaymentStrategyEnumerable(
            IEnumerable<IPaymentStrategy> paymentStrategies)
        {
            _paymentStrategies = paymentStrategies;
        }
        public string ExecuteStrategy(Payment key)
        {
            return _paymentStrategies.FirstOrDefault(x => x.Name == key)?.Execute() ??
            throw new ArgumentException($"Payment type '{key}' not found.");
        }
    }
}

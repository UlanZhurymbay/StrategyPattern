using StrategyPattern.Enums;
using StrategyPattern.Services.PaymentMethods;
using System.Xml.Linq;

namespace StrategyPattern.Services
{
    public class PaymentStrategyDictionary : Dictionary<Payment, IPaymentStrategy>
    {
        public string ExecuteStrategy(Payment key)
        {

            if (TryGetValue(key, out var valueStrategy))
            {
                return valueStrategy.Execute();
            }
            throw new ArgumentException($"Payment type '{key}' not found.");
        }
    }
}

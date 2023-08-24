using StrategyPattern.Enums;
using StrategyPattern.Services.PaymentMethods;

namespace StrategyPattern.Services
{
    public delegate IPaymentStrategy PaymentStrategyDelegate(Payment cookingType);

}

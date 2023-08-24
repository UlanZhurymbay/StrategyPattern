using StrategyPattern.Enums;

namespace StrategyPattern.Services.PaymentMethods
{
    public interface IPaymentStrategy
    {
        public Payment Name { get; set; }
        string Execute();
    }
}

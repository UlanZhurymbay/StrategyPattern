using StrategyPattern.Enums;

namespace StrategyPattern.Services.PaymentMethods
{
    public class PartialPaymentStrategy : IPaymentStrategy
    {
        public int MyProperty { get; set; }
        public PartialPaymentStrategy()
        {
            MyProperty = 0;
        }
        public Payment Name { get; set; } = Payment.Partial;

        public string Execute()
        {
            return nameof(PartialPaymentStrategy);
        }
    }
}

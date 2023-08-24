using StrategyPattern.Enums;

namespace StrategyPattern.Services.PaymentMethods
{
    public class ConcretePaymentStrategy : IPaymentStrategy
    {
        public int MyProperty { get; set; }
        public ConcretePaymentStrategy()
        {
            MyProperty = 0;
        }
        public Payment Name { get; set; } = Payment.Concrete;

        public string Execute()
        {
            return nameof(ConcretePaymentStrategy);
        }
    }
}

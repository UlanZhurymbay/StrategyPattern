using StrategyPattern.Enums;

namespace StrategyPattern.Services.PaymentMethods
{
    public interface IPaymentStrategy
    {
        public Payment Name { get; set; }
        string Execute();
    }

    //for Parrent
    public interface IConcreteStrategy : IPaymentStrategy
    {
    }
    //for Parrent
    public interface IPartialStrategy : IPaymentStrategy
    {
    }
}

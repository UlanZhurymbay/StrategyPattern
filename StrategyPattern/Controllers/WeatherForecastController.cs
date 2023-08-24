using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Enums;
using StrategyPattern.Services;

namespace StrategyPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly PaymentStrategyDictionary _paymentDictioanry;
        private readonly PaymentStrategyEnumerable _paymentEnumerable;
        private readonly PaymentStrategyDelegate _paymentDelegate;
        public WeatherForecastController(
            //PaymentStrategyDictionary paymentDictioanry, 
            //PaymentStrategyEnumerable paymentEnumerable, 
            PaymentStrategyDelegate paymentDelegate
            )
        {
            //_paymentDictioanry = paymentDictioanry;
            //_paymentEnumerable = paymentEnumerable;
            _paymentDelegate = paymentDelegate;
        }

        [HttpGet("GetDictioanry/")]
        public string Get(Payment payment)
        {
            try
            {
                return _paymentDictioanry.ExecuteStrategy(payment);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("GetEnumerable/")]
        public string Get2(Payment payment)
        {
            try
            {
                return _paymentEnumerable.ExecuteStrategy(payment);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("PaymentStrategyDelegate/")]
        public string Get3(Payment payment)
        {
            try
            {
                return _paymentDelegate(payment).Execute();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
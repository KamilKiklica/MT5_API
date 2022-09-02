using Microsoft.AspNetCore.Mvc;

namespace MT5_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private static IEnumerable<TradeResponse> tradeList { get; set; }

        public TradeController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<TradeResponse>> GetAll()
        {
            return Ok(tradeList);
        }

        [HttpPost]
        public ActionResult SetAll(IEnumerable<TradeResponse> trades)
        {
            tradeList = trades;
            return Ok();
        }
    }

    public class TradeResponse
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double Volume { get; set; }
        public string Comment { get; set; }
        public bool IsBuying { get; set; }
    }
}
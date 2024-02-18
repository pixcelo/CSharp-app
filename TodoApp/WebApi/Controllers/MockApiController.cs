using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockApiController : ControllerBase
    {
        private IConfiguration _configuration;

        public MockApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetChartData")]
        public JsonResult GetChartData()
        {
            var data = new List<ChartData>
            {
                new ChartData {Name = "Page A", Uv = 4000, Pv = 2400, Amt = 2400 },
                new ChartData {Name = "Page B", Uv = 3000, Pv = 1398, Amt = 2210 },
                new ChartData {Name = "Page C", Uv = 2000, Pv = 9800, Amt = 2290 },
                new ChartData {Name = "Page D", Uv = 2780, Pv = 3908, Amt = 2000 },
                new ChartData {Name = "Page E", Uv = 1890, Pv = 4800, Amt = 2181 },
                new ChartData {Name = "Page F", Uv = 2390, Pv = 3800, Amt = 2500 },
                new ChartData {Name = "Page G", Uv = 3490, Pv = 4300, Amt = 2100 }
            };

            return new JsonResult(data);
        }

        public class ChartData
        {
            public string? Name { get; set; }
            public int Uv { get; set; }
            public int Pv { get; set; }
            public int Amt { get; set; }
        }

    }
}

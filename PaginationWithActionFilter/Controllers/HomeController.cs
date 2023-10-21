using Microsoft.AspNetCore.Mvc;
using PaginationWithActionFilter.ActionFilters;
using PaginationWithActionFilter.DataAccesLayer;
using PaginationWithActionFilter.Models;

namespace PaginationWithActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public PagingModel PagingModel { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// QueryString'ten Paging bilgileri gönderilince filterlere uygun veriler döner.
        /// ?Paging={"PageNumber":1,"PageSize":10,"Filters":[{"field":"Name","operator":"contains","value":"1"},{"field":"Name","operator":"contains","value":"2"}],"logic":"or"}
        /// </summary>
        [HttpGet(Name = "GetAll")]
        [ServiceFilter(typeof(FilteringAttribute))]
        public IActionResult GetAll()
        {
            DumpContext dumpContext = new DumpContext();

            return Ok(dumpContext.GetAll(PagingModel));
        }
    }
}
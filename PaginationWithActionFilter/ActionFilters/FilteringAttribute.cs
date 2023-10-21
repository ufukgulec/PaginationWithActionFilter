using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PaginationWithActionFilter.Controllers;
using PaginationWithActionFilter.Models;

namespace PaginationWithActionFilter.ActionFilters
{
    /// <summary>
    /// ActionFilter olarak oluşturulan filtre mekanizmasıdır.
    /// Program.cs'de Scoped olarak eklenmiştir.
    /// Kullanım: [ServiceFilter(typeof(FilteringAttribute))]
    /// </summary>
    public class FilteringAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is HomeController controller)
            {
                controller.PagingModel = GetPagingValue(context);
            }
        }
        /// <summary>
        /// HttpContext.Request.Query'den 'Paging' olarak etiketlenmiş alanı yakalar.
        /// </summary>
        /// <param name="context">ActionExecutingContext</param>
        /// <returns>'Paging' olarak etiketlenmiş alanı PagingModel olarak döner.</returns>
        public static PagingModel GetPagingValue(ActionExecutingContext context)
        {
            var value = context.HttpContext.Request.Query["Paging"];

            if (!string.IsNullOrEmpty(value))
            {
                var paged = JsonConvert.DeserializeObject<PagingModel>(value);
                if (paged is not null)
                    return paged;
                else
                    return new PagingModel();
            }
            else
            {
                return new PagingModel();
            }
        }
    }
}

using PaginationWithActionFilter.Extensions;
using PaginationWithActionFilter.Models;

namespace PaginationWithActionFilter.DataAccesLayer
{
    // Veritabanı senaryosu
    public class DumpContext
    {
        /// <summary>
        /// Fake veritabanından varlıklar filtrelenerek döner.
        /// </summary>
        /// <param name="pagingModel">Request Query'de doldurulan PagingModel sınıfı</param>
        /// <returns>Queryable<DumpModel></returns>
        public IQueryable<DumpModel> GetAll(PagingModel pagingModel)
        {
            // IQueryable
            var datas = DataBase.Models().Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize)
                  .Take(pagingModel.PageSize);

            datas = BuildFilterExtension<DumpModel>.ApplyFilter(datas, pagingModel);

            return datas;
        }
    }
}

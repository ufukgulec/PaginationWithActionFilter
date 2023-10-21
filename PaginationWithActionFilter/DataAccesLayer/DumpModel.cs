namespace PaginationWithActionFilter.DataAccesLayer
{
    public class DumpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public static class DataBase
    {
        public static IQueryable<DumpModel> Models()
        {
            List<DumpModel> list = new List<DumpModel>();

            list.AddRange(new List<DumpModel>
            {
                new DumpModel{ Id = 1, Name = "Deneme 1" },
                new DumpModel{ Id = 2, Name = "Deneme 2" },
                new DumpModel{ Id = 3, Name = "Deneme 3" },
                new DumpModel{ Id = 4, Name = "Deneme 4" },
                new DumpModel{ Id = 5, Name = "Deneme 5" }
            });

            return list.AsQueryable();
        }
    }
}

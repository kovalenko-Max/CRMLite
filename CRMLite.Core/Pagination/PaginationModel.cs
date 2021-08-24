using System.Collections.Generic;

namespace CRMLite.Core.Pagination
{
    public class PaginationModel<T>
    {
        public  int CountItems { get; set; }
        public int PageLimit { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}

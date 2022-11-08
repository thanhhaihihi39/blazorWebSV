using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorNhiber1.Data
{
    public class SinhVienPaging
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}

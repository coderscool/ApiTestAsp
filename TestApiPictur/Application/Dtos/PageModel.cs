using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiPictur.Application.Dtos
{
    public class PageModel<T> : PagingRequestBase
    {
        public List<T> Items { get; set; }
    }
}

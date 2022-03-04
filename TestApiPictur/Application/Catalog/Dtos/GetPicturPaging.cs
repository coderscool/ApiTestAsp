using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Application.Dtos;

namespace TestApiPictur.Application.Catalog.Dtos
{
    public class GetPicturPaging : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiPictur.Application.Dtos
{
    public class PagingRequestBase
    {
        public int _pages { get; set; }
        public int _limit { get; set; }
        public int TotalRecord { get; set; }
    }
}

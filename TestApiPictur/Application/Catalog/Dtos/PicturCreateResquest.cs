using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiPictur.Application.Catalog.Dtos
{
    public class PicturCreateResquest
    {
        public int PicturId { get; set; }
        public string Title { get; set; }
        public string Leter { get; set; }
    }
}

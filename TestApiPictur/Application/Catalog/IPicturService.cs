using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Application.Catalog.Dtos;
using TestApiPictur.Application.Dtos;
using TestApiPictur.Models;

namespace TestApiPictur.Application.Catalog
{
    public interface IPicturService
    {
        Task<int> Create(PicturCreateResquest resquest);

        Task<int> Update(PicturUpdateResquest resquest);

        Task<int> Delete(int PicturId);

        Task<List<PicturModel>> GetAll();

        Task<Pictur> GetById(int PicturId);

        Task<PageModel<Pictur>> GetAllPaging(GetPicturPaging request);
    }
}

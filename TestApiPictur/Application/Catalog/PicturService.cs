using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Application.Catalog.Dtos;
using TestApiPictur.Application.Dtos;
using TestApiPictur.Data.EF;
using TestApiPictur.Models;

namespace TestApiPictur.Application.Catalog
{
    public class PicturService : IPicturService
    {
        private readonly TestApiPicturDbContext _context;
        public PicturService(TestApiPicturDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PicturCreateResquest resquest)
        {
            var pictur = new Pictur()
            {
                Title = resquest.Title,
                Leter = resquest.Leter
            };
            _context.Picturs.Add(pictur);
             await _context.SaveChangesAsync();
            return pictur.PicturId;
        }

        public async Task<int> Delete(int PicturId)
        {
            var pictur = await _context.Picturs.FindAsync(PicturId);
            _context.Picturs.Remove(pictur);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PicturModel>> GetAll()
        {
            var query = from p in _context.Picturs
                        select new { p };

            var data = await query.Select(x => new PicturModel()
            {
                PicturId = x.p.PicturId,
                Title = x.p.Title,
                Leter = x.p.Leter
            }).ToListAsync();

            return data;

        }

        public async Task<PageModel<Pictur>> GetAllPaging(GetPicturPaging request)
        {
            var query = from p in _context.Picturs
                        select new { p };

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request._pages - 1)* request._limit)
                .Take(request._limit)
                .Select(x => new Pictur()
            {
                PicturId = x.p.PicturId,
                Title = x.p.Title,
                Leter = x.p.Leter
            }).ToListAsync();

            var pageModel = new PageModel<Pictur>()
            {
                TotalRecord = totalRow,
                Items = data,
                _limit = request._limit,
                _pages = request._pages
            };
            return pageModel;
        }

        public async Task<Pictur> GetById(int PicturId)
        {
            var pictur = await _context.Picturs.FindAsync(PicturId);
            return pictur;
        }

        public async Task<int> Update(PicturUpdateResquest resquest)
        {
            var pictur = await _context.Picturs.FindAsync(resquest.PicturId);
            if (pictur == null) throw new Exception("cannot find a pictur");

            pictur.Leter = resquest.Leter;
            pictur.Title = resquest.Title;

            return await _context.SaveChangesAsync();
        }
    }
}

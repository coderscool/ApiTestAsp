using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Application.Catalog;
using TestApiPictur.Application.Catalog.Dtos;

namespace TestApiPictur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturController : ControllerBase
    {
        private readonly IPicturService _picturService;
        public PicturController(IPicturService picturService)
        {
            _picturService = picturService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var picturs = await _picturService.GetAll();
            return Ok(picturs);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery]GetPicturPaging request)
        {
            var picturs = await _picturService.GetAllPaging(request);
            return Ok(picturs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById( int PicturId)
        {
            var picturs = await _picturService.GetById(PicturId);
            if (picturs == null)
                return BadRequest();
            return Ok(picturs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PicturCreateResquest resquest)
        {
            var result = await _picturService.Create(resquest);
            if (result == 0)
                return BadRequest();

            var pictur = await _picturService.GetById(result);

            return CreatedAtAction(nameof(GetById), new { PicturId = result }, pictur);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int PicturId)
        {
            var result = await _picturService.Delete(PicturId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromForm] PicturUpdateResquest resquest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            resquest.PicturId = Id;
            var affectedResult = await _picturService.Update(resquest);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


    }
}

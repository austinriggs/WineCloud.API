using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCloud2.Domain.Abstract;
using WineCloud2.Models.DAL;

namespace WineCloud2.API.Controllers
{
    [Route("api/cellars")]
    [ApiController]
    [Authorize]
    public class CellarsController : Controller
    {
        private ICellarService _cellarService;

        public CellarsController(ICellarService cellarService)
        {
            _cellarService = cellarService;
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateCellar(CellarVM newCellar)
        {
            try
            {
                var cellar = await _cellarService.CreateCellarAsync(newCellar);

                return Ok(cellar);
            }
            catch
            {
                throw;
            }
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> GetCellars()
        {
            try
            {
                var cellars = await _cellarService.GetCellarsAsync();

                return Ok(cellars);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async  Task<IActionResult> GetCellarById(Guid id)
        {
            try
            {
                var cellar = await _cellarService.GetCellarByIdAsync(id);

                return Ok(cellar);
            }
            catch
            {
                throw;
            }
        }
    }
}
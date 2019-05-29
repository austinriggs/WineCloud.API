using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCloud2.Domain.Abstract;
using WineCloud2.Models.DAL;
using Microsoft.EntityFrameworkCore;

namespace WineCloud2.Domain.Concrete
{
    public class CellarService : ICellarService
    {
        private readonly WineCloudDbContext _ctx;

        public CellarService(WineCloudDbContext context) {
            _ctx = context;
        }

        public async Task<CellarVM> CreateCellarAsync(CellarVM newCellar)
        {
            try
            {
                var cellar = new Cellar() {
                    Description = newCellar.Description
                };

                await _ctx.Cellars.AddAsync(cellar);

                await _ctx.SaveChangesAsync();

                newCellar.Id = cellar.Id;

                return newCellar;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCellarAsync(Guid cellarId)
        {
            try
            {
                var cellar = await _ctx.Cellars
                    .FindAsync(cellarId);

                _ctx.Remove(cellar);

                await _ctx.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CellarVM>> GetCellarsAsync()
        {
            try
            {
                var cellars = await _ctx.Cellars
                    .Select(p => new CellarVM()
                    {
                        Id = p.Id,
                        Description = p.Description
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return cellars;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CellarVM> GetCellarByIdAsync(Guid id)
        {
            try
            {
                var cellar = await _ctx.Cellars
                .FindAsync(id);

                var cellarVM = new CellarVM()
                {
                    Id = cellar.Id,
                    Description = cellar.Description
                };

                return cellarVM;
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<CellarVM> UpdateCellarAsync(Guid cellarId, CellarVM cellar)
        {
            try
            {
                var cellarDb = await _ctx.Cellars.FindAsync(cellarId);

                cellarDb.Description = cellar.Description;

                await _ctx.SaveChangesAsync();

                var cellarVM = new CellarVM()
                {
                    Id = cellarDb.Id,
                    Description = cellarDb.Description
                };

                return cellarVM;
            }
            catch
            {
                throw;
            }
        }
    }
}

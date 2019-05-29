using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WineCloud2.Models.DAL;

namespace WineCloud2.Domain.Abstract
{
    public interface ICellarService
    {
        Task<CellarVM> CreateCellarAsync(CellarVM newCellar);

        Task<IEnumerable<CellarVM>> GetCellarsAsync();

        Task<CellarVM> GetCellarByIdAsync(Guid id);

        Task<CellarVM> UpdateCellarAsync(Guid cellarId, CellarVM cellar);

        Task DeleteCellarAsync(Guid cellarId);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WineCloud2.Models.DAL;
using WineCloud2.Models.ViewModels;

namespace WineCloud2.Domain.Abstract
{
    public interface IBottleService
    {
        Task<IEnumerable<BottleTypeVM>> GetBottleTypes();

        Task<BottleTypeVM> GetBottleTypeById(Guid id);

        Task<BottleVM> GetBottleById(Guid id);

        Task<BottleType> AddBottleType(CreateBottleTypeVM bottleType);

        Task<Bottle> AddBottle(Guid bottleTypeId, BottleVM bottle);

        Task<BottleTypeVM> UpdateBottleType(Guid id, BottleTypeVM bottleType, bool cascade);

        Task<BottleVM> UpdateBottle(Guid id, BottleVM bottle);

        Task<BottleVM> DrinkBottle(Guid id);

        Task RemoveBottleType(Guid id);

        Task RemoveBottle(Guid id);
    }
}

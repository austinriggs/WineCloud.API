using System;
using System.Collections.Generic;
using WineCloud2.Domain.Abstract;
using WineCloud2.Models.DAL;
using WineCloud2.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WineCloud2.Domain.Concrete
{
    public class BottleService : IBottleService
    {
        private readonly WineCloudDbContext _ctx;

        public BottleService(WineCloudDbContext context)
        {
            _ctx = context;
        }

        public async Task<BottleType> AddBottleType(CreateBottleTypeVM bottleType)
        {
            try
            {
                var newBottleType = new BottleType()
                {
                    Color = bottleType.Color,
                    YearVintage = bottleType.YearVintage,
                    Winery = bottleType.Winery,
                    Varietal = bottleType.Varietal,
                    Vinyard = bottleType.Vinyard,
                    Name = bottleType.Name,
                    PurchaseDate = bottleType.PurchaseDate,
                    PurchasePrice = bottleType.PurchasePrice,
                    StorageDate = bottleType.StorageDate,
                    StorageTemparature = bottleType.StorageTemparature,
                    CreatedById = bottleType.CreatedById,
                    OpenedDate = bottleType.OpenedDate,
                    Notes = bottleType.Notes
                };

                for(var i = 0; i < bottleType.NewBottleCount; i++)
                {
                    var newBottle = new Bottle()
                    {
                        Color = bottleType.Color,
                        YearVintage = bottleType.YearVintage,
                        Winery = bottleType.Winery,
                        Varietal = bottleType.Varietal,
                        Vinyard = bottleType.Vinyard,
                        Name = bottleType.Name,
                        PurchaseDate = bottleType.PurchaseDate,
                        PurchasePrice = bottleType.PurchasePrice,
                        StorageDate = bottleType.StorageDate,
                        StorageTemparature = bottleType.StorageTemparature,
                        CreatedById = bottleType.CreatedById,
                        CreatedDateTime = bottleType.CreatedDateTime,
                        OpenedDate = bottleType.OpenedDate,
                        Notes = bottleType.Notes
                    };

                    newBottleType.Bottles.Add(newBottle);
                }

                _ctx.BottleTypes.Add(newBottleType);

                await _ctx.SaveChangesAsync();

                return newBottleType;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Bottle> AddBottle(Guid bottleTypeId, BottleVM bottle)
        {
            try
            {
                var bottleType = await _ctx.BottleTypes.FindAsync(bottleTypeId);

                if (bottleType == null)
                {
                    var newBottleType = new CreateBottleTypeVM()
                    {
                        Color = bottle.Color,
                        YearVintage = bottle.YearVintage,
                        Winery = bottle.Winery,
                        Varietal = bottle.Varietal,
                        Vinyard = bottle.Vinyard,
                        Name = bottle.Name,
                        PurchaseDate = bottle.PurchaseDate,
                        PurchasePrice = bottle.PurchasePrice,
                        StorageDate = bottle.StorageDate,
                        StorageTemparature = bottle.StorageTemparature,
                        CreatedById = bottle.CreatedById,
                        CreatedDateTime = bottle.CreatedDateTime,
                        OpenedDate = bottle.OpenedDate,
                        Notes = bottle.Notes,
                        NewBottleCount = 1
                    };

                    var createdBottleType = await AddBottleType(newBottleType);
                    return createdBottleType.Bottles.FirstOrDefault();
                }
                else
                {
                    var newBottle = new Bottle()
                    {
                        BottleTypeId = bottleTypeId,
                        Color = bottle.Color,
                        YearVintage = bottle.YearVintage,
                        Winery = bottle.Winery,
                        Varietal = bottle.Varietal,
                        Vinyard = bottle.Vinyard,
                        Name = bottle.Name,
                        PurchaseDate = bottle.PurchaseDate,
                        PurchasePrice = bottle.PurchasePrice,
                        StorageDate = bottle.StorageDate,
                        StorageTemparature = bottle.StorageTemparature,
                        CreatedById = bottle.CreatedById,
                        CreatedDateTime = bottle.CreatedDateTime,
                        OpenedDate = bottle.OpenedDate,
                        Notes = bottle.Notes
                    };

                    _ctx.Bottles.Add(newBottle);

                    await _ctx.SaveChangesAsync();

                    return newBottle;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<BottleTypeVM>> GetBottleTypes()
        {
            try
            {
                var bottleTypes = await _ctx.BottleTypes
                    .Include(p => p.Bottles)
                    .Select(b => new BottleTypeVM()
                    {
                        Id = b.Id,
                        Color = b.Color,
                        YearVintage = b.YearVintage,
                        Winery = b.Winery,
                        Varietal = b.Varietal,
                        Vinyard = b.Vinyard,
                        Name = b.Name,
                        PurchaseDate = b.PurchaseDate,
                        PurchasePrice = b.PurchasePrice,
                        StorageDate = b.StorageDate,
                        StorageTemparature = b.StorageTemparature,
                        CreatedById = b.CreatedById,
                        CreatedDateTime = b.CreatedDateTime,
                        OpenedDate = b.OpenedDate,
                        Notes = b.Notes,
                        Bottles = b.Bottles

                    })
                    .AsNoTracking()
                    .ToListAsync();

                return bottleTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BottleTypeVM> GetBottleTypeById(Guid id)
        {
            try
            {
                var bottleTypeVM = await _ctx.BottleTypes
                    .Include(p => p.Bottles)
                    .Select(b => new BottleTypeVM()
                    {
                        Id = b.Id,
                        Color = b.Color,
                        YearVintage = b.YearVintage,
                        Winery = b.Winery,
                        Varietal = b.Varietal,
                        Vinyard = b.Vinyard,
                        Name = b.Name,
                        PurchaseDate = b.PurchaseDate,
                        PurchasePrice = b.PurchasePrice,
                        StorageDate = b.StorageDate,
                        StorageTemparature = b.StorageTemparature,
                        CreatedById = b.CreatedById,
                        CreatedDateTime = b.CreatedDateTime,
                        OpenedDate = b.OpenedDate,
                        Notes = b.Notes,
                        Bottles = b.Bottles
                    })
                    .AsNoTracking()
                    .FirstAsync();

                return bottleTypeVM;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BottleVM> GetBottleById(Guid id)
        {
            try
            {
                var bottleVM = await _ctx.Bottles
                    .Select(b => new BottleVM()
                    {
                        Id = b.Id,
                        Color = b.Color,
                        YearVintage = b.YearVintage,
                        Winery = b.Winery,
                        Varietal = b.Varietal,
                        Vinyard = b.Vinyard,
                        Name = b.Name,
                        PurchaseDate = b.PurchaseDate,
                        PurchasePrice = b.PurchasePrice,
                        StorageDate = b.StorageDate,
                        StorageTemparature = b.StorageTemparature,
                        CreatedById = b.CreatedById,
                        CreatedDateTime = b.CreatedDateTime,
                        OpenedDate = b.OpenedDate,
                        Notes = b.Notes
                    })
                    .AsNoTracking()
                    .FirstAsync();

                return bottleVM;
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveBottleType(Guid id)
        {
            try
            {
                var bottleType = await _ctx.BottleTypes.FindAsync(id);

                _ctx.BottleTypes.Remove(bottleType);

                await _ctx.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveBottle(Guid id)
        {
            try
            {
                var bottle = await _ctx.Bottles.FindAsync(id);

                _ctx.Bottles.Remove(bottle);

                await _ctx.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<BottleTypeVM> UpdateBottleType(Guid id, BottleTypeVM bottleType, bool cascade)
        {
            try
            {
                var updateBottleType = await _ctx.BottleTypes
                    .Include(p => p.Bottles)
                    .Where(p => p.Id == id)
                    .FirstAsync();

                updateBottleType.Color = bottleType.Color;
                updateBottleType.YearVintage = bottleType.YearVintage;
                updateBottleType.Winery = bottleType.Winery;
                updateBottleType.Varietal = bottleType.Varietal;
                updateBottleType.Vinyard = bottleType.Vinyard;
                updateBottleType.Name = bottleType.Name;
                updateBottleType.PurchaseDate = bottleType.PurchaseDate;
                updateBottleType.PurchasePrice = bottleType.PurchasePrice;
                updateBottleType.StorageDate = bottleType.StorageDate;
                updateBottleType.StorageTemparature = bottleType.StorageTemparature;
                updateBottleType.OpenedDate = bottleType.OpenedDate;
                updateBottleType.Notes = bottleType.Notes;

                if (cascade)
                {
                    foreach (var bottle in updateBottleType.Bottles)
                    {
                        bottle.Color = bottleType.Color;
                        bottle.YearVintage = bottleType.YearVintage;
                        bottle.Winery = bottleType.Winery;
                        bottle.Varietal = bottleType.Varietal;
                        bottle.Vinyard = bottleType.Vinyard;
                        bottle.Name = bottleType.Name;
                        bottle.PurchaseDate = bottleType.PurchaseDate;
                        bottle.PurchasePrice = bottleType.PurchasePrice;
                        bottle.StorageDate = bottleType.StorageDate;
                        bottle.StorageTemparature = bottleType.StorageTemparature;
                        bottle.OpenedDate = bottleType.OpenedDate;
                        bottle.Notes = bottleType.Notes;
                    }
                }

                await _ctx.SaveChangesAsync();

                return bottleType;

            }
            catch
            {
                throw;
            }
        }

        public async Task<BottleVM> UpdateBottle(Guid id, BottleVM bottle)
        {
            try
            {
                var updateBottle = await _ctx.Bottles.FindAsync(id);

                updateBottle.Color = bottle.Color;
                updateBottle.YearVintage = bottle.YearVintage;
                updateBottle.Winery = bottle.Winery;
                updateBottle.Varietal = bottle.Varietal;
                updateBottle.Vinyard = bottle.Vinyard;
                updateBottle.Name = bottle.Name;
                updateBottle.PurchaseDate = bottle.PurchaseDate;
                updateBottle.PurchasePrice = bottle.PurchasePrice;
                updateBottle.StorageDate = bottle.StorageDate;
                updateBottle.StorageTemparature = bottle.StorageTemparature;
                updateBottle.OpenedDate = bottle.OpenedDate;
                updateBottle.Notes = bottle.Notes;

                await _ctx.SaveChangesAsync();

                return bottle;

            }
            catch
            {
                throw;
            }
        }

        public async Task<BottleVM> DrinkBottle(Guid id)
        {
            try
            {
                var updateBottle = await _ctx.Bottles.FindAsync(id);

                updateBottle.OpenedDate = DateTime.UtcNow;

                await _ctx.SaveChangesAsync();

                var bottleVM = new BottleVM()
                {
                    Id = updateBottle.Id,
                    Color = updateBottle.Color,
                    YearVintage = updateBottle.YearVintage,
                    Winery = updateBottle.Winery,
                    Varietal = updateBottle.Varietal,
                    Vinyard = updateBottle.Vinyard,
                    Name = updateBottle.Name,
                    PurchaseDate = updateBottle.PurchaseDate,
                    PurchasePrice = updateBottle.PurchasePrice,
                    StorageDate = updateBottle.StorageDate,
                    StorageTemparature = updateBottle.StorageTemparature,
                    CreatedById = updateBottle.CreatedById,
                    CreatedDateTime = updateBottle.CreatedDateTime,
                    OpenedDate = updateBottle.OpenedDate,
                    Notes = updateBottle.Notes

                };

                return bottleVM;
            }
            catch
            {
                throw;
            }
        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WineCloud2.Domain.Abstract;
using WineCloud2.Models.DAL;
using WineCloud2.Models.ViewModels;

namespace WineCloud2.Domain.Concrete
{
    public class UserService : IUserService
    {
        private readonly WineCloudDbContext _ctx;

        public UserService(WineCloudDbContext context) {
            _ctx = context;
        }

        public async Task<UserVM> CreateUserAsync(UserVM user)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                _ctx.Users.Add(newUser);

                var cellar = new Cellar()
                {
                    Description = user.LastName + "'s Cellar"
                };

                _ctx.Cellars.Add(cellar);

                await _ctx.SaveChangesAsync();

                user.Id = newUser.Id;
                user.CreatedDateTime = newUser.CreatedDateTime;

                return user;
            }
            catch
            {
                throw;
            }
            
        }
    }
}

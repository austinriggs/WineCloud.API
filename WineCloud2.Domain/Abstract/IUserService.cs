using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WineCloud2.Models.ViewModels;

namespace WineCloud2.Domain.Abstract
{
    public interface IUserService
    {
        Task<UserVM> CreateUserAsync(UserVM user);
    }
}

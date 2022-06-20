using AutoMapper;
using Day63Demo.Data;
using Day63Demo.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day63Demo.Models.Services
{
    public interface IUsersService 
    {
        Task<List<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(int id);
        Task CreateAsync(UserViewModel UserViewModel);

        Task UpdateAsync(UserViewModel UserViewModel);
        Task DeleteAsync(int id);


    }
}

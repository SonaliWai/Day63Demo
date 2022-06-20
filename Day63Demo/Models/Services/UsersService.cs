using AutoMapper;
using Day63Demo.Data;
using Day63Demo.Data.Models;
using Day63Demo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day63Demo.Models.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            // EF returns List of DataModel
            var users = await _dbContext.Users.ToListAsync();
           
            var usersViewModel = users
                .Select(d => _mapper.Map<UserViewModel>(d))
                .ToList();

            // return List of ViewModel
            return usersViewModel;
        }
        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            // EF returns List of DataModel
            var user = await _dbContext.Users.SingleAsync(d => d.Id == id);

            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }
        public async Task CreateAsync(UserViewModel userViewModel)
        {
            
            var userToAdd = _mapper.Map<User>(userViewModel);

            await _dbContext.Users.AddAsync(userToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserViewModel userViewModel)
        {
            var userToUpdate = await _dbContext.Users.SingleAsync(d => d.Id == userViewModel.Id);


            userToUpdate.FirstName = userViewModel.FirstName;
            userToUpdate.LastName = userViewModel.LastName;
            userToUpdate.DateOfBirth = userViewModel.DateOfBirth;
            userToUpdate.Pan = userViewModel.Pan;
            userToUpdate.Address = userViewModel.Address;
            userToUpdate.Gender = userViewModel.Gender;
            userToUpdate.MobileNumber = userViewModel.MobileNumber;
            userToUpdate.Email = userViewModel.Email;
            userToUpdate.Comments = userViewModel.Comments;
            userToUpdate.DepartmentRefId = userViewModel.DepartmentRefId;

            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userToDelete = await _dbContext.Users.SingleAsync(d => d.Id == id);

            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
        }


    }
}


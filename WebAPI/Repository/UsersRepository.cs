using WebAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebAPI.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUsersByID(int ID);
        Task<Users> InsertUsers(Users objUsers);
        Task<Users> UpdateUsers(Users objUsers);
        bool DeleteUsers(int ID);
    }
    public class UsersRepository : IUsersRepository
    {

        private readonly APIDbContext _appDBContext;

        public UsersRepository(APIDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _appDBContext.Users.ToListAsync();
        }

        public async Task<Users> GetUsersByID(int ID)
        {
            return await _appDBContext.Users.FindAsync(ID);
        }

        public async Task<Users> InsertUsers(Users objUsers)
        {
            _appDBContext.Users.Add(objUsers);
            await _appDBContext.SaveChangesAsync();
            return objUsers;
        }

        public async Task<Users> UpdateUsers(Users objUsers)
        {
            _appDBContext.Entry(objUsers).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objUsers;
        }

        public bool DeleteUsers(int ID)
        {
            bool result = false;
            var department = _appDBContext.Users.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
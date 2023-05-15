using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
//using 
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    
    public class UserRepository: IUserRepository
    {
        Store214087579Context _store214087579Context;
        public UserRepository(Store214087579Context store214104465Context)
        {
            _store214087579Context = store214104465Context;
        }
        static private string path = "..\\users.JSON";
        public async Task<User> addNewUser(User newUser)
        {
            await _store214087579Context.Users.AddAsync(newUser);
            await _store214087579Context.SaveChangesAsync();
            return newUser;
            //int numberOfUsers = System.IO.File.ReadLines(path).Count();
            //newUser.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(newUser);
            //await System.IO.File.AppendAllTextAsync(path, userJson + Environment.NewLine);

        }

        public async Task<User> getUserById(int id)
        {
            User? user = await _store214087579Context.Users.Where(u=>u.UserId==id).Include(u=>u.Orders).FirstOrDefaultAsync();
            return user!=null?user:null;
        }

        public async Task<User> signIn(User userData)
        {
            var users = await _store214087579Context.Users.Where(user=>user.UserEmail==userData.UserEmail && user.UserPassword==user.UserPassword).ToListAsync();
            return users.Count() == 0 ? null : users[0];
        }

        public async Task updateUser(User updatedUser, int id)
        {
            User userToUpdate = await _store214087579Context.Users.FindAsync(id);
            if (userToUpdate != null)
            {
                _store214087579Context.Entry(userToUpdate).CurrentValues.SetValues(updatedUser);
                await _store214087579Context.SaveChangesAsync();
            }
        }
    }
}
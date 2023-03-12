using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addNewUser(User newUser);
        Task<User> getUserById(int id);
        Task<User> signIn(User uesrData);
        Task updateUser(User updatedUser, int id);
    }
}

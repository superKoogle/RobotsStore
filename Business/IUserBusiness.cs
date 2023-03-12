using Entities;

namespace Business
{
    public interface IUserBusiness
    {
        Task<User> addNewUser(User newUser);
        Task<User> GetUserById(int id);
        Task<User> SignIn(User userData);
        Task updateUser(int id, User updatedUser);
    }
}
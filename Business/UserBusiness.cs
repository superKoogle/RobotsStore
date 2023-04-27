using Entities;
using Repository;
//using Zxcvbn;

namespace Business
{
    public class UserBusiness:IUserBusiness
    {
        IUserRepository userRepository;
        IPasswordBusiness passwordBusiness;

        public UserBusiness(IUserRepository userRepository, IPasswordBusiness passwordBusiness)
        {
            this.userRepository = userRepository;
            this.passwordBusiness = passwordBusiness;
        }
        public async Task<User> addNewUser(User newUser)
        {
            if (await passwordBusiness.goodPassword(newUser.UserPassword) >= 3)
                return await userRepository.addNewUser(newUser);
            else
                return null;
        }
        public async Task<User> GetUserById(int id)
        {
            return await userRepository.getUserById(id);
        }

        public async Task<User> SignIn(User userData)
        {
            return await userRepository.signIn(userData);
        }

        public async Task updateUser(int id, User updatedUser)
        {
            await userRepository.updateUser(updatedUser, id);
        }

    
    }
}
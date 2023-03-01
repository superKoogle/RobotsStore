using Entities;
using Repository;
using Zxcvbn;

namespace Business
{
    public class UserBusiness
    {
        public static User addNewUser(User newUser)
        {
            if (goodPassword(newUser.Password) >= 3)
                return UserRepository.addNewUser(newUser);
            else
                return null;
        }
        public static User GetUserById(int id)
        {
            return UserRepository.getUserById(id);
        }

        public static User SignIn(User userData)
        {
            return UserRepository.signIn(userData);
        }

        public static void updateUser(int id, User updatedUser)
        {
            UserRepository.updateUser(updatedUser, id);
        }

        public static int goodPassword(string pwd)
        {
            var res = Zxcvbn.Core.EvaluatePassword(pwd);
            return res.Score;
        }
    }
}
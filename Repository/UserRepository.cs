using Entities;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        static private string path = "..\\users.JSON";
        public async Task<User> addNewUser(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            newUser.UserId = numberOfUsers + 1;
            string userJson =JsonSerializer.Serialize(newUser);
            await System.IO.File.AppendAllTextAsync(path, userJson + Environment.NewLine);
            return newUser;
        }

        public async Task<User> getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }

        public async Task<User> signIn(User uesrData)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile =await reader.ReadLineAsync()) != null)
                {
                    User user =  JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == uesrData.Email && user.Password == uesrData.Password)
                        return user;
                }
            }
            return null;
        }

        public async Task updateUser(User updatedUser, int id)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    User user =  JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
                await System.IO.File.WriteAllTextAsync(path, text);
            }
        }
    }
}
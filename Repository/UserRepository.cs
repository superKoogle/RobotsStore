using Entities;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    public class UserRepository
    {
        static private string path = "..\\users.JSON";
        public static User addNewUser(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            newUser.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return newUser;
        }

        public static User getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }

        public static User signIn(User uesrData)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == uesrData.Email && user.Password == uesrData.Password)
                        return user;
                }
            }
            return null;
        }

        public static void updateUser(User updatedUser, int id)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
                System.IO.File.WriteAllText(path, text);
            }
        }
    }
}
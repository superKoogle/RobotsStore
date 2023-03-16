using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    
    public class UserRepository: IUserRepository
    {
        Store214087579Context _store214087579Context;
        public UserRepository(Store214087579Context store214087579Context)
        {
            _store214087579Context = store214087579Context;
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
            User? user = await _store214087579Context.Users.FindAsync(id);
            return user!=null?user:null;
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == id)
            //            return user;
            //    }
            //}
           
        }

        public async Task<User> signIn(User userData)
        {
            List<User>? user = await _store214087579Context.Users.Where(user=>user.UserEmail==userData.UserEmail && user.UserPassword==userData.UserPassword).ToListAsync();
            return user.Count() > 0 ? user[0] : null;
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile =await reader.ReadLineAsync()) != null)
            //    {
            //        User user =  JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserEmail == uesrData.UserEmail && user.UserPassword == uesrData.UserPassword)
            //            return user;
            //    }
            //}
        }

        public async Task updateUser(User updatedUser, int id)
        {
            User user = await _store214087579Context.Users.FindAsync(id);
            if (user != null)
            {
                _store214087579Context.Entry(user).CurrentValues.SetValues(updatedUser);
                await _store214087579Context.SaveChangesAsync();
            }
            
            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //    {

            //        User user =  JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = await System.IO.File.ReadAllTextAsync(path);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
            //    await System.IO.File.WriteAllTextAsync(path, text);
            //}
        }
    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DirtMaster.Models;
using Xamarin.Essentials;

namespace DirtMaster.Service
{
    public static class UserService
    {
        static SQLiteAsyncConnection connection;
        public static bool IsUserLogged = false;
        static async Task Init()
        {
            if (connection == null)
            {
                string userPath = Path.Combine(FileSystem.AppDataDirectory, "thisUserData.db");
                connection = new SQLiteAsyncConnection(userPath);
                await connection.CreateTableAsync<User>();
            }
        }

        public static async Task CreateUserAsync(string name, string password)
        {
            await Init();
            User newUser = new User
            {
                Name = name,
                Password = password
            };
            await connection.InsertAsync(newUser);
        }

        public static async Task ReturnUserAsync(int id)
        {
            await Init();
            await connection.GetAsync<User>(id);
        }

        public static async Task<bool> CheckIfUserValidAsync(string name, string password)
        {
            await Init();
            var query = await connection.Table<User>().FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
            if (query == null) return false;
            else
                return IsUserLogged = true;
        }
    }
}

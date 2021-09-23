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
        public static bool isUserLogged = false;
        static async Task Init()
        {
            if (connection == null)
            {
                string userPath = Path.Combine(FileSystem.AppDataDirectory, "thisUserData.db");
                connection = new SQLiteAsyncConnection(userPath);
                await connection.CreateTableAsync<User>();
            }
        }

        public static async Task CreateUser(string name, string password)
        {
            await Init();
            User newUser = new User
            {
                Name = name,
                Password = password
            };
            await connection.InsertAsync(newUser);
        }

        public static async Task ReturnUser(int id)
        {
            await Init();
            await connection.GetAsync<User>(id);
        }

        public static void CheckIfUserLogged(string name, string password)
        {
            var query = connection.Table<User>().Where(x => x.Name.Equals(name) && x.Password.Equals(password));
            isUserLogged = Convert.ToBoolean(query);
        }
    }
}

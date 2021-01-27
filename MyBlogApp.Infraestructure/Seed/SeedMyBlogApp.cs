using MyBlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBlogApp.Infraestructure.Seed
{
    public class SeedMyBlogApp
    {
        public static void AddUsers(DataContext context)
        {
            if (!context.Users.Any())
            {

                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed/Data/Users.json");

                var usersData = File.ReadAllText(path);
                var users = System.Text.Json.JsonSerializer.Deserialize<ICollection<User>>(usersData);

                foreach (var user in users)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges();

            }
        }
 
    }
}

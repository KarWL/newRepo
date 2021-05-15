using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using newRepo.Data;
using newRepo.Models;
using System;
using System.Linq;

namespace newRepo.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PropertyDB(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PropertyDB>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new Users
                    {
                        Id = Guid.NewGuid(),
                        Name = "Lee",
                        Password = "Lee"
                    },
                    new Users
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kar",
                        Password = "Kar"
                    },
                    new Users
                    {
                        Id = Guid.NewGuid(),
                        Name = "Wee",
                        Password = "Wee"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
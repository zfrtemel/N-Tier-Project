using DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Core.Interfaces;

namespace DataAccess.Seeders
{
    public static class AdminSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MainDbContext>();
            var crypto = scope.ServiceProvider.GetService<ICryptoService>();

            if (!context.Users.Any())
            {
                context.Users.Add(new Entity.Models.User.UserEntity
                {
                    Email = "admin@test.com",
                    Username = "admin",
                    Role = Core.Enum.EUserRole.ADMIN,
                    Password = crypto.Hash("123456789Aa."),
                    CreatedAt = System.DateTime.Now,
                });
            }

            context.SaveChanges();
        }
    }
}

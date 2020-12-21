using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Helpers
{
    public class userHelper : IUserHelper
    {

        private readonly UserManager<User> userManager;

        public userHelper(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entidades;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);



        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


        Task<IdentityResult> UpdateUserAsync(User user);


        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}

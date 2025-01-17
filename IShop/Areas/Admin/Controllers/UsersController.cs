﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IShop.Areas.Admin.Data;
using IShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<Customer> _userManager;
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable viewModel = _userManager.Users.Select(c => new ListCustomersViewModel()
            {
                Id = c.Id,
                FIO = c.FIO,
                Login = c.UserName,
                Email = c.Email
            });
            return View(viewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        IdentityResult result = await _roleManager.DeleteAsync(role);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Edit(string userId)
        //{
        //    // получаем пользователя
        //    User user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        // получем список ролей пользователя
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        var allRoles = _roleManager.Roles.ToList();
        //        ChangeRoleViewModel model = new ChangeRoleViewModel
        //        {
        //            UserId = user.Id,
        //            UserEmail = user.Email,
        //            UserRoles = userRoles,
        //            AllRoles = allRoles
        //        };
        //        return View(model);
        //    }

        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(string userId, List<string> roles)
        //{
        //    // получаем пользователя
        //    User user = await _userManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        // получем список ролей пользователя
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        // получаем все роли
        //        var allRoles = _roleManager.Roles.ToList();
        //        // получаем список ролей, которые были добавлены
        //        var addedRoles = roles.Except(userRoles);
        //        // получаем роли, которые были удалены
        //        var removedRoles = userRoles.Except(roles);

        //        await _userManager.AddToRolesAsync(user, addedRoles);

        //        await _userManager.RemoveFromRolesAsync(user, removedRoles);

        //        return RedirectToAction("UserList");
        //    }

        //    return NotFound();
        //}
    }
}

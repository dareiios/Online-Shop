using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Dto;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> LogIn()
        {
            var model = new LoginDto();
            return View(model);
        }

        //нужны менеджеры и бд, находу почту. если нашлась проверяю пароль. если пароль верный-вхожу. tempData error-ошибка
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(loginDto.Email);
                if(userByEmail != null)
                {
                   var chechPassword = await _userManager.CheckPasswordAsync(userByEmail, loginDto.Password);
                    if(chechPassword == true)
                    {
                        var signInRes = await _signInManager.PasswordSignInAsync(userByEmail, loginDto.Password, false, false);
                        if (signInRes.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["Error"] = "пароль неверный";
                    return View(loginDto);
                    
                }
                TempData["Error"] = "данный пользователь не существует";
                return View(loginDto);

            }
            TempData["Error"] = "Все поля обязательны для заполнения";
            return View(loginDto);
        }


        public async Task<IActionResult> Register()
        {
            var reg = new RegisterDto();
            return View(reg);
        }


        //найти пользоввателя. создать пользователя. присвоить пароль, роль, войти
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = await _userManager.FindByEmailAsync(registerDto.Email);
                if(checkEmail == null)
                {
                    var newUser = new AppUser()
                    {
                        Email = registerDto.Email,
                        UserName = registerDto.Name,
                    };

                    var password = await _userManager.CreateAsync(newUser, registerDto.Password);
                    if (password.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(newUser, UserRoless.User);
                        await _signInManager.SignInAsync(newUser, false);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "пароль не подходит";
                    return View(registerDto);
                }
                TempData["Error"] = "Пользователь уже существует";
                return View(registerDto);
            }
            TempData["Error"] = "Все поля обязательны для заполнения";
            return View(registerDto);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

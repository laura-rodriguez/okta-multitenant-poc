﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace okta_aspnetcore_mvc_example.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, new string[] { "tenant1"});
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignIn2()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, new string[] { "tenant2"});

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                     OktaDefaults.MvcAuthenticationScheme,
                     CookieAuthenticationDefaults.AuthenticationScheme,
                },
                new AuthenticationProperties { RedirectUri = "/Home/" });
        }
    }
}
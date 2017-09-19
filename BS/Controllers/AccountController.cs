using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BS.Data.Model.System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BS.Controllers
{
	public class AccountController : Controller
	{
		public AccountController(DomainModelPostgreSqlContext context)
		{
			_context = context;
		}
		private readonly DomainModelPostgreSqlContext _context;

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{

			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(User model)
		{
			var user = _context.Users.SingleOrDefault(t => t.Login == model.Login && t.Password == model.Password);
			if (user == null)
			{
				ModelState.AddModelError("", "Пользователь не найден");
				return View(model);
			}
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, "Fake User"),
				new Claim("age", "25", ClaimValueTypes.Integer)
			};

			var identity = new ClaimsIdentity("Cookies");
			identity.AddClaims(claims);

			var principal = new ClaimsPrincipal(identity);

			await HttpContext.Authentication.SignInAsync("Cookies",
				principal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
				});

			return RedirectToAction("Index", "Home");
		}
	}
}

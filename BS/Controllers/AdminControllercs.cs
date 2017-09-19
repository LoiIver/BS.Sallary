using BS.Data.Model.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Controllers
{
    public class AdminController : Controller
    {
		private readonly DomainModelPostgreSqlContext _context;
		public AdminController(DomainModelPostgreSqlContext context)
		{
			_context = context;
		}

		public ActionResult Users()
		{
			var users = _context.Users.ToList();

			return View("Index", users);

		}
		[HttpGet]
		public ActionResult Edit(int userId)
		{
			var user = _context.Users.SingleOrDefault(t => t.UserId == userId);

			if (user == null)
				return NotFound();

			return View(user);
		}

		[HttpPost]
		public ActionResult Edit(User model)
		{
			var user = _context.Users.SingleOrDefault(t => t.UserId == model.UserId);
			if (user == null)
				return RedirectToAction("Index");
			user.FirstName = model.FirstName;
			_context.SaveChanges();
			return View(user);
		}
	}
}

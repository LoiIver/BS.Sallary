using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BS.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public HomeController(DomainModelPostgreSqlContext context)
		{
			_context = context;
		}
		private readonly DomainModelPostgreSqlContext _context;
		public IActionResult Index()
		{
			//foreach( var service in db.Services.First())
		 
			return View(_context.ServiceTypes.First());
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}

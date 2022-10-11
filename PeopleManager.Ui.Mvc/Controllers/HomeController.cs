using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Data;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly Database _database;

		public HomeController(Database database)
		{
			_database = database;
		}

		public IActionResult Index()
		{
			var people = _database.People.ToList();
			return View(people);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		
	}
}

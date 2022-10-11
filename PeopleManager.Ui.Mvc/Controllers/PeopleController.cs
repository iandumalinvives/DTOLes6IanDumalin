using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Data;
using PeopleManager.Model;
using PeopleManager.Services.Abstractions;

namespace PeopleManager.Ui.Mvc.Controllers
{
	public class PeopleController : Controller
	{
		private readonly IPersonService _personService;

		public PeopleController(IPersonService personService)
		{
			_personService = personService;
		}

		public IActionResult Index()
		{
			var people = _personService.Find();
			return View(people);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Person person)
		{
			if (!string.IsNullOrEmpty(person.FirstName) && person.FirstName.ToLower().Trim().Contains("john"))
			{
				ModelState.AddModelError("", "People with the name John are not welcome here!");
			}

			if (!ModelState.IsValid)
			{
				return View(person);
			}

			_personService.Create(person);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var person = _personService.Get(id);

			if (person is null)
			{
				return RedirectToAction("Index");
			}

			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(Person person)
		{
			if (!ModelState.IsValid)
			{
				return View(person);
			}

			_personService.Update(person.Id, person);
			
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var person = _personService.Get(id);

			if (person is null)
			{
				return RedirectToAction("Index");
			}

			return View(person);
		}

		[HttpPost]
		[Route("People/Delete/{id}")]
		public IActionResult DeleteConfirmed(int id)
		{
			_personService.Delete(id);

			return RedirectToAction("Index");
		}
	}
}

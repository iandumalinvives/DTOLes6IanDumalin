using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Data;
using PeopleManager.Model;
using PeopleManager.Services.Abstractions;

namespace PeopleManager.Services
{
	public class PersonService : IPersonService
	{
		private readonly Database _database;

		public PersonService(Database database)
		{
			_database = database;
		}

		public Person Get(int id)
		{
			var person = _database.People
				.SingleOrDefault(p => p.Id == id);

			return person;
		}

		public IList<Person> Find()
		{
			var people = _database.People
				.ToList();

			return people;
		}


		public Person Create(Person person)
		{
			_database.People.Add(person);
			_database.SaveChanges();

			return person;
		}

		public Person Update(int id, Person person)
		{
			var dbPerson = Get(id);

			if (dbPerson is null)
			{
				return null;
			}

			dbPerson.FirstName = person.FirstName;
			dbPerson.LastName = person.LastName;
			dbPerson.Email = person.Email;
			dbPerson.Age = person.Age;

			_database.SaveChanges();

			return dbPerson;
		}

		public bool Delete(int id)
		{
			var dbPerson = Get(id);

			if (dbPerson is null)
			{
				return false;
			}

			_database.People.Remove(dbPerson);
			_database.SaveChanges();

			return true;
		}
	}
}

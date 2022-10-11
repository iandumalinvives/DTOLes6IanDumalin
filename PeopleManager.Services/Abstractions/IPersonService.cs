using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Model;

namespace PeopleManager.Services.Abstractions
{
	public interface IPersonService
	{
		Person Get(int id);
		IList<Person> Find();

		Person Create(Person person);
		Person Update(int id, Person person);
		bool Delete(int id);
	}
}

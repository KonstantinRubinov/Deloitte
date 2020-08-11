using System.Collections.Generic;

namespace DeloitteSystem
{
	public interface IPersonsRepository
	{
		List<PersonModel> GetAllPersons();
		PersonModel GetPersonByName(string name);
		PersonModel AddPerson(PersonModel newPerson);
		PersonModel UpdatePerson(PersonModel newPerson);
		void DeletePerson(string name);
		List<PersonModel> GetAllPersonsByString(string search);
	}
}

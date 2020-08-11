using System.Collections.Generic;
using System.Data;

namespace DeloitteSystem
{
	public class PersonsManager: IPersonsRepository
	{
		private Person personsDB = Person.Instance;

		public List<PersonModel> GetAllPersons()
		{
			List<PersonModel> personsList = new List<PersonModel>();

			for (int i = 0; i < personsDB.personsSet.Tables["persons"].Rows.Count; i++)
			{
				PersonModel person = new PersonModel();
				person.name = personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString();
				person.workTitle = personsDB.personsSet.Tables["persons"].Rows[i]["workTitle"].ToString();
				person.imageUrl = "assets/images/" + personsDB.personsSet.Tables["persons"].Rows[i]["imageUrl"].ToString();

				personsList.Add(person);
			}
			return personsList;
		}

		public PersonModel GetPersonByName(string name)
		{
			PersonModel person=null;

			for (int i = 0; i < personsDB.personsSet.Tables["persons"].Rows.Count; i++)
			{
				if (personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString().Equals(name))
				{
					person = new PersonModel();
					person.name = personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString();
					person.workTitle = personsDB.personsSet.Tables["persons"].Rows[i]["workTitle"].ToString();
					person.imageUrl = personsDB.personsSet.Tables["persons"].Rows[i]["imageUrl"].ToString();
				}
			}
			return person;
		}

		public PersonModel AddPerson(PersonModel newPerson)
		{
			DataRow myNewRow = personsDB.personsSet.Tables["persons"].NewRow();
			myNewRow["name"] = newPerson.name;
			myNewRow["workTitle"] = newPerson.workTitle;
			myNewRow["imageUrl"] = newPerson.imageUrl;
			personsDB.personsSet.Tables["persons"].Rows.Add(myNewRow);

			return GetPersonByName(newPerson.name);
		}

		public PersonModel UpdatePerson(PersonModel newPerson)
		{
			DataRow[] rows = personsDB.personsSet.Tables["persons"].Select($"id={newPerson.name}");
			DataRow row = rows[0];
			row["name"] = newPerson.name;
			row["workTitle"] = newPerson.workTitle;
			row["imageUrl"] = newPerson.imageUrl;

			return GetPersonByName(newPerson.name);
		}

		public void DeletePerson(string name)
		{
			for (int i = personsDB.personsSet.Tables["persons"].Rows.Count - 1; i >= 0; i--)
			{
				DataRow dr = personsDB.personsSet.Tables["persons"].Rows[i];
				if (dr["name"].Equals(name))
					dr.Delete();
			}
			personsDB.personsSet.Tables["persons"].AcceptChanges();
		}

		public List<PersonModel> GetAllPersonsByString(string search)
		{
			List<PersonModel> personsList = new List<PersonModel>();

			for (int i = 0; i < personsDB.personsSet.Tables["persons"].Rows.Count; i++)
			{
				if (search.Length > 1)
				{
					if (personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString().ToLower().Contains(search.ToLower()) ||
						personsDB.personsSet.Tables["persons"].Rows[i]["workTitle"].ToString().ToLower().Contains(search.ToLower()) ||
						personsDB.personsSet.Tables["persons"].Rows[i]["imageUrl"].ToString().ToLower().Contains(search.ToLower()))
						{
							PersonModel person = new PersonModel();
							person.name = personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString();
							person.workTitle = personsDB.personsSet.Tables["persons"].Rows[i]["workTitle"].ToString();
							person.imageUrl = "assets/images/" + personsDB.personsSet.Tables["persons"].Rows[i]["imageUrl"].ToString();
							personsList.Add(person);
						}
				}
				else
				{
					PersonModel person = new PersonModel();
					person.name = personsDB.personsSet.Tables["persons"].Rows[i]["name"].ToString();
					person.workTitle = personsDB.personsSet.Tables["persons"].Rows[i]["workTitle"].ToString();
					person.imageUrl = "assets/images/" + personsDB.personsSet.Tables["persons"].Rows[i]["imageUrl"].ToString();
					personsList.Add(person);
				}
			}
			return personsList;
		}
	}
}

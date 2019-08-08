using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteSystem
{
	public class Person
	{
		private static Person instance;

		private Person()
		{
			createDataBase();
		}

		public static Person Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Person();
				}
				return instance;
			}
		}



		







		public DataSet personsSet;
		private DataTable persons;

		private void createDataBase()
		{
			MakePersonsTable();
			MakeDataSet();
			addPersons();
		}

		private void addPersons()
		{
			addRow("Kostya Rubinov", "Manager", "0a55b13b-fdca-426f-b080-5b808189d469.jpg");
			addRow("Garry Ragrin", "DevOps", "0d87e188-305e-4467-9d59-4287a9c51766.jpg");
			addRow("Zeev Fraiman", "Teacher", "0e773d44-d4c1-44dc-a7ef-1c28c0bc6bbf.jpg");
			addRow("Zion Alon", "Adviser", "1bbf1ca1-611f-4425-b147-80c705e2e8e4.jpg");
		}

		private void addRow(string name, string workTitle, string imageUrl)
		{
			DataRow myNewRow = personsSet.Tables["persons"].NewRow();
			myNewRow["name"] = name;
			myNewRow["workTitle"] = workTitle;
			myNewRow["imageUrl"] = imageUrl;
			personsSet.Tables["persons"].Rows.Add(myNewRow);
		}









		private void MakeDataSet()
		{
			personsSet = new DataSet("personsSet");
			personsSet.Tables.Add(persons);
		}

		private void MakePersonsTable()
		{
			persons = new DataTable("persons");

			DataColumn imageUrl = new DataColumn("imageUrl");
			imageUrl.DataType = Type.GetType("System.String");
			persons.Columns.Add(imageUrl);

			DataColumn workTitle = new DataColumn("workTitle");
			workTitle.DataType = Type.GetType("System.String");
			persons.Columns.Add(workTitle);

			DataColumn name = new DataColumn("name");
			name.DataType = Type.GetType("System.String");
			persons.Columns.Add(name);


			DataColumn[] keys = new DataColumn[1];
			keys[0] = name;
			persons.PrimaryKey = keys;
		}








	}
}

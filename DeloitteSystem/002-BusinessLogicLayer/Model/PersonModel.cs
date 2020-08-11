namespace DeloitteSystem
{
	public class PersonModel
	{
		private string _imageUrl;
		private string _workTitle;
		private string _name;

		public string imageUrl
		{
			get { return _imageUrl; }
			set { _imageUrl = value; }
		}

		public string workTitle
		{
			get { return _workTitle; }
			set { _workTitle = value; }
		}

		public string name
		{
			get { return _name; }
			set { _name = value; }
		}
	}
}

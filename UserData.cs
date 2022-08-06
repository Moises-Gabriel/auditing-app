using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audit
{
    public class UserData
    {
		public string date = DateTime.Today.ToString("MM_d_yyyy");

		public bool correctInput = true;

		public string path()
        {
			string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), $"{date}_audit.txt");
			return dataPath;
        }

		public void Data()
		{
			Console.WriteLine("Enter name: ");
			string name = Console.ReadLine();

			Console.WriteLine("Enter AIN: ");
			string ain = Console.ReadLine();

			path();
			File.AppendAllText(path(), name + Environment.NewLine + ain + Environment.NewLine);

			Console.WriteLine("Thank you.");
			Console.WriteLine("Please input Department Data.");
		}
	}
}

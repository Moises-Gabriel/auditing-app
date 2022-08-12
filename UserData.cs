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
			bool correctInput = false;
			Console.WriteLine("Enter name: ");
			string name = Console.ReadLine();

			Console.WriteLine("Enter AIN: ");
			string ainString = Console.ReadLine();

            if (ainString.Length != 9)
            {
				Console.WriteLine("AIN was incorrect. Please try again.");
				correctInput = false;
			}
            else
            {
				Console.WriteLine(ainString);
				correctInput = true;
				return;
			}

			path();
			File.AppendAllText(path(), name + Environment.NewLine + ainString + Environment.NewLine);

			Console.WriteLine("Thank you.");
			Console.WriteLine("Please input Department Data.");
		}
	}
}

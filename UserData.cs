using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audit
{
    public class UserData
    {
		public string name = String.Empty;
		public string path = String.Empty;
		public void FileData()
        {
			string date = new string(String.Empty);
			path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), $"{date}_audit.txt");


			//File data
			Console.WriteLine("Please input today's date (MM_DD_YY): ");
			date = Console.ReadLine();
			if (date == null || date.Length < 8)
			{
				Console.WriteLine("Date inputted incorrectly! Please try again.");
				//Program program = new Program();
				//program.Main(args);
			}
		}
		public void Data(List<string> dataInput)
		{
			Console.WriteLine("Enter name: ");
			name = Console.ReadLine();
			dataInput.Add(name); //dataInput[0]

			Console.WriteLine("Enter AIN: ");
			string ain = Console.ReadLine();
			dataInput.Add(ain); //dataInput[1]

			File.AppendAllText(path, dataInput[0] + Environment.NewLine + dataInput[1] + Environment.NewLine);

			Console.WriteLine("Thank you.");
			Console.WriteLine("Please input Department Data.");
		}
	}
}

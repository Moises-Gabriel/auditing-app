using System.Collections.Generic;
using System;
using System.IO;

namespace audit
{
	class Program
	{
		static void Main(string[] args)
		{
			UserData userData = new UserData();
			DepartmentData departmentData = new DepartmentData();

			List<string> dataInput = new List<string>();

			userData.FileData();
			userData.Data(dataInput);

			departmentData.Data();

			Console.WriteLine("Thank you! The data has been saved to .txt files!");
		}
	}
}
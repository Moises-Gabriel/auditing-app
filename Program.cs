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

			userData.Data();

			departmentData.Data();

			Console.WriteLine("Thank you! The data has been saved to a .txt file!");
		}
	}
}
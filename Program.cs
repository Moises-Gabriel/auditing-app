using System.Collections.Generic;
using System;
using System.IO;
using Avalonia;
using Avalonia.ReactiveUI;
using audit.Views;
using audit.Data;

namespace audit
{
    class Program
	{
        [STAThread]
		static void Main(string[] args)
		{
			BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
			var window = new RenderWindow();
			window.Show();

			UserData userData = new UserData();
			DepartmentData departmentData = new DepartmentData();

			//userData.Data();

			//departmentData.Data();

			Console.WriteLine("Thank you! The data has been saved to a .txt file!");
		}

		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<WindowApp>()
				.UsePlatformDetect()
				.LogToTrace()
				.UseReactiveUI();
	}
}
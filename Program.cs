using Avalonia;
using Avalonia.ReactiveUI;
using audit.Views;

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
		}

		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<WindowApp>()
				.UsePlatformDetect()
				.LogToTrace()
				.UseReactiveUI();
	}
}
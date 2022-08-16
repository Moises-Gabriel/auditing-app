using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Data;
using Avalonia.Controls;

namespace audit.Data
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

        public void RetrieveData(object sender,  RoutedEventArgs args)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Associate ID: ");
            string idString = Console.ReadLine();

            while (string.IsNullOrEmpty(idString) || idString.Length < 9)
            {
                Console.WriteLine("ID is incorrect. Please try again.");
                idString = Console.ReadLine();
            }

            path();
            File.AppendAllText(path(), name + Environment.NewLine + idString + Environment.NewLine);

            Console.WriteLine("Thank you.");
            Console.WriteLine("Please input Department Data.");
        }
    }
}

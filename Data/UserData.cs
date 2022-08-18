using Avalonia.Interactivity;
using audit.ViewModels;


namespace audit.Data
{
    public class UserData
    {
        public string date = DateTime.Today.ToString("MM_d_yyyy");

        public FormView? formView;

        public string path()
        {
            string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), $"{date}_audit.txt");
            return dataPath;
        }

        public void RetrieveData()
        {
            string name = formView.name;
            string idString = formView.id;

            while (string.IsNullOrEmpty(idString) || idString.Length < 9)
            {
                //Display warning 
            }

            //Save to txt file
            path();
            File.AppendAllText(path(), name + Environment.NewLine + idString + Environment.NewLine);
        }
    }
}

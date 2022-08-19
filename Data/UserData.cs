using Avalonia.Interactivity;
using audit.ViewModels;


namespace audit.Data
{
    public class UserData
    {
        public string date = DateTime.Today.ToString("MM_d_yyyy");
        public bool warning = false;

        public string DataPath()
        {
            string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), $"{date}_audit.txt");
            return dataPath;
        }

        //TODO: Change method name to reflect its function
        public void RetrieveData(FormView formView)
        {
            string name = formView.TextBoxes[0];
            string idString = formView.TextBoxes[1];

            if (string.IsNullOrEmpty(idString) || idString.Length < 9)
            {
                //Display warning
                warning = true;
                formView.WARNING = "ASSOCIATE ID WAS INCORRECT! PLEASE TRY AGAIN!";
            }
            else
            {
                formView.WARNING = "";
                formView.FormData[0] = "Name: " + formView.TextBoxes[0];
                //formView.FormData[1] = formView.TextBoxes[1];
                warning = false;
            }

            ////Save to txt file
            DataPath();
            File.AppendAllText(DataPath(), name + Environment.NewLine + idString + Environment.NewLine);
        }
    }
}

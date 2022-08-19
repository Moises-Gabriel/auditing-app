using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using audit.Views;
using audit.Data;

namespace audit.ViewModels
{
    public class FormView : ViewModelBase
    {
        UserData userData = new();
        DepartmentData depData = new();

        //Collection of Text Boxes
        private ObservableCollection<string> textBoxes = new(new string[6]);
        public ObservableCollection<string> TextBoxes
        {
            get => textBoxes;
            set => this.RaiseAndSetIfChanged(ref textBoxes, value);
        }

        //Collection of Form Data
        private ObservableCollection<string> formData = new(new string[6]);
        public ObservableCollection<string> FormData
        {
            get => formData;
            set => this.RaiseAndSetIfChanged(ref formData, value);
        }

        //Collection of Compliance Data
        private ObservableCollection<string> compliance = new(new string[6]);
        public ObservableCollection<string> Compliance
        {
            get => compliance;
            set => this.RaiseAndSetIfChanged(ref compliance, value);
        }

        //Form Data //TODO: COULD BE SIMPLIFIED
        public List<string> controlNames = new(new string[6]);

        private string? warning;
        public string WARNING { get => warning; set => this.RaiseAndSetIfChanged(ref warning, value); }

        //Submit button command
        public ICommand Submit { get; private set; }
        public ICommand Clear { get; private set; }
        public FormView()
        {
            bool submitted = false;
            Submit = ReactiveCommand.Create(() =>
            {
                if (!submitted)
                {
                    //Assign the textboxes' text to the Form Data
                    userData.RetrieveData(this);
                    depData.Data(this);
                    submitted = true;
                }
                if (submitted)
                {
                    //Clear the form after everything has been submitted
                    ClearForm();
                    submitted = false;
                }
            });

            Clear = ReactiveCommand.Create(() =>
            {
                ClearContent();
            });
        }

        void ClearForm()
        {
            for (int i = 0; i < TextBoxes.Count; i++)
            {
                TextBoxes[i] = "";
            }
        }

        void ClearContent()
        {
            for (int i = 0; i < FormData.Count; i++)
            {
                FormData[i] = "";
                WARNING = "";
                Compliance[0] = "";
                Compliance[1] = "";
            }
        }
        //Find Controls and store them
        public void RetrieveControls(RenderWindow renderWindow)
        {
            controlNames[0] = renderWindow.FindControl<TextBox>("NAME").Text;
            controlNames[1] = renderWindow.FindControl<TextBox>("ID").Text;
            controlNames[2] = renderWindow.FindControl<TextBox>("DEP").Text;
            controlNames[3] = renderWindow.FindControl<TextBox>("TOTAL").Text;
            controlNames[4] = renderWindow.FindControl<TextBox>("SENSORS").Text;
            controlNames[5] = renderWindow.FindControl<TextBox>("TICKETS").Text;

            textBoxes.Add(controlNames[0]);
            textBoxes.Add(controlNames[1]);
            textBoxes.Add(controlNames[2]);
            textBoxes.Add(controlNames[3]);
            textBoxes.Add(controlNames[4]);
            textBoxes.Add(controlNames[5]);
        }
    }
}

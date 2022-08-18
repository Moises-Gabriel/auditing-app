using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using audit.Views;

namespace audit.ViewModels
{
    public class FormView : ViewModelBase
    {
        //Collection of Form Data
        private ObservableCollection<string> formData = new ObservableCollection<string>(new string[6]);
        public ObservableCollection<string> FormData
        {
            get => formData;
            set => this.RaiseAndSetIfChanged(ref formData, value);
        }

        //Collection of Text Boxes
        private ObservableCollection<string> textBoxes = new ObservableCollection<string>(new string[6]);
        public ObservableCollection<string> TextBoxes
        {
            get => textBoxes;
            set => this.RaiseAndSetIfChanged(ref textBoxes, value);
        }

        //Form Data
        string? name;
        string? id;
        string? dep;
        string? total;
        string? sensors;
        string? tickets;

        //Submit button command
        public ICommand Submit { get; private set; }
        public FormView()
        {
            Submit = ReactiveCommand.Create(() =>
            {
                //Assign the textboxes' text to the Form Data
                for (int i = 0; i < FormData.Count; i++)
                {
                    FormData[i] = TextBoxes[i];
                }
            });
        }

        //Find Controls and store them
        public void RetrieveControls(RenderWindow renderWindow)
        {
            name = renderWindow.FindControl<TextBox>("NAME").Text;
            id = renderWindow.FindControl<TextBox>("ID").Text;
            dep = renderWindow.FindControl<TextBox>("DEP").Text;
            total = renderWindow.FindControl<TextBox>("TOTAL").Text;
            sensors = renderWindow.FindControl<TextBox>("SENSORS").Text;
            tickets = renderWindow.FindControl<TextBox>("TICKETS").Text;

            textBoxes.Add(name);
            textBoxes.Add(id);
            textBoxes.Add(dep);
            textBoxes.Add(total);
            textBoxes.Add(sensors);
            textBoxes.Add(tickets);
        }
    }
}

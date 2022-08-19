using audit.ViewModels;

namespace audit.Data
{
    internal class DepartmentData
    {
        public void Data(FormView formView)
        {
            UserData userData = new();

            List<string> data = new();

            List<int> depData = new();
            List<int> totalData = new();

            string dep = formView.TextBoxes[2];
            string total = formView.TextBoxes[3];
            string sens = formView.TextBoxes[4];
            string ticket = formView.TextBoxes[5];

            if (string.IsNullOrEmpty(dep) || string.IsNullOrEmpty(total) || string.IsNullOrEmpty(sens) || string.IsNullOrEmpty(ticket))
            {
                userData.warning = true;
                formView.WARNING = "FIELDS EMPTY! PLEASE INPUT DATA!";
            }
            else
            {
                formView.WARNING = "";
                userData.warning = false;
                //department
                string depTextBox = formView.TextBoxes[2];
                formView.FormData[2] = "Department: " + depTextBox;
                if (depTextBox != null)
                {
                    int depNum = int.Parse(depTextBox);
                    depData.Add(depNum); //depData[0]
                    data.Add(depTextBox);
                }

                //total merch counted
                string totalTextBox = formView.TextBoxes[3];
                formView.FormData[3] = "Total Counted: " + totalTextBox;
                if (totalTextBox != null)
                {
                    int totalNum = int.Parse(totalTextBox);
                    totalData.Add(totalNum); //totalData[0]
                    data.Add(totalTextBox);
                }

                //total missing sensors
                string sensTextBox = formView.TextBoxes[4];
                formView.FormData[4] = "Missing Sensors: " + sensTextBox;
                if (sensTextBox != null)
                {
                    int sensorNum = int.Parse(sensTextBox);
                    depData.Add(sensorNum); //depData[1]
                    data.Add(sensTextBox);
                }

                //total missing tickets
                string ticketTextBox = formView.TextBoxes[5];
                formView.FormData[5] = "Missing Tickets: " + ticketTextBox;
                if (ticketTextBox != null)
                {
                    int ticketNum = int.Parse(ticketTextBox);
                    depData.Add(ticketNum); //depData[2]
                    data.Add(ticketTextBox);
                }

                if (depData != null)
                {
                    //Calculate compliance
                    float senAns = depData[1] / (float)totalData[0] * 100;
                    float senCompliance = 100 - senAns;
                    formView.Compliance[0] = senCompliance.ToString() + "%";
                    data.Add(senCompliance.ToString() + "%");

                    float tickAns = depData[2] / (float)totalData[0] * 100;
                    float tickCompliance = 100 - tickAns;
                    formView.Compliance[1] = tickCompliance.ToString() + "%";
                    data.Add(tickCompliance.ToString() + "%");

                    SaveToFile(data, userData);
                }
            }
        }

        void SaveToFile(List<string> data, UserData userData)
        {
            List<string> prefixes = new()
                        { "Department: ", "Merchandise Total: ", "Missing Sensors: ",
                        "Missing Tickets: ", "Sensor Compliance: ", "Ticket Compliance: "
                        };

            for (int j = 0; j < data.Count; j++)
            {
                File.AppendAllText(userData.DataPath(), Environment.NewLine + prefixes[j] + data[j] + Environment.NewLine);
            }
        }
    }
}

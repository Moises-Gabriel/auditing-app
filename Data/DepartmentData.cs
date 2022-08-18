using audit.ViewModels;

namespace audit.Data
{
    internal class DepartmentData
    {
        public FormView? formView;
        public void Data()
        {
            UserData userData = new UserData();

            List<string> data = new List<string>();

            List<int> depData = new List<int>();
            List<int> totalData = new List<int>();

            //department
            string department = formView.dep;
            int depNum = int.Parse(department);
            depData.Add(depNum); //depData[0]
            data.Add(department);

            //total merch counted
            string total = formView.total;
            int totalNum = int.Parse(total);
            totalData.Add(totalNum); //totalData[0]
            data.Add(total);

            //total missing sensors
            string sensors = formView.sensors;
            int sensorNum = int.Parse(sensors);
            depData.Add(sensorNum); //depData[1]
            data.Add(sensors);

            //total missing tickets
            string tickets = formView.tickets;
            int ticketNum = int.Parse(tickets);
            depData.Add(ticketNum); //depData[2]
            data.Add(tickets);

            //Calculate compliance
            float senAns = depData[1] / (float)totalData[0] * 100;
            float senCompliance = 100 - senAns;
            Console.WriteLine($"Sensor Compliance: {senCompliance}%");
            data.Add(senCompliance.ToString() + "%");

            float tickAns = depData[2] / (float)totalData[0] * 100;
            float tickCompliance = 100 - tickAns;
            Console.WriteLine($"Ticket Compliance: {tickCompliance}%");
            data.Add(tickCompliance.ToString() + "%");

            List<string> prefixes = new List<string>()
                { "Department: ", "Merchandise Total: ", "Missing Sensors: ",
                "Missing Tickets: ", "Sensor Compliance: ", "Ticket Compliance: "
                };

            for (int j = 0; j < data.Count; j++)
            {
                File.AppendAllText(userData.path(), Environment.NewLine + prefixes[j] + data[j] + Environment.NewLine);
            }
        }
    }
}

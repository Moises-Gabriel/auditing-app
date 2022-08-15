using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audit.Data
{
    internal class DepartmentData
    {
        public void Data()
        {
            UserData userData = new UserData();
            var newLine = Environment.NewLine;

            Console.WriteLine("How many departments were audited?");
            string totalDep = Console.ReadLine();
            int totalDepartments = int.Parse(totalDep);

            for (int i = 0; i < totalDepartments; i++)
            {
                List<string> data = new List<string>();

                List<int> depData = new List<int>();
                List<int> totalData = new List<int>();

                Console.WriteLine(newLine);

                Console.WriteLine("Enter Department: ");
                string department = Console.ReadLine();
                int depNum = int.Parse(department);
                depData.Add(depNum); //depData[0]
                data.Add(department);

                Console.WriteLine("Enter Total Counted: ");
                string total = Console.ReadLine();
                int totalNum = int.Parse(total);
                totalData.Add(totalNum); //totalData[0]
                data.Add(total);

                Console.WriteLine("Enter Missing Sensors: ");
                string sensors = Console.ReadLine();
                int sensorNum = int.Parse(sensors);
                depData.Add(sensorNum); //depData[1]
                data.Add(sensors);

                Console.WriteLine("Enter Missing Tickets: ");
                string tickets = Console.ReadLine();
                int ticketNum = int.Parse(tickets);
                depData.Add(ticketNum); //depData[2]
                data.Add(tickets);

                Console.WriteLine(newLine);

                //Print completed audit form
                Console.WriteLine($"Audited Department: {depData[0]}");
                Console.WriteLine($"Total Counted Merchandise: {totalData[0]}");
                Console.WriteLine($"Missing Sensors: {depData[1]}");
                Console.WriteLine($"Missing Tickets: {depData[2]}");

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
}

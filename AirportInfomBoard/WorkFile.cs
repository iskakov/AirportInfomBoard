using AirportInfomBoard.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard
{
    public static class WorkFile
    {
        private static List<string> cityNames = new List<string>()
        {
            "Пермь","Нью-Йорк","Москва","Токио",
            "Сингапур","Дубай","Барселона","Сан-Франциско",
            "Чикаго","Берлин","Варшава","Вашингтон",
            "Вена","Венеция","Венеция","Геленджик",
            "Дубай","Дубровник","Евпатория","Екатеринбург",
            "Женева","Ижевск","Иркутск","Йошкар-Ола",
            "Казань","Кёльн","Киев","Лондон",
        };

        public static void ReadFile(List<Flight> flights) 
        {
            using (var streamReader = new StreamReader("Flights.txt"))
            {
                var fligthSt = "";
                while ((fligthSt = streamReader.ReadLine()) != null)
                {
                    try
                    {
                        if (fligthSt.Split(';').Length == 4)
                        {
                            flights.Add(new Flight(fligthSt));
                        }
                    }
                    catch { }
                }
            }
        }

        public static void GenerateFile()
        {
            var Flights = new List<Flight>();
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int countPass = random.Next(1, 10);
                bool isFli = (random.Next(0, 2)) == 1 ? true : false;
                var date = new DateTime(random.Next(2001, 2001), random.Next(1, 2), random.Next(1, 15), random.Next(0, 23), random.Next(0, 60), random.Next(0, 60));
                var city = cityNames[random.Next(0, cityNames.Count)];
                Flights.Add(new Flight(countPass, isFli, date, city));
            }
            Flights.Sort((flight1, flight2) => flight1.DateFlight.CompareTo(flight2.DateFlight));
            try
            {
                using (var streamWriter = new StreamWriter("Flights.txt"))
                {
                    for (int i = 0; i < Flights.Count; i++)
                    {
                        streamWriter.WriteLine(Flights[i].ToString());
                    }
                }
            }
            catch {}
        }
    }
}

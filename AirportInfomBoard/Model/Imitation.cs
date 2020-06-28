using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace AirportInfomBoard.Model
{
    public class Imitation : VM
    {
        public Imitation()
        {
            CurrFlight = new Flight();
            Flights = new List<Flight>();
            InformForGrapfics = new ObservableCollection<InformForGrapfic>();
            InformForGrapfics.Add(new InformForGrapfic() { Time = TimeSpan.FromHours(0) });
            InformDeparture = new InformationFlights();
            InformArrive = new InformationFlights();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Move;
            //timer.Elapsed += Move;
            //timer.AutoReset = true;
            CustomTimer = new CustomTimer(timer);

            currentDate = new DateTime(2001, 1, 1, 0, 0, 0);
            CurrFlight.DateFlight = new DateTime(2001, 1, 1, 0, 0, 0);
            CustomTimer.Date = currentDate.ToShortDateString();
            CustomTimer.Time = currentDate.ToShortTimeString();
            CustomTimer.CurrentSpeed = 1000;
        }

        public Flight CurrFlight { get; set; }
        public List<Flight> Flights { get; set; }
        public InformationFlights InformDeparture { get; set; }
        public InformationFlights InformArrive { get; set; }
        public ObservableCollection<InformForGrapfic> InformForGrapfics { get; set; }
        public CustomTimer CustomTimer { get; set; }
        private DispatcherTimer timer;
        private DateTime currentDate; 
        public void Start()
        {
            Random random = new Random();
            // заполнение из файла
            for(int i = 0; i < 10000; i++)
            {
                int countPass = random.Next(1, 10);
                bool isFli = (random.Next(0, 2)) == 1 ? true : false;
                var date = new DateTime(random.Next(2001,2001), random.Next(1, 2), random.Next(1, 15), random.Next(0, 23), random.Next(0, 60), random.Next(0, 60));
                Flights.Add(new Flight(countPass, isFli, date, "Пермь"));
            }
            

            Flights.Sort((flight1, flight2) => flight1.DateFlight.CompareTo(flight2.DateFlight));
            // запуск таймера
            
            timer.Start();

        }

        private void Move(object sender, EventArgs e)
        {
            int day = currentDate.Day;
            int hour = currentDate.Hour;

            currentDate = currentDate.AddSeconds(CustomTimer.AddSecond);
            CustomTimer.Date = currentDate.ToShortDateString();
            CustomTimer.Time = currentDate.ToLongTimeString();
            if (day < currentDate.Day)
            {
                InformDeparture.CountPassengerLastDay = 0;
                InformArrive.CountPassengerLastDay = 0;
                InformForGrapfics.Clear();
                InformForGrapfics.Add(new InformForGrapfic() { Time = TimeSpan.FromHours(0) });
            }
            if (hour < currentDate.Hour)
            {
                InformForGrapfics.Add(new InformForGrapfic() { Time = TimeSpan.FromHours(currentDate.Hour) });
            }
            var loopResult = Parallel.ForEach<Flight>(Flights, CheckFlight);

           
            
            DeleteFlights();
            if(Flights.Count == 0)
            {
                timer.Stop();
            }
        }


        private void CheckFlight(Flight flight, ParallelLoopState pls)
        {

            if(flight.DateFlight <= currentDate && flight.isActual)
            {
                CurrFlight.DateFlight = flight.DateFlight;
                CurrFlight.CountPassenger = flight.CountPassenger;
                CurrFlight.City = flight.City;
                CurrFlight.IsFlight = flight.IsFlight;
                flight.isActual = false;
                CheckInformationFlight(flight);
            }
            else
            {
                pls.Break();
            }
        }

        private void DeleteFlights()
        {
            int i = 0;
            while (i < Flights.Count)
            {
                if (!Flights[i].isActual) 
                    Flights.RemoveAt(i);
                else
                    break;
            }
        }
        
        private void CheckInformationFlight(Flight flight)
        {
            if (flight.IsFlight)
            {
                InformDeparture.CountPassengerAllTime += flight.CountPassenger;
                InformDeparture.CountPassengerLastDay += flight.CountPassenger;
                InformDeparture.CountPassengerLastFlight = flight.CountPassenger;
                InformForGrapfics[InformForGrapfics.Count - 1].CountPassengerDeparture += flight.CountPassenger;
            }
            else
            {
                InformArrive.CountPassengerAllTime += flight.CountPassenger;
                InformArrive.CountPassengerLastDay += flight.CountPassenger;
                InformArrive.CountPassengerLastFlight = flight.CountPassenger;
                InformForGrapfics[InformForGrapfics.Count - 1].CountPassengerArrive += flight.CountPassenger;

            }
        }

    }
}

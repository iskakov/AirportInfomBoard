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
            // заполнение из файла
            Flights.Add(new Flight(20,true,new DateTime(2001, 1, 1, 0,0,00), "Пермь"));
            Flights.Add(new Flight(1,false,new DateTime(2001, 1, 1, 0,30,00), "Пермь"));
            Flights.Add(new Flight(2,false,new DateTime(2001, 1, 1, 5,30,00), "Пермь"));
            Flights.Add(new Flight(3, true, new DateTime(2001, 1, 1, 6,30,00), "Пермь"));
            Flights.Add(new Flight(4,false,new DateTime(2001, 1, 1, 12,30,00), "Пермь"));
            Flights.Add(new Flight(5,false,new DateTime(2001, 1, 1, 1,22,00), "Пермь"));
            Flights.Add(new Flight(6, true, new DateTime(2001, 1, 1, 1,54,00), "Пермь"));
            Flights.Add(new Flight(7, true, new DateTime(2001, 1, 1, 2,50,00), "Пермь"));
            Flights.Add(new Flight(8,false,new DateTime(2001, 1, 1, 3,30,00), "Пермь"));
            Flights.Add(new Flight(9, true, new DateTime(2001, 1, 1, 6,30,00), "Пермь"));
            Flights.Add(new Flight(0, true, new DateTime(2001, 1, 1, 23,30,00), "Пермь"));
            Flights.Add(new Flight(22,false,new DateTime(2001, 1, 1, 7,30,00), "Пермь"));
            Flights.Add(new Flight(23, true, new DateTime(2001, 1, 1, 9,30,00), "Пермь"));
            Flights.Add(new Flight(21, true, new DateTime(2001, 1, 1, 4,30,00), "Пермь"));
            Flights.Add(new Flight(42,false,new DateTime(2001, 1, 1, 9,30,00), "Пермь"));
            Flights.Add(new Flight(42, true, new DateTime(2001, 1, 1, 8,30,00), "Пермь"));
            Flights.Add(new Flight(25,false,new DateTime(2001, 1, 1, 7,30,00), "Пермь"));
            Flights.Add(new Flight(42, false, new DateTime(2001, 1, 2, 9, 30, 00), "Пермь"));
            Flights.Add(new Flight(42, true, new DateTime(2001, 1, 2, 8, 30, 00), "Пермь"));
            Flights.Add(new Flight(22, false, new DateTime(2001, 1, 2, 8, 30, 00), "Пермь"));
            Flights.Add(new Flight(11, false, new DateTime(2001, 1, 2, 7, 30, 00), "Пермь"));

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

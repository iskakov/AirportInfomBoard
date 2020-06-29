using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            initializeInfromForGraphic();
            InformDeparture = new InformationFlights();
            InformArrive = new InformationFlights();
            
            currentDate = new DateTime(2001, 1, 1, 0, 0, 0);
            CustomTimer = new CustomTimer(currentDate);
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
            try
            {
                WorkFile.ReadFile(Flights);
            }
            catch
            {
                WorkFile.GenerateFile();
                WorkFile.ReadFile(Flights);
            }
            // запуск таймера
            CustomTimer.Timer.Tick += Move;
            CustomTimer.Start();
        }

        private void Move(object sender, EventArgs e)
        {
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;


            currentDate = currentDate.AddSeconds(CustomTimer.AddSecond);
            
            CustomTimer.Time = currentDate.ToLongTimeString();
            if (day < currentDate.Day || month < currentDate.Month || year < currentDate.Year)
            {
                InformDeparture.CountPassengerLastDay = 0;
                InformArrive.CountPassengerLastDay = 0;
                InformForGrapfics.Clear();
                CustomTimer.Date = currentDate.ToShortDateString();
                initializeInfromForGraphic();
            }
            var loopResult = Parallel.ForEach<Flight>(Flights, CheckFlight);
                      
            DeleteFlights();
            if(Flights.Count == 0)
            {
                CustomTimer.Stop();
                CustomTimer.Timer.Tick -= Move;
                CustomEvent.RaiseDelegate();
                // событие на остановку
            }
        }

        private void initializeInfromForGraphic()
        {
            for(int i = 0; i< 24; i++)
            {
                InformForGrapfics.Add(new InformForGrapfic() { Time = TimeSpan.FromHours(i) });
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
                CurrFlight.IsNew = flight.IsNew;
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
                InformForGrapfics[flight.DateFlight.Hour].CountPassengerDeparture += flight.CountPassenger;
            }
            else
            {
                InformArrive.CountPassengerAllTime += flight.CountPassenger;
                InformArrive.CountPassengerLastDay += flight.CountPassenger;
                InformArrive.CountPassengerLastFlight = flight.CountPassenger;
                InformForGrapfics[flight.DateFlight.Hour].CountPassengerArrive += flight.CountPassenger;

            }
        }

    }
}

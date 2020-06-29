using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AirportInfomBoard.Model
{
    public class Flight : VM
    {

        private bool isFlight;
        private DateTime dateFlight;

        public bool isActual;
        private string isFlightSt;
        private string city;
        private string dateFlightSt;
        private int countPassenger;
        private Visibility isNew;

        public bool IsFlight
        {
            get
            {
                return isFlight;
            }
            set
            {
                isFlight = value;
                if (value)
                    IsFlightSt = "Вылетел";
                else
                    IsFlightSt = "Прилетел";
            }
        }
        public int CountPassenger
        {
            get => countPassenger;
            set { countPassenger = value; OnPropertyChanged(); }
        }
        public DateTime DateFlight { get => dateFlight; set { dateFlight = value; DateFlightSt = dateFlight.ToShortDateString() + " " + dateFlight.ToShortTimeString(); } }
        public string DateFlightSt { get => dateFlightSt; set { dateFlightSt = value; OnPropertyChanged(); } }
        public string City { get => city; set { city = value; OnPropertyChanged(); } }
        public string IsFlightSt
        {
            get => isFlightSt;
            set { isFlightSt = value; OnPropertyChanged(); }
        }

        public Visibility IsNew { get => isNew; set { isNew = value; OnPropertyChanged(); } }

        public Flight()
        {
            DateFlight = new DateTime();
            IsNew = Visibility.Collapsed;
            City = "";
        }

        public Flight(int countPassenger, bool isFlight, DateTime dateFlight, string cityName)
        {
            CountPassenger = countPassenger;
            IsFlight = isFlight;
            DateFlight = dateFlight;
            City = cityName;
            isActual = true;
            IsNew = Visibility.Visible;
        }

        public Flight(string fligthSt)
        {
            var mass = fligthSt.Split(';');
            if (mass.Length == 4)
            {
                countPassenger = int.Parse(mass[0]);
                IsFlight = mass[1].Equals("Вылетел") ? true : false;
                DateFlight = DateTime.Parse(mass[2]);
                isActual = true;
                city = mass[3];
            }
        }

        public override string ToString()
        {
            return CountPassenger.ToString() + ";" + IsFlightSt + ";" + dateFlight.ToShortDateString() + " " + dateFlight.ToLongTimeString() + ";" + City;
        }
    }
}

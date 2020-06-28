using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CountPassenger { get => countPassenger; set { countPassenger = value; OnPropertyChanged(); } }
        public DateTime DateFlight { get => dateFlight; set { dateFlight = value; DateFlightSt = dateFlight.ToLongDateString(); } }
        public string DateFlightSt { get => dateFlightSt; set { dateFlightSt = value; OnPropertyChanged(); } }
        public string City { get => city; set { city = value; OnPropertyChanged(); } }
        public string IsFlightSt { get => isFlightSt; set { isFlightSt = value; OnPropertyChanged(); } }

        public Flight()
        {
            DateFlight = new DateTime();

            City = "";
        }

        public Flight(int countPassenger, bool isFlight, DateTime dateFlight, string cityName)
        {
            CountPassenger = countPassenger;
            IsFlight = isFlight;
            DateFlight = dateFlight;
            City = cityName;
            isActual = true;
        }


    }
}

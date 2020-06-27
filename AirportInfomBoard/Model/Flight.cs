using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard.Model
{
    public class Flight
    {
        public int CountPassenger { get; set; }
        private bool isFlight;
        public bool IsFlight { 
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
        public DateTime DateFlight { get; set; }
        public String CityName { get; set; }
        public String IsFlightSt { get; set; }

        public Flight()
        {
            DateFlight = new DateTime();
            CityName = "";
        }

        public Flight(int countPassenger, bool isFlight, DateTime dateFlight, string cityName)
        {
            CountPassenger = countPassenger;
            IsFlight = isFlight;
            DateFlight = dateFlight;
            CityName = cityName;
        }


    }
}

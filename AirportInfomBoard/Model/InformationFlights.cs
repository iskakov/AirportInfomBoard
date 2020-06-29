using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard.Model
{
    public class InformationFlights : VM
    {
        private int countPassengerLastFlight;
        private int countPassengerLastDay;
        private long countPassengerAllTime;

        public InformationFlights()
        {
        }

        public InformationFlights(int countPassengerLastFlight, int countPassengerLastDay, long countPassengerAllTime)
        {
            CountPassengerLastFlight = countPassengerLastFlight;
            CountPassengerLastDay = countPassengerLastDay;
            CountPassengerAllTime = countPassengerAllTime;
        }

        public int CountPassengerLastFlight { get => countPassengerLastFlight; set { countPassengerLastFlight = value; OnPropertyChanged(); } }
        public int CountPassengerLastDay { get => countPassengerLastDay; set { countPassengerLastDay = value; OnPropertyChanged(); } }
        public long CountPassengerAllTime { get => countPassengerAllTime; set { countPassengerAllTime = value; OnPropertyChanged(); } }

    }
}

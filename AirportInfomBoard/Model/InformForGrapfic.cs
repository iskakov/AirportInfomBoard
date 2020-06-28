using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard.Model
{
    public class InformForGrapfic : VM
    {
        private int countPassengerDeparture;
        private int countPassengerArrive;

        public int CountPassengerArrive { get => countPassengerArrive; set { countPassengerArrive = value; OnPropertyChanged(); } }
        public int CountPassengerDeparture { get => countPassengerDeparture; set { countPassengerDeparture = value; OnPropertyChanged(); } }
        public TimeSpan Time { get; set; }
    }
}

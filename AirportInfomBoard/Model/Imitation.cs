using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard.Model
{
    public class Imitation : VM
    {
        public Imitation()
        {
            CurrFlight = null;
            Flights = new List<Flight>();
            InformForGrapfics = new ObservableCollection<InformForGrapfic>();
            InformDeparture = new InformationFlights();
            InformArrive = new InformationFlights();
        }

        public Flight CurrFlight { get; set; }
        public List<Flight> Flights { get; set; }
        public InformationFlights InformDeparture { get; set; }
        public InformationFlights InformArrive { get; set; }
        public ObservableCollection<InformForGrapfic> InformForGrapfics { get; set; }

        public void Start()
        {
            // заполнение из файла
            // запуск таймера

        }

    }
}

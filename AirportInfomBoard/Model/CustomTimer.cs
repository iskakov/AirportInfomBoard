using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace AirportInfomBoard.Model
{
    public class CustomTimer : VM
    {
        private DispatcherTimer timer;
        private string date;
        private string time;
        private int currentSpeed;
        private TimeSpan timeSpan;

        public CustomTimer(DispatcherTimer timer)
        {
            this.timer = timer;
        }

        public TimeSpan TimeSpan { get => timeSpan; set { timeSpan = value; OnPropertyChanged(); } }
        public string Date { get => date; set { date = value; OnPropertyChanged("Date"); } }
        public string Time { get => time; set { time = value; OnPropertyChanged("Time"); } }
        public int CurrentSpeed
        {
            get => currentSpeed;
            set
            {
                currentSpeed = value;
                AddSecond = value > 1000 ? (value > 5000 ? (value > 7500 ? 7 : 5) : 2) : 1;
                timer.Stop(); timer.Interval = value > 1 ? TimeSpan.FromMilliseconds(1000.0 / value) : TimeSpan.FromMilliseconds(1000); timer.Start();
                OnPropertyChanged();
            }
        }

        public int AddSecond { get; set; }
    }
}

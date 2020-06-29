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
        public DispatcherTimer Timer { get; }
        private string date;
        private string time;
        private int currentSpeed;
        private TimeSpan timeSpan;

        public CustomTimer(DateTime currentDate)
        {
            Timer = new DispatcherTimer(); // переместить в CustomTimer
            Timer.Interval = TimeSpan.FromMilliseconds(1000);
            Date = currentDate.ToShortDateString();
            Time = currentDate.ToShortTimeString();
            CurrentSpeed = 1;
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
            Timer.Tag = true;
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
                AddSecond = value > 100 ? ((double)value)/100.0 + 1.0 : 1.0;
                if(Timer.Tag != null && !(bool)Timer.Tag)
                    Timer.Stop(); Timer.Interval = value < 100 ? TimeSpan.FromMilliseconds(1000.0 / value) : TimeSpan.FromMilliseconds(10); Timer.Start();
                OnPropertyChanged();
            }
        }

        public double AddSecond { get; set; }
    }
}

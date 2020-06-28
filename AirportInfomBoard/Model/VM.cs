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
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(
                              DispatcherPriority.Background,
                              new Action(() => {
                                  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
                              }));
            }
        }

    }
}

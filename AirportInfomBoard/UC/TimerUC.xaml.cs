using AirportInfomBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportInfomBoard.UC
{
    /// <summary>
    /// Логика взаимодействия для TimerUC.xaml
    /// </summary>
    public partial class TimerUC : UserControl
    {
        private CustomTimer customTimer;
        public TimerUC(CustomTimer customTimer)
        {
            InitializeComponent();
            this.customTimer = customTimer;
            grid.DataContext = this.customTimer;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}

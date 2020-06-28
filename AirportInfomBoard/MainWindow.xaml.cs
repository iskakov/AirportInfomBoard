using AirportInfomBoard.Model;
using AirportInfomBoard.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AirportInfomBoard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Imitation imitation;
        
        public MainWindow()
        {
            InitializeComponent();
            imitation = new Imitation();
            timerUC.Content = new TimerUC(imitation.CustomTimer);
            lastFlight.Content = new LastFlightUC(imitation.CurrFlight);
            infromFlights.Content = new MainWorkPlaceUC(imitation.InformArrive, imitation.InformDeparture);
            graphic.Content = new BarChatUC(imitation.InformForGrapfics);
            imitation.Start();
        }
    }
}

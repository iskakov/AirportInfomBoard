using AirportInfomBoard.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для BarChatUC.xaml
    /// </summary>
    public partial class BarChatUC : UserControl
    {
        private ObservableCollection<InformForGrapfic> informForGrapfic;
        public BarChatUC(ObservableCollection<InformForGrapfic> informForGrapfic)
        {
            InitializeComponent();
            this.informForGrapfic = informForGrapfic;
            Vs vs = new Vs() { List = informForGrapfic};
            chart.DataContext = vs;
        }
        public class Vs
        {
            public ObservableCollection<InformForGrapfic> List { get; set; }
        }
    }
}

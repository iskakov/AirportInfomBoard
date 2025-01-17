﻿using AirportInfomBoard.Model;
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
    /// Логика взаимодействия для MainWorkPlaceUC.xaml
    /// </summary>
    public partial class MainWorkPlaceUC : UserControl
    {

        public MainWorkPlaceUC(InformationFlights informArrive, InformationFlights informDeparture)
        {
            InitializeComponent();
            leftPanel.Content = new InformationForFlights(informArrive, true);
            rightPanel.Content = new InformationForFlights(informDeparture, false);
            CustomEvent.SignOrCloseDelegate(EndImitation, true);
        }

        private void EndImitation()
        {
            MessageBox.Show("Имитация закончилась.");
        }
    }
}

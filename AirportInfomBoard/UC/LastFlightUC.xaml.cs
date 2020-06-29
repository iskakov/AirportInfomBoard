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
    /// Логика взаимодействия для LastFlightUC.xaml
    /// </summary>
    public partial class LastFlightUC : UserControl
    {
        private Flight flight;
        public LastFlightUC(Flight flight)
        {
            InitializeComponent();
            this.flight = flight;
            stackPanel.DataContext = flight;
            
        }
    }
}

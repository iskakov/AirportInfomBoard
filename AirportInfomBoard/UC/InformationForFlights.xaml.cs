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
    /// Логика взаимодействия для InformationForFlights.xaml
    /// </summary>
    public partial class InformationForFlights : UserControl
    {
        private InformationFlights informationForFlights;
        public InformationForFlights(InformationFlights informationForFlights, bool isArrive)
        {
            InitializeComponent();
            this.informationForFlights = informationForFlights;
            grid.DataContext = informationForFlights;
            if (isArrive)
                titleTB.Text = "Информация по прилету:";
            else
                titleTB.Text = "Информация по вылету:";
        }
    }
}

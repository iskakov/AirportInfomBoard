using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace AirportInfomBoard
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool isWiden;
        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Windows[0].DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[0].Close();
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void main_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double X = e.GetPosition(App.Current.Windows[0]).X;
                double Y = e.GetPosition(App.Current.Windows[0]).Y;

                if (rect.Name == "RectRight" || rect.Name == "RectRight1")
                {
                    double newWidth = X + 1;
                    App.Current.Windows[0].Width = newWidth;
                }

                if (rect.Name == "RectBot")
                {
                    double newWidth = Y + 1;
                    App.Current.Windows[0].Height = newWidth;
                }
                if (rect.Name == "RectLeft" || rect.Name == "RectLeft1")
                {

                    X -= 1;
                    if (Current.Windows[0].Width - X > Current.Windows[0].MinWidth)
                        Current.Windows[0].Left += X;
                    X = Current.Windows[0].Width - X;
                    if (X > 0)
                    {
                        Current.Windows[0].Width = X;
                    }
                }

                if (rect.Name == "RectTop")
                {

                    Y -= 1;
                    if (Current.Windows[0].Height - Y > Current.Windows[0].MinHeight)
                        Current.Windows[0].Top += Y;
                    Y = Current.Windows[0].Height - Y;
                    if (Y > 0)
                    {
                        Current.Windows[0].Height = Y;
                    }
                }
            }
        }
        

        private void main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWiden = false;
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void main_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWiden = true;
        }

        private void MaximazeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Current.Windows[0].WindowState.Equals(WindowState.Normal))
            {
                Current.Windows[0].WindowState = WindowState.Maximized;
            }
            else
            {

                Current.Windows[0].WindowState = WindowState.Normal;
            }
        }
    }
}

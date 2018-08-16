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
using System.Windows.Threading;

namespace Wpf_DrawTimer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int interval_timer = 10;

        public MainWindow()
        {
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, interval_timer)
            };
            timer.Tick += pb_Tick;
            InitializeComponent();
        }

        //обработка интервала
        private void pb_Tick(object sender, object e)
        {
            pb_Time.Value++;
            if (pb_Time.Value == pb_Time.Maximum + interval_timer)
            { 
                timer.Stop();
                b5.IsEnabled = true;
                b15.IsEnabled = true;
                b25.IsEnabled = true;
                this.Focus();
            }
        }

        //кнопки
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            b15.IsEnabled = false;
            b25.IsEnabled = false;
            pb_Time.Value = 0;
            pb_Time.Maximum = 30;
            timer.Start();
        }

        private void b15_Click(object sender, RoutedEventArgs e)
        {
            b5.IsEnabled = false;
            b25.IsEnabled = false;
            pb_Time.Value = 0;
            pb_Time.Maximum = 90;
            timer.Start();
        }

        private void b25_Click(object sender, RoutedEventArgs e)
        {
            b5.IsEnabled = false;
            b15.IsEnabled = false;
            pb_Time.Value = 0;
            pb_Time.Maximum = 150;
            timer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            pb_Time.Value = 0;
            timer.Stop();
            b5.IsEnabled = true;
            b15.IsEnabled = true;
            b25.IsEnabled = true;
        }
    }
}

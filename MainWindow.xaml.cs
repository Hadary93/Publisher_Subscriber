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

namespace Publisher_Subscriber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// an event that has an ellipse as message.
        /// </summary>
        private event EventHandler<Ellipse>? customEvent;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            this.ellipse.Fill = Brushes.Red;

            //if event is subscribed => raise the event.
            if (customEvent != null)
            {
                customEvent(this, ellipse);
            }
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            this.ellipse.Fill = Brushes.Green;

            //if event is subscribed => raise the event.
            if (customEvent != null)
            {
                customEvent(this, ellipse);
            }
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
            //subscribe to the event.
            customEvent += HandleRaisedEvent;

            subscribe.Background = Brushes.Blue;
            unsubscribe.Background = Brushes.LightGray;
        }

        private void Unsubscribe_Click(object sender, RoutedEventArgs e)
        {
            //unsubscibe to the event.
            customEvent -= HandleRaisedEvent;

            unsubscribe.Background = Brushes.Blue;
            subscribe.Background = Brushes.LightGray;
        }

        /// <summary>
        /// handles the event raise for subscribers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleRaisedEvent(object? sender, Ellipse e)
        {
            ellipse_2.Fill = e.Fill;
        }
    }
}

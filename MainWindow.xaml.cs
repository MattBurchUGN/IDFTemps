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
using System.Net.Http;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security;
using Microsoft.SharePoint.Client;


namespace IDFTemps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        // multiple JsonDocument variables so that I can do async calls
        JsonDocument response1;
        JsonDocument response2;
        JsonDocument response3;
        JsonDocument response4;
        JsonDocument response5;
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Loaded(object sender, EventArgs e)
        {
            dispatcherTimer_Tick1(null,null);
            dispatcherTimer_Tick2(null, null);
            dispatcherTimer_Tick3(null, null);
            dispatcherTimer_Tick4(null, null);
            dispatcherTimer_Tick5(null, null);
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick1);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick2);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick3);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick4);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick5);
            dispatcherTimer.Interval = new TimeSpan(0, 30, 0);
            dispatcherTimer.Start();
        }
        private async void dispatcherTimer_Tick(string location, string ip)
        {
            var client = new HttpClient();
            try
            {
                response1 = await JsonDocument.ParseAsync(await client.GetStreamAsync(ip));
                if (response1.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    ShippingButton.Background = Brushes.Yellow;
                    ShippingButton.Foreground = Brushes.Black;
                    ShippingButton.Content = location + " " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    ShippingButton.Background = Brushes.LimeGreen;
                    ShippingButton.Foreground = Brushes.Black;
                    ShippingButton.Content = location + " " + response1.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();
                }
            }
            catch (HttpRequestException ex)
            {
                ShippingButton.Background = Brushes.Red;
                ShippingButton.Foreground = Brushes.Black;
                ShippingButton.Content = location + " " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
        private async void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                response1 = await JsonDocument.ParseAsync(await client.GetStreamAsync("http://10.109.255.241"));
                if (response1.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    ShippingButton.Background = Brushes.Yellow;
                    ShippingButton.Foreground = Brushes.Black;
                    ShippingButton.Content = "Shipping " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    ShippingButton.Background = Brushes.LimeGreen;
                    ShippingButton.Foreground = Brushes.Black;
                    ShippingButton.Content = "Shipping " + response1.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();
                }
            }
            catch (HttpRequestException ex)
            {
                ShippingButton.Background = Brushes.Red;
                ShippingButton.Foreground = Brushes.Black;
                ShippingButton.Content = "Shipping " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
        private async void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                response2 = await JsonDocument.ParseAsync(await client.GetStreamAsync("http://10.109.255.243"));
                if (response2.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    RulButton.Background = Brushes.Yellow;
                    RulButton.Foreground = Brushes.Black;
                    RulButton.Content = "Rul " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    RulButton.Background = Brushes.LimeGreen;
                    RulButton.Foreground = Brushes.Black;
                    RulButton.Content = "Rul " + response2.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();

                }
            }
            catch (HttpRequestException ex)
            {
                RulButton.Background = Brushes.Red;
                RulButton.Foreground = Brushes.Black;
                RulButton.Content = "Rul " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
        private async void dispatcherTimer_Tick3(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                response3 = await JsonDocument.ParseAsync(await client.GetStreamAsync("http://10.109.255.245"));
                if (response3.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    FleeceButton.Background = Brushes.Yellow;
                    FleeceButton.Foreground = Brushes.Black;
                    FleeceButton.Content = "Fleece " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    FleeceButton.Background = Brushes.LimeGreen;
                    FleeceButton.Foreground = Brushes.Black;
                    FleeceButton.Content = "Fleece " + response3.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();

                }
            }
            catch (HttpRequestException ex)
            {
                FleeceButton.Background = Brushes.Red;
                FleeceButton.Foreground = Brushes.Black;
                FleeceButton.Content = "Fleece " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
        private async void dispatcherTimer_Tick4(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                response4 = await JsonDocument.ParseAsync(await client.GetStreamAsync("http://10.109.255.247"));
                if (response4.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    HeadlinerButton.Background = Brushes.Yellow;
                    HeadlinerButton.Foreground = Brushes.Black;
                    HeadlinerButton.Content = "Headliner " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    HeadlinerButton.Background = Brushes.LimeGreen;
                    HeadlinerButton.Foreground = Brushes.Black;
                    HeadlinerButton.Content = "Headliner " + response4.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();

                }
            }
            catch (HttpRequestException ex)
            {
                HeadlinerButton.Background = Brushes.Red;
                HeadlinerButton.Foreground = Brushes.Black;
                HeadlinerButton.Content = "Headliner " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
        private async void dispatcherTimer_Tick5(object sender, EventArgs e)
        {
            var client = new HttpClient();
            //response5 = await CheckMezzanine(client);
            try
            {
                response5 = await JsonDocument.ParseAsync(await client.GetStreamAsync("http://10.109.255.249"));
                if (response5.RootElement.GetProperty("TempF").ToString() == "32.00")
                {
                    MezzanineButton.Background = Brushes.Yellow;
                    MezzanineButton.Foreground = Brushes.Black;
                    MezzanineButton.Content = "Mezzanine " + "No Reading" + Environment.NewLine + DateTime.Now.ToString();
                }
                else
                {
                    MezzanineButton.Background = Brushes.LimeGreen;
                    MezzanineButton.Foreground = Brushes.Black;
                    MezzanineButton.Content = "Mezzanine " + response5.RootElement.GetProperty("TempF").ToString() + Environment.NewLine + DateTime.Now.ToString();

                }
            }
            catch (HttpRequestException ex)
            {
                MezzanineButton.Background = Brushes.Red;
                MezzanineButton.Foreground = Brushes.Black;
                MezzanineButton.Content = "Mezzanine " + "Unreachable" + Environment.NewLine + DateTime.Now.ToString();
            }
        }
    }
}

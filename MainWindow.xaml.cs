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

namespace Grupparbete1november
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DailyWeatherDate> WeatherCollection = new List<DailyWeatherDate>();
        List<Clouds> FormationOfClouds = new List<Clouds>() { Clouds.Makrillmoln, Clouds.Klart, Clouds.Valkmoln, Clouds.Dimmoln};
        List<string> PresentWeatherCollection = new List<string>();
        FileHandling fileHandling = new FileHandling();

        public MainWindow()
        {

            InitializeComponent();
            FillBoxes();
            UpdateWeatherCollection();


        }
        private void FillBoxes()
        {

            for (int i = 1; i <= 12; i++)
            {
                WindSpeed.Items.Add(10 * i);
            }
            for (int x = -30; x <=30; x++)
            {
                Degrees.Items.Add(x);
            }
            CloudFormation.ItemsSource = FormationOfClouds;

        }
        private void UpdateWeatherCollection()
        {
            WeatherDetail.ItemsSource = null;
            var temp = WeatherCollection.Select(day => $"This day it is: {day.Grader}, with {day.WindPower} km/h windpower. It is sunny: {day.Sunny}. The Clouds is {day.ShapeOfClouds}").ToList();
            WeatherDetail.ItemsSource = temp;
        }

        private void Skapa_Click(object sender, RoutedEventArgs e)
        {
            bool sunnornot = false;
            if (Sunny.IsChecked == true) sunnornot = true;
            else sunnornot = false;
            int kmPerTimme = (int)WindSpeed.SelectedValue; //Felhantera nullvalue.
            Clouds ChosenCloud = (Clouds)CloudFormation.SelectedItem;
            int ChosenDegrees = (int)Degrees.SelectedItem;

            WeatherCollection.Add(new DailyWeatherDate(ChosenDegrees, sunnornot, kmPerTimme, ChosenCloud)); //(int grader, bool sunny, int windPower, Clouds shapeOfClouds)
            fileHandling.WriteToFile(WeatherCollection);
            UpdateWeatherCollection();

        }
    }
}

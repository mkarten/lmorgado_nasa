using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace lmorgado_nasa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Initialized = false;
        private NasaApi nasaApi = new NasaApi("D9sigYbhtYHhbln3WkSJ5IIdYDxuggmKG16WKiJG");
        private APOD apod = new APOD();
        private NEOFeed NeoFeed = new NEOFeed();
        private List<NeoDisplay> NeoDisplayList = new List<NeoDisplay>();
        private List<string> NEODateList = new List<string>();
        private string Unit = "kilometers";
        private double originalWidth = 0;
        private double originalHeight = 0;
        private DateTime date;

        public MainWindow()
        {
            InitializeComponent();
        }

        // after the grid loads start the app and get all the necesary data
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            InitApp();

            ImageSource POTDImage = this.apod.GetImage();
            POTDImg.Source = POTDImage;
            originalHeight = POTDImg.Source.Height;
            originalWidth = POTDImg.Source.Width;
            Width = originalWidth;
            Height = originalHeight;
            App.Icon = POTDImage;
            foreach (var str in this.NeoFeed.near_earth_objects)
            {
                NEODateList.Add(str.Key);
            }
            NEO tempNeo = new NEO();
            NeoDisplayList = tempNeo.TransformNeoList(this.Unit, NeoFeed.near_earth_objects[NEODateList[0]]);
            NeoData.ItemsSource = NeoDisplayList;
            NeoData.IsSynchronizedWithCurrentItem = true;
        }

        // displays more info about the APOD
        private void POTDGetMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            msg += "title : " + apod.title+"\n\n";
            msg += "date : " + apod.date + "\n\n";
            msg += "explanation : \n\n" + apod.explanation + "\n";
            MessageBoxResult result = MessageBox.Show(msg, apod.title, MessageBoxButton.OK);

        }

        // initializes important data for the app
        private void InitApp()
        {
            StartDate.SelectedDate = DateTime.Today;
            date = DateTime.Today;
            this.NeoFeed = NEOFeed.GetNeoFeed(nasaApi,date,date);
            this.apod.LoadApod(nasaApi);
            Units.Items.Add("kilometers");
            Units.Items.Add("meters");
            Units.Items.Add("miles");
            Units.Items.Add("feet");
            Units.SelectedIndex = 0;
            
            Initialized = true;
        }

        // opens the url for a neo object
        private void ViewSingleNeo(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string content = btn.Content.ToString();
            OpenUrl(string.Format("https://ssd.jpl.nasa.gov/tools/sbdb_lookup.html#/?sstr={0}&view=OPC",content));
        }

        // Took from stack overflow
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        // update the units for the object diameter
        private void Units_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLayout();
            var selectedValue = (sender as ComboBox).SelectedValue;
            if (!Initialized || this.Unit == selectedValue.ToString())
            {
                return;
            }
            this.Unit = selectedValue.ToString();
            NEO tempNeo = new NEO();
            NeoDisplayList = tempNeo.TransformNeoList(this.Unit, NeoFeed.near_earth_objects[NEODateList[0]]);
            // refresh the data grid
            NeoData.ItemsSource = NeoDisplayList;
        }

        // resize the window according to the APOD ratio
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;

            // Calculez le rapport d'aspect souhaité
            double aspectRatio = originalWidth / originalHeight;

            // Si la nouvelle largeur dépasse le rapport d'aspect, ajustez la hauteur
            if (width / aspectRatio > height)
            {
                height = width / aspectRatio;
            }
            // Sinon, ajustez la largeur
            else
            {
                width = height * aspectRatio;
            }

            // Redimensionnez la fenêtre pour conserver le rapport d'aspect
            this.Width = width;
            this.Height = height;
        }

        // changes the date to get the data from
        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = (sender as DatePicker).SelectedDate;
            if (selectedDate.HasValue)
            {
                date = selectedDate.Value;
                this.NeoFeed = NEOFeed.GetNeoFeed(nasaApi, date, date);
                NEODateList = new List<string>();
                foreach (var str in this.NeoFeed.near_earth_objects)
                {
                    NEODateList.Add(str.Key);
                }
                NEO tempNeo = new NEO();
                NeoDisplayList = tempNeo.TransformNeoList(this.Unit, NeoFeed.near_earth_objects[NEODateList[0]]);
                NeoData.ItemsSource = NeoDisplayList;
                NeoData.IsSynchronizedWithCurrentItem = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media.Imaging;

namespace lmorgado_nasa
{
    class NasaApi
    {
        private string ApiKey;

        // The NasaApi class is used to get data from the Nasa API
        public NasaApi(string apiKey)
        {
            ApiKey = apiKey;
        }

        public void SetApiKey(string key)
        {
            this.ApiKey = key;
        }

        // call the api using the api key
        public string Call(string url,List<string> parameters)
        {
            HttpClient client = new HttpClient();
            string result = "";
            try
            {
                // add the api key to the url
                url += "?api_key=" + ApiKey;

                // add the parameters to the url
                foreach (string parameter in parameters)
                {
                    url += "&" + parameter;
                }
                // call the api
                client.Timeout = TimeSpan.FromSeconds(5);
                return client.GetStringAsync(url).Result;
            }
            catch (Exception e)
            {
                MessageBoxResult res = MessageBox.Show("An error occurred while calling the API:\n " + e.Message, "An error occurred", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            return result;
        }
    }

    class APOD
    {
        public string date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        private BitmapImage HdImage { get; set; }
        private BitmapImage Image { get; set; }


        public APOD(string date="")
        {
            this.date = date;
        }

        public void LoadApod(NasaApi api)
        {
            List<string> parameters = new List<string>();
            if (date != "")
            {
                parameters.Add("date=" + date);
            }
            string result = api.Call("https://api.nasa.gov/planetary/apod", parameters);
            if (result == "")
            {
                // terminate the program if the api call failed
                Environment.Exit(0);
            }
            // parse the result
            APOD apod = JsonSerializer.Deserialize<APOD>(result);
            this.date = apod.date;
            this.explanation = apod.explanation;
            this.hdurl = apod.hdurl;
            this.media_type = apod.media_type;
            this.service_version = apod.service_version;
            this.title = apod.title;
            this.url = apod.url;
            this.HdImage = new BitmapImage(new Uri(this.hdurl));
            this.Image = new BitmapImage(new Uri(this.url));
        }

        public BitmapImage GetHdImage()
        {
            return this.HdImage;
        }

        public BitmapImage GetImage()
        {
            return this.Image;
        }
    }
    
    
}

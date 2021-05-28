using DesktopWeatherApplication.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWeatherApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void getWeather(string url, string zipcode)
        {
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<WeatherInformation.Root>(json);
                WeatherInformation.Root data = result;

                richTextBox1.Text += "ZIP Code: " + zipcode + "\n";
                richTextBox1.Text += "City: " + data.location.name + "\n";
                richTextBox1.Text += "State: " + data.location.region + "\n";
                richTextBox1.Text += "Country: " + data.location.country + "\n";
                richTextBox1.Text += "Latitude: " + data.location.lat + "\n";
                richTextBox1.Text += "Longitude: " + data.location.lon + "\n";
                richTextBox1.Text += "Time Zone: " + data.location.tz_id + "\n";
                richTextBox1.Text += "Local Time: " + data.location.localtime + "\n";
                richTextBox1.Text += "Updated: " + data.current.last_updated + "\n";
                richTextBox1.Text += "Celsius: " + data.current.temp_c + "\n";
                richTextBox1.Text += "Fahrenheit: " + data.current.temp_f + "\n";
                richTextBox1.Text += "Wind (MPH): " + data.current.wind_mph + "\n";
                richTextBox1.Text += "Wind (KPH): " + data.current.wind_kph + "\n";
                richTextBox1.Text += "Wind Degree: " + data.current.wind_degree + "\n";
                richTextBox1.Text += "Wind Direction: " + data.current.wind_dir + "\n";
                richTextBox1.Text += "Pressure (MB): " + data.current.pressure_mb + "\n";
                richTextBox1.Text += "Pressure (IN): " + data.current.pressure_in + "\n";
                richTextBox1.Text += "Precipitation (MM): " + data.current.precip_mm + "\n";
                richTextBox1.Text += "Precipitation (IN): " + data.current.precip_in + "\n";
                richTextBox1.Text += "Humidity: " + data.current.humidity + "\n";
                richTextBox1.Text += "Cloud: " + data.current.cloud + "\n";
                richTextBox1.Text += "Feels Like (C): " + data.current.feelslike_c + "\n";
                richTextBox1.Text += "Feels Like (F): " + data.current.feelslike_f + "\n";
                richTextBox1.Text += "Visibility (KM): " + data.current.vis_km + "\n";
                richTextBox1.Text += "Visibility (MI): " + data.current.vis_miles + "\n";
                richTextBox1.Text += "UV: " + data.current.uv + "\n";
                richTextBox1.Text += "Gust (MPH): " + data.current.gust_mph + "\n";
                richTextBox1.Text += "Gust (KPH): " + data.current.gust_kph + "\n";
                richTextBox1.Text += "Air Quality (co): " + data.current.air_quality.co + "\n";
                richTextBox1.Text += "Air Quality (no2): " + data.current.air_quality.no2 + "\n";
                richTextBox1.Text += "Air Quality (o3): " + data.current.air_quality.o3 + "\n";
                richTextBox1.Text += "Air Quality (so2): " + data.current.air_quality.so2 + "\n";
                richTextBox1.Text += "Air Quality (pm2_5): " + data.current.air_quality.pm2_5 + "\n";
                richTextBox1.Text += "Air Quality (pm10): " + data.current.air_quality.pm10 + "\n";
                richTextBox1.Text += "Air Quality (us-epa-index): " + data.current.air_quality.UsEpaIndex + "\n";
                richTextBox1.Text += "Air Quality (gb-defra-index): " + data.current.air_quality.GbDefraIndex + "\n";
                richTextBox1.Text += "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // variables
            string uniqueKey = "a884043157774396add153753212705";
            string getZipCode = "";

            // get zip code
            getZipCode = textBox1.Text;

            // create string for api call
            string apiCall = string.Concat("https://api.weatherapi.com/v1/current.json?key=", uniqueKey, "&q=", getZipCode, "&aqi=yes");

            // get weather
            getWeather(apiCall, getZipCode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear all
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}

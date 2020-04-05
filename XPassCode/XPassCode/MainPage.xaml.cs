using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace XPassCode
{

    //public class Data
    //{
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public string AuthMethod { get; set; }
    //    public string DeviceId { get; set; }
    //    public string IP { get; set; }

    //    public Data()
    //    {
    //        AuthMethod = "FaceId";
    //        DeviceId = "1";
    //        IP = "172.0.0.1";
    //    }

    //}
    public class Data
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthMethod { get; set; }
        public string DeviceId { get; set; }
        public string IP { get; set; }
        public string PushNotificationId { get; set; }
        public bool Disabled { get; set; }

        public Data()
        {
            AuthMethod = "UP";
            DeviceId = "beeef4d393ec2c98";
            IP = null;
            Disabled = false;
            PushNotificationId = "";
        }

    }

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PasscodeEntry.Focus();
        }

        private void PasscodeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            string val = entry.Text;

            if (val.Length > 4)
            {
                val = val.Remove(val.Length - 1);
                entry.Text = val;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            Data data = new Data
            {
                Username = username.Text,
                Password = password.Text
            };
            resultText.Text = "Loading...";

            await MakePost(data);
        }

        public async Task MakePost(Data data)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://test-videobanking.vtb.ge/api/sessions/authenticate/mobileClient");

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage result;

                try
                {
                    result = await client.PostAsync(uri, content);

                }
                catch (Exception ex)
                {

                    throw;
                }

                var resultString = await result.Content.ReadAsStringAsync();
                resultText.Text = resultString;

                Console.WriteLine(resultString);
            }
        }
    }
}

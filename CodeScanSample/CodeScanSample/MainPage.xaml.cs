using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace CodeScanSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ScanCode_Clicked(object sender, EventArgs e)
        {
            try {
                var scanPage = new ZXingScannerPage();
                scanPage.Title = "Scan Page";
                scanPage.OnScanResult += (result) =>
                {
                    //We have to stop scanning !
                    scanPage.IsScanning = false;
                    //we will display result on the label 
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                        Code.IsVisible = true;
                        Code.Text = result.Text;
                    }
                        );
                };
                await Navigation.PushAsync(scanPage);
            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }
           

        }
    }
}

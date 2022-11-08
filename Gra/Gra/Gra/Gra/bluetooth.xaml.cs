using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
//using Plugin.BluetoothLE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
namespace Gra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
       /* 
        IBluetoothLE ble;
        IAdapter adapter;
        ObservableCollection<IDevice> devicelist;
        */
     
        public Page1()
        {
            InitializeComponent();
            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            var devicelist = new ObservableCollection<IDevice>();
           DisplayAlert("Notice", ble.State.ToString(), "OK");

            adapter.StartScanningForDevicesAsync();
            adapter.DeviceDiscovered += (s, a) => devicelist.Add(a.Device);
            //  text.Text = state.ToString();

            //   DisplayAlert("Notice", devicelist.ToString(), "OK"); 

        }
/*
        private void Button_Clicked(object sender, EventArgs e)
        {
               
            DisplayAlert("Notice", ble.State.ToString(), "OK");
        }
*/          
    }






}
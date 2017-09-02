/*
 * PlayLeft Small application to get the battery level of your Xbox Controller as a UWP app.
 * First UWP as such just learing how the platform works.
 * Released under GPL3, Developed by Spoonie_au.
 */

using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.Gaming.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PlayLeft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Gamepad _Gamepad = null;

        string fullChargeCap = "";
        string remainingCap = "";
        string batteryStatus = "";
        bool wirelessConnected = false;

        public MainPage()
        {
            this.InitializeComponent();

            //Set the window size.
            ApplicationView.PreferredLaunchViewSize = new Size(500, 320);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            lblContSelected.Text = "No Controller connected.";
            lblConnection.Text = "";
            lblBatteryStatus.Text = "";
            lblFullChargeCap.Text = "";
            lblRemainingCap.Text = "";
            txtPercentage.Text = "";

            PraseController();

        }

        public async void PraseController()
        {
            //Set Add/Remove actions.
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;

            while (true)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    //If no game pad found.
                    if (_Gamepad == null)
                    {
                        return;
                    }

                    //Can not handle more than one controllers, will support 4 controllers once I can work out how to identify controllers.
                    if (Gamepad.Gamepads.Count > 1)
                    {
                        return;
                    }

                    // Get the current state.
                    var controllerWireless = _Gamepad.IsWireless;
                    wirelessConnected = controllerWireless;
             
                    //Get battery status.
                    var controllerBatt = _Gamepad.TryGetBatteryReport();
                    batteryStatus = controllerBatt.Status.ToString();
                    fullChargeCap = controllerBatt.FullChargeCapacityInMilliwattHours.ToString();
                    remainingCap = controllerBatt.RemainingCapacityInMilliwattHours.ToString();

                    fillDetails();

                });
                //set time in ms to check.
                await Task.Delay(TimeSpan.FromMilliseconds(5));
            }


        }

        private void fillDetails()
        {
            lblContSelected.Text = "Controller Connected.";

            if (wirelessConnected == true)
            {
                lblConnection.Text = "Connected via wireless.";
            }
            else
            {
                lblConnection.Text = "Connected via charge and play cable";
            }

            lblBatteryStatus.Text = "Battery is " + batteryStatus;
            lblFullChargeCap.Text = "Full charge capacipty " + fullChargeCap + "mwh";
            lblRemainingCap.Text = "Remaining charge capacipty " + remainingCap + "mwh";

            //Call calss CalcPercentage and pass the remainingCap and fullChargeCap, will get a percentage as a retuen. 
            CalcPercentage calcPercentage = new CalcPercentage();
            txtPercentage.Text = calcPercentage.Percentage(double.Parse(remainingCap), double.Parse(fullChargeCap));

        }

        //Remove controller action.
        private async void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            _Gamepad = null;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                               {
                                   lblContSelected.Text = "No Controler connected.";
                                   lblConnection.Text = "";
                                   lblBatteryStatus.Text = "";
                                   lblFullChargeCap.Text = "";
                                   lblRemainingCap.Text = "";
                                   txtPercentage.Text = "";

                                   Toasts disconnectToast = new Toasts();
                                   disconnectToast.removeToast();
                               });
        }

        //Add controller action.
        private async void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            _Gamepad = e;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //If gamepad count is larger than one, do noting. will support 4 controllers once I can work out how to identify controllers.
                if (Gamepad.Gamepads.Count > 1)
                {
                    return;
                }

                Toasts addToast = new Toasts();
                addToast.addToast();

            });
        }

        //Call About.
        private void abAbout_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AboutAsync();
        }

        private async void AboutAsync()
        {
            About about = new About();
            await about.ShowAsync();
        }

        
    }
}

      
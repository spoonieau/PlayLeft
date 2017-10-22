/*
 * PlayLeft Small application to get the battery level of your Xbox Controller as a UWP app.
 * First UWP as such just learing how the platform works.
 * Released under GPL3, Developed by Spoonie_au.
 */

using Windows.ApplicationModel.Resources;
using Windows.UI.Notifications;

namespace PlayLeft
{
    class Toasts
    {
        public void addToast()
        {
            //Load localized string
            var resourceLoader = ResourceLoader.GetForCurrentView();

            //Contents of addToast
            var templateAdd = "<toast launch=\"app-defined-string\">" +
                              "<visual>" +
                              "<binding template =\"ToastGeneric\">" +
                              "<text>" + resourceLoader.GetString("AppDisplayName") + "</text>" +
                              "<text>" + resourceLoader.GetString("ControllerConnected") + "</text>" +
                              "</binding>" +
                              "</visual>" +
                              "</toast>";

            //Create and show Toast
            var xmlAddToast = new Windows.Data.Xml.Dom.XmlDocument();
            xmlAddToast.LoadXml(templateAdd);

            var showAddToast = new ToastNotification(xmlAddToast);
            var toast = ToastNotificationManager.CreateToastNotifier();


            toast.Show(showAddToast);


        }

        public void removeToast()
        {
            //Load localized string
            var resourceLoader = ResourceLoader.GetForCurrentView();


            //Contents of RemoveToast
            var templateRemove = "<toast launch=\"app-defined-string\">" +
                                 "<visual>" +
                                 "<binding template =\"ToastGeneric\">" +
                                 "<text>"+ resourceLoader.GetString("AppDisplayName") + "</text>" +
                                 "<text>" + resourceLoader.GetString("ControllerDisconnected") + "</text>" +
                                 "</binding>" +
                                 "</visual>" +
                                 "</toast>";

            //Create and show Toast
            var xmlRemoveToast = new Windows.Data.Xml.Dom.XmlDocument();
            xmlRemoveToast.LoadXml(templateRemove);

            var showRemoveToast = new ToastNotification(xmlRemoveToast);
            var toast = ToastNotificationManager.CreateToastNotifier();

            toast.Show(showRemoveToast);
        }
    }
}

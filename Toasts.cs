/*
 * PlayLeft Small application to get the battery level of your Xbox Controller as a UWP app.
 * First UWP as such just learing how the platform works.
 * Released under GPL3, Developed by Spoonie_au.
 */

using Windows.UI.Notifications;

namespace PlayLeft
{
    class Toasts
    {
        public void addToast()
        {   
            var templateAdd = "<toast launch=\"app-defined-string\">" +
                              "<visual>" +
                              "<binding template =\"ToastGeneric\">" +
                              "<text>PlayLeft</text>" +
                              "<text>Controller Connected.</text>" +
                              "</binding>" +
                              "</visual>" +
                              "</toast>"; 

            var xmlAddToast = new Windows.Data.Xml.Dom.XmlDocument();
            xmlAddToast.LoadXml(templateAdd);

            var showAddToast = new ToastNotification(xmlAddToast);
            var toast = ToastNotificationManager.CreateToastNotifier();

            toast.Show(showAddToast);
            

        }

        public void removeToast()
        {
            var templateRemove = "<toast launch=\"app-defined-string\">" +
                                 "<visual>" +
                                 "<binding template =\"ToastGeneric\">" +
                                 "<text>PlayLeft</text>" +
                                 "<text>Controller Disconnected.</text>" +
                                 "</binding>" +
                                 "</visual>" +
                                 "</toast>";

            var xmlRemoveToast = new Windows.Data.Xml.Dom.XmlDocument();
            xmlRemoveToast.LoadXml(templateRemove);

            var showRemoveToast = new ToastNotification(xmlRemoveToast);
            var toast = ToastNotificationManager.CreateToastNotifier();

            toast.Show(showRemoveToast);
        }
    }
}

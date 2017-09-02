/*
 * PlayLeft Small application to get the battery level of your Xbox Controller as a UWP app.
 * First UWP as such just learing how the platform works.
 * Released under GPL3, Developed by Spoonie_au.
 */

using System;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;


// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

    //About ContentDialog.
namespace PlayLeft
{
    public sealed partial class About : ContentDialog
    {
        public About()
        {
            this.InitializeComponent();

            //Set title of ContentDialog.
            this.Title = "PlayLeft " + (typeof(App).GetTypeInfo().Assembly.GetName().Version).ToString();

            //Set text of Textbox.
            tbAbout.Text = "Small application to get the battery level of your Xbox Controller." + Environment.NewLine +
                "Released under GPL3" + Environment.NewLine + "Developed by Spoonie_au" + Environment.NewLine +
                "Source available at ";

            //Add a hyperlink to the end of the text of the Textbox text.
            Hyperlink hyperlink = new Hyperlink();
            Run gitLink = new Run();
            gitLink.Text = "https://github.com/spoonieau/PlayLeft";
            hyperlink.NavigateUri = new Uri("https://github.com/spoonieau/PlayLeft");
            hyperlink.Inlines.Add(gitLink);
            tbAbout.Inlines.Add(hyperlink);

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            return;
        }
    }
}

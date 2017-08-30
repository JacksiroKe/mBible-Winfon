using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace mBible
{
    public partial class EeSettings : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        long usedt;
        int secst;

        public EeSettings()
        {
            InitializeComponent();
            EeSettings_Loaded();
        }

        private void EeSettings_Loaded()
        {
            string[] sett_titles = new string[] 
            { 
                "Application Font Size", 
                "Application Font Type",
                "Reset Application",
                "Call: Jackson Siro",
                "Call: Jackson Siro",
                "Email Us Now",
                "Visit Us Online",
                "Application Mode",
                "Application Version"
            };
            string[] sett_content = new string[] 
            { 
                "Font Size: " + settings.FontSizeSetting.ToString(),
                "Font Type: " + settings.FontTypeSetting.ToString(),
                "Reset App Settings",
                "+254 711 474 787 [safaricom]",
                "+254 731 973 180 [airtel]",
                "smataweb@gmail.com",
                "http://jacksiro.wordpress.com",
                installed_on(),
                "0.0.0.012"
            };

            for (int i = 0; i < sett_titles.Length; i++)
            {
                Current_SettView sett_obj = new Current_SettView();
                sett_obj.SettTitle = sett_titles[i];
                sett_obj.SettDescri = sett_content[i];
                SettListBox.Items.Add(sett_obj);
            }
        }

        public class Current_SettView
        {
            public string SettTitle { get; set; }
            public string SettDescri { get; set; }
        }

        private void SettListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SettListBox.SelectedIndex == -1)
                return;

            if (SettListBox.SelectedIndex == 0)
                NavigationService.Navigate(new Uri("/EeSettings1.xaml", UriKind.Relative));

            else if (SettListBox.SelectedIndex == 1)
                NavigationService.Navigate(new Uri("/EeSettings2.xaml", UriKind.Relative));

            else if (SettListBox.SelectedIndex == 2)
            {
                MessageBoxResult WantToReset = MessageBox.Show("Are you sure you want to reset this app? Everything" +
                    " will be lost from your App Settings to database.", "Want to Reset mBible?", MessageBoxButton.OK);

                if (WantToReset == MessageBoxResult.OK)
                {

                    settings.FirstTimeSetting = false;
                    settings.InitialSetupSetting = false;
                    settings.BooksSetupSetting = false;
                    settings.VersesSetupSetting = false;
                    settings.SeenTutorialSetting = false;
                    settings.CurrentTestamentSetting = 1;
                    settings.CurrentEnglishSetting = "Genesis";
                    settings.CurrentAbbrevSetting = "Gen.";
                    settings.CurrentSwahiliSetting = "Mwanzo";
                    settings.CurrentBookSetting = 1;
                    settings.CurrentChaptersSetting = 50;
                    settings.SelectedChapterSetting = 1;
                    settings.SelectedVerseSetting = 1;
                    settings.FontSizeSetting = 50;
                    settings.FontTypeSetting = "Arial";
                    settings.InstalledonSetting = 0;
                    settings.LastParaidSetting = 1;
                    settings.SkippedRatingSetting = 0;
                    settings.RatedTSWSetting = false;
                    settings.LastSearchSetting = "";
                    settings.Hint1Setting = false;
                    settings.Hint2Setting = false;
                    settings.Hint3Setting = false;
                    settings.Hint4Setting = false;
                    settings.Hint5Setting = false;
                    settings.Hint6Setting = false;
                    settings.Hint7Setting = false;
                    settings.MessageFindSetting = false;
                    settings.MessageSearchSetting = false;
                    settings.LastLoadedSetting = 1;

                    BooksDelete deletebk = new BooksDelete();
                    deletebk.DeleteAllBooks();


                    VersesDelete deletevs = new VersesDelete();
                    deletevs.DeleteAllVerses();
                    NavigationService.Navigate(new Uri("/AppStart.xaml", UriKind.Relative));

                }

                else if (WantToReset == MessageBoxResult.Cancel)
                {
                        
                }
            }

            else if (SettListBox.SelectedIndex == 3)
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.PhoneNumber = "+254711474787";
                phoneCallTask.DisplayName = "Jack Siro";
                phoneCallTask.Show();
            }

            else if (SettListBox.SelectedIndex == 4)
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.PhoneNumber = "+254731973180";
                phoneCallTask.DisplayName = "Jack Siro";
                phoneCallTask.Show();
            }

            else if (SettListBox.SelectedIndex == 5)
            {
                EmailComposeTask emailComposeTask = new EmailComposeTask();
                emailComposeTask.Subject = "vSongBook Inquiry";
                emailComposeTask.Body = "God bless you Jack Siro. Am contacting you concerning vSongBook";
                emailComposeTask.To = "smataweb@gmail.com";
                emailComposeTask.Show();
            }

            else if (SettListBox.SelectedIndex == 6)
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri("http://jacksiro.wordpress.com", UriKind.Absolute);
                webBrowserTask.Show();
            }
            SettListBox.SelectedIndex = -1;
        }

        public string installed_on()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            usedt = nowMilSecond - settings.InstalledonSetting;
            secst = (int)(usedt / 1000);

            if (secst < 60) return "Installed " + secst + " seconds ago";
            else if (secst < 3600) return "Installed " + secst / 60 + " minutes ago";
            else if (secst < 86400) return "Installed " + secst / 3600 + " hours ago";
            else if (secst < 604800) return "Installed " + secst / 86400 + " days ago";
            else if (secst < 2419200) return "Installed " + secst / 604800 + " weeks ago";
            else if (secst < 29030400) return "Installed " + secst / 2419200 + " months ago";
            else if (secst > 29030400) return "Installed " + secst / 29030400 + " years ago";
            return installed_on();
        }
    }
}
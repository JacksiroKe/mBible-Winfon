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
using System.Windows.Media.Imaging;

namespace mBible
{
    public partial class AppStart : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public AppStart()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AppStart_Loaded);

        }

        private void AppStart_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            if (!settings.FirstTimeSetting) {
				SetFirstUse();
				settings.FirstTimeSetting = true;
			}
            //settings.InitialSetupSetting = true;
            //NavigationService.Navigate(new Uri("/EeSettings2.xaml", UriKind.Relative));
                    
            if (!settings.InitialSetupSetting)
            {
                NavigationService.Navigate(new Uri("/BbBibleLoad.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/CcBible.xaml", UriKind.Relative));
            }
        }

        private void SetFirstUse()
        {
            if (!settings.FirstTimeSetting)
            {
                settings.FirstTimeSetting = true;
                DateTime unixEpoch = new DateTime(1970, 1, 1);
                DateTime localDate = DateTime.Now;
                long totMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;
                settings.InstalledonSetting = totMilSecond;

            }
        }

    }
}
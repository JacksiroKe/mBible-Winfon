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
    public partial class EeSettings2 : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public EeSettings2()
        {
            InitializeComponent();
            this.DataContext = App.ViewFont;
            EeSettings2_Loaded();

        }

        /*
        private void Togglename_Click_1(object sender, RoutedEventArgs e)
        {
            if (Togglename.IsChecked == true)
                MessageBox.Show("Switch is on");
            else
                MessageBox.Show("Switch is of");
        }
        */

        private void EeSettings2_Loaded()
        {
            if (!App.ViewFont.IsDataLoaded)
            {
                App.ViewFont.LoadData();
            }
            
        }

        
        private void lstCurrFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lstCurrFont.SelectedIndex == -1)
                return;

            ItemViewFont myresults = (sender as ListPicker).SelectedItem as ItemViewFont;
            txtFontType.Text = myresults.FTName;
            settings.FontTypeSetting = myresults.FTName;
            //txtSampleText.FontFamily = myresults.FTName;
        }

    }
}
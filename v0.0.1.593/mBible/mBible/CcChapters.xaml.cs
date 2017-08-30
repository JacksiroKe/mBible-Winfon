using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using mBible.Resources;

namespace mBible
{
    public partial class CcChapters : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        int max_len;
        public CcChapters()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(CcChapters_Loaded);
            
        }

        private void CcChapters_Loaded(object sender, RoutedEventArgs e)
        {
            if (settings.CurrentChaptersSetting > 100) max_len = 4;
            else if (settings.CurrentChaptersSetting < 100) max_len = 3;
            else if (settings.CurrentChaptersSetting < 10) max_len = 2;

            txtBook_P.Text = settings.CurrentEnglishSetting + " ...";
            txtMaximum_P.Text = "Chapter? [1-" + settings.CurrentChaptersSetting + "]";


        }
        
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text.Remove(txtChapter_P.Text.Length - 1, 1);
            if (String.IsNullOrWhiteSpace(txtChapter_P.Text))
            {
                btnProceed_P.IsEnabled = false;
            }
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 9;
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 8;
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 7;
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 6;
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 5;

        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 4;
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 3;

        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 2;
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 1;
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            txtChapter_P.Text = txtChapter_P.Text + 0;
        }


        private void txtChapter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtChapter_P.Text))
            {
                try
                {
                    if (txtChapter_P.Text.Length < max_len)
                    {
                        int chapters = Int32.Parse(txtChapter_P.Text);
                        txtChapter_P.Text = chapters.ToString();
                        if (chapters > 0 && chapters < settings.CurrentChaptersSetting + 1)
                        {
                            btnProceed_P.IsEnabled = true;
                        }
                        else
                        {
                            btnProceed_P.IsEnabled = false;
                        }
                    }
                    else
                    {
                        btn_Disable();
                    }
                }
                catch (Exception)
                {
                    btn_Disable();
                }
                
            }
        }

        private void btn_Disable()
        {
            btnNine_P.IsEnabled = false;
            btnEight_P.IsEnabled = false;
            btnSeven_P.IsEnabled = false;
            btnSix_P.IsEnabled = false;
            btnFive_P.IsEnabled = false;
            btnFour_P.IsEnabled = false;
            btnThree_P.IsEnabled = false;
            btnTwo_P.IsEnabled = false;
            btnOne_P.IsEnabled = false;
            btnZero_P.IsEnabled = false;
            btnProceed_P.IsEnabled = false;
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            int chapters = Int32.Parse(txtChapter_P.Text);
            if (chapters > 0 && chapters < settings.CurrentChaptersSetting + 1)
            {
                settings.SelectedChapterSetting = chapters;
                NavigationService.Navigate(new Uri("/CcRead.xaml", UriKind.Relative));
            }
        }

    }
}
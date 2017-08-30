using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using System.Threading;
using System.IO.IsolatedStorage;
using System.ComponentModel;

namespace mBible
{
    public partial class BbBibleLoad : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        bool startedLoading;
        public BbBibleLoad()
        {
            InitializeComponent();
            startedLoading = false;
            this.Loaded += new RoutedEventHandler(BbBibleLoad_Loaded);

        }

        private void BbBibleLoad_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();

            if (!settings.BooksSetupSetting)
            {
                settings.BooksSetupSetting = true;
                LoadBibleDetails();
            }
            btnProceed.Visibility = Visibility.Visible;
            txtProgress.Text = "This app is going load the Bible for the first time. Your screen should be on during this time "
                + "and not get locked. Please go back and change lockscreen settings to like more than 30 minutes. "
                + "before you proceed with loading the Bible";
        }

        private void LoadBibleDetails()
        {
            String line;
            String pathoffile = "RealData/mdetails.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile);
            try
            {

                while ((line = reader.ReadLine()) != null)
                {
                    String[] strings = line.Split('%');
                    BookAdd add = new BookAdd();
                    add.AddBook(Int32.Parse(strings[0]), Int32.Parse(strings[1]), 
                        Int32.Parse(strings[2]), strings[3], strings[4], strings[5]);
                }
            }
            catch (Exception)
            {
                reader.Close();
            }

        }

        private void ProceedloadingBible(object sender, RoutedEventArgs e)
        {
            startedLoading = true;
            btnProceed.Visibility = Visibility.Collapsed;
            txtProgress.Text = "Loading the Master Bible has began. Be patient while Master Bible loads...";
            
            settings.InitialSetupSetting = true;
            settings.VersesSetupSetting = true;
            LoadBibleVerse();
            
            NavigationService.Navigate(new Uri("/CcBible.xaml", UriKind.Relative));
        }

        private void LoadBibleVerse()
        {
            String line;
            String pathoffile = "RealData/mbible.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile);
            try
            {

                while ((line = reader.ReadLine()) != null)
                {
                    String[] strings = line.Split('%');
                    VerseAdd add = new VerseAdd();
                    add.AddVerse(strings[0], strings[1]);
                }
            }
            catch (Exception)
            {
                reader.Close();
            }

        }

        private void LoadBibleVerses(int fileno)
        {
            String line;
            String pathoffile = "RealData/mbible" + fileno + ".txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile);
            try
            {

                while ((line = reader.ReadLine()) != null)
                {
                    String[] strings = line.Split('%');
                    VerseAdd add = new VerseAdd();
                    add.AddVerse(strings[0], strings[1]);
                }
            }
            catch (Exception)
            {
                reader.Close();
            }

        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            //base.OnBackKeyPress(e);
            if (startedLoading)
            {
                if (!settings.VersesSetupSetting)
                {
                    MessageBoxResult BeforeUExit = MessageBox.Show("Are you sure you want to exit this app? "
                        + "The current task will be aborted and will never resume even after you reopen it.", 
                        "Warning on Exit", MessageBoxButton.OK);

                    if (BeforeUExit == MessageBoxResult.OK)
                    {
                        NavigationService.GoBack();
                    }

                    /*
                    else if (BeforeUExit == MessageBoxResult.Cancel)
                    {
                        
                    }
                         */
                }
            }
        }
        
    }
}
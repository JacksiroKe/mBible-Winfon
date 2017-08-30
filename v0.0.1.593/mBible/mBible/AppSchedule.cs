using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Threading;
using System.IO.IsolatedStorage;

namespace mBible
{
    public class AppSchedule : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;

        /// <remarks>
        /// AppSchedule constructor, initializes the UnhandledException handler
        /// </remarks>
        public AppSchedule()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += AppSchedule_UnhandledException;
                });
            }
        }

        /// Code to execute on Unhandled Exceptions
        private void AppSchedule_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void OnInvoke(ScheduledTask task)
        {
            if (task.Name.Equals("MasterBibleLoad", StringComparison.OrdinalIgnoreCase))
            {
                LoadBibleDetails();
                LoadBibleVerses();
                //settings.InitialSetupSetting = true;

                ShellToast toast = new ShellToast();
                Mutex mutex = new Mutex(true, "mBibleScheduledAgentData");
                mutex.WaitOne();
                IsolatedStorageSettings setting = IsolatedStorageSettings.ApplicationSettings;
                toast.Title = setting["mBibleScheduledAgentData"].ToString();
                mutex.ReleaseMutex();
                toast.Content = "Task Running";
                toast.Show();
            }
            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(3));
            NotifyComplete();
        }

        private void LoadBibleDetails()
        {
            String pathoffile = "RealData/mdetails.txt";
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] strings = line.Split('%');
                        if (strings.Length < 2) continue;
                        VerseAdd add = new VerseAdd();
                        add.AddVerse(strings[0], strings[1]);

                        HolyBibleAdd adddetail = new HolyBibleAdd();
                        adddetail.AddHolyBible(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5]);
                    }
                }
            }
            catch (Exception) { }
        }

        private void LoadBibleVerses()
        {
            String pathoffile = "RealData/mbible.txt";
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] strings = line.Split('%');
                        if (strings.Length < 2) continue;
                        VerseAdd add = new VerseAdd();
                        add.AddVerse(strings[0], strings[1]);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
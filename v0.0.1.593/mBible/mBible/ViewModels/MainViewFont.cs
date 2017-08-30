using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace mBible
{
    public class MainViewFont : INotifyPropertyChanged
    {
        public MainViewFont()
        {
            this.MyFonts = new ObservableCollection<ItemViewFont>();
        }

        /// <summary>
        /// A collection for SettingsModel objects.
        /// </summary>
        public ObservableCollection<ItemViewFont> MyFonts { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewTrack1 property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few SettingsModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.MyFonts.Add(new ItemViewFont() { FTName = "Arial" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Calibri" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Comic Sans MS" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Courier New" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "DengXian" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Georgia" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Lucida Sans Unicode" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Tahoma" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Times New Roman" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Trebuchet MS" });
            this.MyFonts.Add(new ItemViewFont() { FTName = "Verdana" });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
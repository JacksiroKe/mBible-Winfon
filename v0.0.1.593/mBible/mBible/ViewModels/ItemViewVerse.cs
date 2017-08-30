using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace mBible
{
    public class ItemViewVerse : INotifyPropertyChanged
    {

        private string _title;
        /// <summary>
        /// Sample Testament property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _verse;
        /// <summary>
        /// Sample Book property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Verse
        {
            get
            {
                return _verse;
            }
            set
            {
                if (value != _verse)
                {
                    _verse = value;
                    NotifyPropertyChanged("Verse");
                }
            }
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
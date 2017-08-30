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
    public class ItemViewBible : INotifyPropertyChanged
    {
        
        private string _testament;
        /// <summary>
        /// Sample Testament property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Testament
        {
            get
            {
                return _testament;
            }
            set
            {
                if (value != _testament)
                {
                    _testament = value;
                    NotifyPropertyChanged("Testament");
                }
            }
        }
        
        private string _book;
        /// <summary>
        /// Sample Book property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Book
        {
            get
            {
                return _book;
            }
            set
            {
                if (value != _book)
                {
                    _book = value;
                    NotifyPropertyChanged("Book");
                }
            }
        }
        
         private string _chapters;
        /// <summary>
        /// Sample Chapters property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Chapters
        {
            get
            {
                return _chapters;
            }
            set
            {
                if (value != _chapters)
                {
                    _chapters = value;
                    NotifyPropertyChanged("Chapters");
                }
            }
        } 
        
         private string _english;
        /// <summary>
        /// Sample English property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string English
        {
            get
            {
                return _english;
            }
            set
            {
                if (value != _english)
                {
                    _english = value;
                    NotifyPropertyChanged("English");
                }
            }
        } 
         
         private string _abbrevs;
        /// <summary>
        /// Sample Chapters property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Abbrevs
        {
            get
            {
                return _abbrevs;
            }
            set
            {
                if (value != _abbrevs)
                {
                    _abbrevs = value;
                    NotifyPropertyChanged("Abbrevs");
                }
            }
        }

        private string _swahili;
        /// <summary>
        /// Sample Chapters property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Swahili
        {
            get
            {
                return _swahili;
            }
            set
            {
                if (value != _swahili)
                {
                    _swahili = value;
                    NotifyPropertyChanged("Swahili");
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
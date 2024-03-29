﻿using System;
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

namespace mBible
{
    public partial class EeSettings1 : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();

        public EeSettings1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(EeSettings1_Loaded);

        }

        private void EeSettings1_Loaded(object sender, RoutedEventArgs e)
        {
            int myfontsize = settings.FontSizeSetting;
            fontResizer.Value = myfontsize;
            sample_text.FontSize = myfontsize;
        }

        private void SaveNewFontSize(object sender, TextChangedEventArgs e)
        {
            Double myfonts = Convert.ToDouble(new_font_size.Text);
            int newfonts = Convert.ToInt32(myfonts);

            settings.FontSizeSetting = newfonts;
            sample_text.FontSize = newfonts;

        }
    }
}
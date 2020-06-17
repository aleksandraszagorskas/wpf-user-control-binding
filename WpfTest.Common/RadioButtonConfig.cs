using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTest.Common
{
    public class RadioButtonConfig : RadioButton
    {
        public bool IsConfigured
        {
            get { return (bool)GetValue(IsConfiguredProperty); }
            set { SetValue(IsConfiguredProperty, value); }
        }

        public static readonly DependencyProperty IsConfiguredProperty =
            DependencyProperty.Register("IsConfigured", typeof(bool), typeof(RadioButtonConfig), new PropertyMetadata(false));


    }
}

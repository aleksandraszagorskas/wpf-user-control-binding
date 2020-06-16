using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest.UserControlBinding
{
    /// <summary>
    /// Interaction logic for BindingControl.xaml
    /// </summary>
    public partial class BindingControl : UserControl
    {
        public string BindLabelText
        {
            get { return (string)GetValue(BindLabelTextProperty); }
            set { SetValue(BindLabelTextProperty, value); }
        }

        public static readonly DependencyProperty BindLabelTextProperty =
            DependencyProperty.Register("BindLabelText", typeof(string), typeof(BindingControl), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public BindingControl()
        {
            InitializeComponent();
            //solution
            MyGrid.DataContext = new BindingControlViewModel();

            //old data context
            //this.DataContext = new BindingControlViewModel();
        }
    }

    public class BindingControlViewModel: ObservableObject
    {
        private string labelText;

        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }

        private DelegateCommand changeTextCommand;
        public ICommand ChangeTextCommand => changeTextCommand;

        public BindingControlViewModel()
        {
            changeTextCommand = new DelegateCommand(OnChangeTextCommand, CanChangeTextCommand);

            //default values
            LabelText = "Default value";
        }

        private bool CanChangeTextCommand(object arg)
        {
            return true;
        }

        private void OnChangeTextCommand(object obj)
        {
            var rng = new Random();
            LabelText = $"New text {rng.Next(0,100)}";
        }
    }
}

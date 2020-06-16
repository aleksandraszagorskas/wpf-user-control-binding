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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }

    public class MainWindowViewModel: ObservableObject
    {
        private string headerLabel = "Default value for MainWindow property init";
        public string HeaderLabel
        {
            get { return headerLabel; }
            set { SetProperty(ref headerLabel, value); }
        }

        private DelegateCommand changeMainTextCommand;
        public ICommand ChangeMainTextCommand => changeMainTextCommand;

        public MainWindowViewModel()
        {

            changeMainTextCommand = new DelegateCommand(OnChangeMainTextCommand, CanChangeMainTextCommand);

            //Default values
            HeaderLabel = "Default value for MainWindow property";
        }

        private bool CanChangeMainTextCommand(object arg)
        {
            return true;
        }

        private void OnChangeMainTextCommand(object obj)
        {
            var rng = new Random();
            HeaderLabel = $"MainWindow property changed {rng.Next(100,200)}";
        }
    }
}

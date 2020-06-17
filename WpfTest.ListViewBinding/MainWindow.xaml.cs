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
using WpfTest.Common;

namespace WpfTest.ListViewBinding
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

    public class MainWindowViewModel : ObservableObject
    {
        private List<SelectionListItem> selectableItems = new List<SelectionListItem>();
        public List<SelectionListItem> SelectableItems
        {
            get { return selectableItems; }
            set
            {
                SelectedItem = value[0];
                SetProperty(ref selectableItems, value);
            }
        }

        private SelectionListItem selectedItem = new SelectionListItem { Text = "-", IsConfigured = false };
        public SelectionListItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        private SelectionListItem configuredItem = new SelectionListItem { Text = "-", IsConfigured = false };
        public SelectionListItem ConfiguredItem
        {
            get { return configuredItem; }
            set { SetProperty(ref configuredItem, value); }
        }

        private string valueText;
        public string ValueText
        {
            get { return valueText; }
            set { SetProperty(ref valueText, value); }
        }


        private DelegateCommand generateListButtonClick;
        public ICommand GenerateListButtonClick => generateListButtonClick;
        private DelegateCommand configureItemButtonClick;
        public ICommand ConfigureItemButtonClick => configureItemButtonClick;
        private DelegateCommand getValueButtonClick;
        public ICommand GetValueButtonClick => getValueButtonClick;

        public MainWindowViewModel()
        {
            generateListButtonClick = new DelegateCommand(OnAddToListButtonClick, CanAddToListButtonClick);
            configureItemButtonClick = new DelegateCommand(OnConfigureItemButtonClick, CanConfigureItemButtonClick);
            getValueButtonClick = new DelegateCommand(OnGetValueButtonClick, CanGetValueButtonClick);
        }

        private bool CanGetValueButtonClick(object arg)
        {
            return true;
        }

        private void OnGetValueButtonClick(object obj)
        {
            var text = SelectedItem.ValueObj.ToString();
            ValueText = text;
        }

        private bool CanConfigureItemButtonClick(object arg)
        {
            return true;
        }

        private void OnConfigureItemButtonClick(object obj)
        {
            var rng = new Random();
            foreach (var item in SelectableItems)
            {
                if (item.IsConfigured)
                {
                    item.IsConfigured = false;
                }
            }

            var index = rng.Next(SelectableItems.Count);
            SelectableItems[index].IsConfigured = true;

            ConfiguredItem = SelectableItems[index];

        }



        private bool CanAddToListButtonClick(object arg)
        {
            return true;
        }

        private void OnAddToListButtonClick(object obj)
        {
            var rng = new Random();
            var list = new List<SelectionListItem>();
            for (int i = 0; i < rng.Next(10, 100); i++)
            {
                var item = new SelectionListItem { Text = $"item {rng.Next(0, 100)}", ValueObj = GetRandomObj(rng), IsConfigured = false };
                list.Add(item);
            }

            var index = rng.Next(list.Count);
            list[index].IsConfigured = true;

            ConfiguredItem = list[index];

            SelectableItems = list;
        }

        private enum TestType
        {
            Undefined,
            State1,
            State2,
            State3
        }

        private object GetRandomObj(Random rng)
        {
            Array testTypeValues = Enum.GetValues(typeof(TestType));
            TestType randomTestType = (TestType)testTypeValues.GetValue(rng.Next(testTypeValues.Length));
            List<int> intList = new List<int>();
            for (int i = 0; i < rng.Next(1,100); i++)
            {
                intList.Add(rng.Next(100, 1000));
            }

            var objArr = new object[] { $"Some string value {rng.Next(0, 100)}", randomTestType, intList[rng.Next(intList.Count)] };
            return objArr[rng.Next(objArr.Length)];
        }
    }


}

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

namespace WpfTest.ListViewBinding
{
    /// <summary>
    /// Interaction logic for SelectionList.xaml
    /// </summary>
    public partial class SelectionList : UserControl
    {
        public List<SelectionListItem> Items
        {
            get { return (List<SelectionListItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(List<SelectionListItem>), typeof(SelectionList), new PropertyMetadata(new List<SelectionListItem>()));


        public SelectionListItem SelectedItem
        {
            get { return (SelectionListItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(SelectionListItem), typeof(SelectionList), new FrameworkPropertyMetadata(new SelectionListItem(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public SelectionList()
        {
            InitializeComponent();
        }
    }
}

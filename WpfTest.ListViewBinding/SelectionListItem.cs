using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Common;

namespace WpfTest.ListViewBinding
{
    public class SelectionListItem: ObservableObject
    {
		private string text;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		private object valueObj;
		public object ValueObj
		{
			get { return valueObj; }
			set { valueObj = value; }
		}

		private bool isConfigured;
		public bool IsConfigured
		{
			get { return isConfigured; }
			set { SetProperty(ref isConfigured, value); }
		}

		//private bool isSelected;
		//public bool IsSelected
		//{
		//	get { return isSelected; }
		//	set { SetProperty(ref isSelected, value); }
		//}
	}
}

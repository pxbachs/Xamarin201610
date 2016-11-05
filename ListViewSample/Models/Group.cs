using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ListViewSample.Core.Models;

namespace ListViewSample
{
	public class Group: ObservableCollection<Category>
	{
		public int Id { get; set; }
		private string _name;
		public string Name
		{
			get { return _name; }
			set {
				_name = value;
				//RaisePropertyChanged("Name");
			}
		}

		public Group(string name)
		{
			this.Name = name;
		}
	}
}

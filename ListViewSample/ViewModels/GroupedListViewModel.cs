using System;
using System.Collections.ObjectModel;
using ListViewSample.Core.Models;
using MvvmCross.Core.ViewModels;

namespace ListViewSample.Core.ViewModels
{
	public class GroupedListViewModel : MvxViewModel
	{
		public ObservableCollection<Category> ListCategory { get; set; }

		private ObservableCollection<Group> _ListGroup;
		public ObservableCollection<Group> ListGroup { get; set; }

		public string this[int index, string indexer] { 
			get
			{
				return ListGroup[0].Name;
			}
			set {
				ListGroup[0].Name = value;
				RaisePropertyChanged(() => ListGroup);
			}
		}

		public GroupedListViewModel()
		{
			ListCategory = new ObservableCollection<Category>();

			ListCategory.Add(new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"));
			ListCategory.Add(new Category("Category 2", "Description 2", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"));
			ListCategory.Add(new Category("Category 3", "Description 3", "http://img.f30.vnecdn.net/2016/10/21/buonlau-3209-1477065005_180x108.jpg"));
			ListCategory.Add(new Category("Category 4", "Description 4", "http://img.f30.vnecdn.net/2016/10/21/buonlau-3209-1477065005_180x108.jpg"));

			ListGroup = new ObservableCollection<Group>()
			{
				new Group("Group 1") {
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg")
				}, 
				new Group("Group 2") {
					new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg")
				},
				new Group("Group 3") {
					new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg")
				},
				new Group("Group 4") {
					new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg"),
						new Category("Category 1", "Description 1", "http://img.f29.vnecdn.net/2016/10/22/anhmoi2-3086-1477115773_490x294.jpg")
				}
			};
		}
	}
}

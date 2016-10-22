using System;
namespace ListViewSample.Core.Models
{
	public class Category
	{
		public string Name { get; set; }
		public string Desc { get; set; }
		public string Icon { get; set; }

		public Category(string name, string desc, string icon) {
			this.Name = name;
			this.Desc = desc;
			this.Icon = icon;
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}

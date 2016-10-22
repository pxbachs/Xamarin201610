using System;
namespace ListViewSample.Core.Models
{
	public class Category
	{
		public string Name;
		public string Desc;
		public string Icon;

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

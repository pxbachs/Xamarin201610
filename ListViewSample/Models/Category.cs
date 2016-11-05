using System;
namespace ListViewSample.Core.Models
{
	public class Category
	{
		public int Id { get; set;}
		public string Name { get; set; }
		public string Desc { get; set; }
		public string Icon { get; set; }

		static int sid = 0;
		public Category() { 
		}
		public Category(string name, string desc, string icon) {
			this.Id = sid;
			sid++;
			this.Name = name;
			this.Desc = desc;
			this.Icon = icon;
		}

		public override string ToString()
		{
			return this.Id + ". " + this.Name;
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class TaskOptions
	{
		private Guid id;
		private string title;
		private string description;

		public TaskOptions(string title, string description) 
		{
			this.id = Guid.NewGuid();
			this.title = title;
			this.description = description;
		}	
		public TaskOptions(Guid id,string title, string description)
		{
			this.id = id;
			this.title = title;
			this.description = description;
		}

		public string Title { get { return title; } set {  title = value; } }
		public string Description { get { return description; } set { description = value; } }
		public Guid Id { get { return id; } set { id = value; } }
	}

}

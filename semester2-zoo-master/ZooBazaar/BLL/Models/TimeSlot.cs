using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TimeSlot
    {
        private int id;
        private string name;
        private string startTime;
        private string endTime;

        public TimeSlot(int id, string name, string startTime, string endTime)
        {
            this.id = id;
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;
        }

		public override string ToString()
		{
            return $"{startTime}-{endTime}";
		}
		public int ID { get => id; }
        public string Name { get => name; }
        public string StartTime { get => startTime; }
        public string EndTime { get => endTime; }
    }
}

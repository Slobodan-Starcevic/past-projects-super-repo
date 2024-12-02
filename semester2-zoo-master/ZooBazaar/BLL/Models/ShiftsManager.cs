using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ShiftsManager
    {
        private List<TimeSlot> TimeSlots = new List<TimeSlot>();
        public ShiftsManager()
        {
            TimeSlots.Add(new TimeSlot(0, "Shift1", "9:00", "10:00"));
            TimeSlots.Add(new TimeSlot(1, "Shift2", "10:00", "11:00"));
            TimeSlots.Add(new TimeSlot(2, "Shift3", "11:00", "12:00"));
            TimeSlots.Add(new TimeSlot(3, "Shift4", "13:00", "14:00"));
            TimeSlots.Add(new TimeSlot(4, "Shift5", "14:00", "15:00"));
            TimeSlots.Add(new TimeSlot(5, "Shift6", "15:00", "16:00"));
        }

        public TimeSlot? timeSlots(int id)
        {
            TimeSlot slot;
            foreach (TimeSlot t in TimeSlots)
                if (t.ID == id)
                {
                    slot = t;
                    return slot;
                }
            return null;
        }

    }
}

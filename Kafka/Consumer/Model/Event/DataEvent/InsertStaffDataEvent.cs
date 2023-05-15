using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLog.Service.Consumer.Model.Event.DataEvent
{
    public class InsertStaffDataEvent
    {
        public int DoUserId { get; set; }
        public int SalonId { get; set; }
        public string StaffRegister20m { get; set; }
        public DateTime WorkDate { get; set; }
        public int WorkTimeId { get; set; }
        public int StaffId { get; set; }
        public int DepartmentId { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public string MessageStreamId { get; set; }
    }
}

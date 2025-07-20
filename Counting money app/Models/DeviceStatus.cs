using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_money_app.Models
{
    public class DeviceStatus
    {
        public string IPAddress { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public string ConnectionMessage { get; set; }
    }
}

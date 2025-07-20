using Counting_money_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using System.Text;
using System.Threading.Tasks;

namespace Counting_money_app.Services
{

    public class DeviceManager
    {
        private readonly string _deviceIp;
        private readonly int _pingTimeout;

        public DeviceStatus Status { get; private set; }

        public DeviceManager(string ipAddress, int timeout = 1000)
        {
            _deviceIp = ipAddress;
            _pingTimeout = timeout;
            Status = new DeviceStatus { IPAddress = ipAddress };
        }

        public async Task CheckConnectionAsync()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(_deviceIp, _pingTimeout);

                    Status.IsConnected = reply.Status == IPStatus.Success;
                    Status.LastConnectionTime = DateTime.Now;
                    Status.ConnectionMessage = Status.IsConnected
                        ? "Connected"
                        : $"Error: {reply.Status}";
                }
            }
            catch (Exception ex)
            {
                Status.IsConnected = false;
                Status.ConnectionMessage = $"Error: {ex.Message}";
            }
        }

        // Add methods for actual communication with the counting machine
        // based on its specific protocol
    }

}

using Newtonsoft.Json;
using System;
using System.Reflection.PortableExecutable;

namespace MachineDetailsMVC.Models
{
    public class MachineDetails
    {      
        public string MachineName { get; set; }
        public string MachineIP { get; set; }
        public string MachineOS { get; set; }

        public string Timestamp { get; set; }
    }
}

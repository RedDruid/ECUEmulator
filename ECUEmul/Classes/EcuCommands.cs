using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECUEmulator.Classes
{
    public class EcuCommands
    {
        public string EcuName { get; set; }
        public List<OneCommand> Commands { get; set; }
    }

    public class OneCommand
    {
        public string Name { get; set; }
        public string Q { get; set; }
        public string A { get; set; }
    }
}

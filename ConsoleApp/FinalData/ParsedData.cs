using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.FinalData
{
    public class ParsedData
    {
        public string Name { get; set; }

        public string HardwareId { get; set; }

        public string BrandName { get; set; }

       /* public bool isMgmtApiDevice { get; set; }

        public bool isAdtDevice { get; set; }*/

        public override bool Equals(object obj)
        {
            return obj is ParsedData data &&
                   Name == data.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.Events
{

    public class PackageArgs : EventArgs
    {
        public string Description { get; set; }
        public string Contents { get; set; }
    }
}

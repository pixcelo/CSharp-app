using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.UI
{
    internal static class UIShared
    {
        static UIShared()
        {
            MachineFacade = new MachineFacade();
        }

        internal static IMachineFacade MachineFacade { get; private set; }
    }
}

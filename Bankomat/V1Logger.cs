using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class V1Logger : Logger
    {
        internal override void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossGenAndVersionMismatchRepro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stackTrace = new System.Diagnostics.StackTrace(new InvalidOperationException(), needFileInfo: false);
            Console.WriteLine("hello");
        }
    }
}

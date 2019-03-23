using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetChalker;
using static NetChalker_Samples.SampleBase;

namespace NetChalker_Samples
{
    public static class Sample_AppendSpace
    {
        public static void Run()
        {
            ChalkerInstance.AppendSpace = true;
            Console.WriteLine("AppendSpace - true (default):\n");
            EnumerateAll();
            ChalkerInstance.AppendSpace = false;
            Console.WriteLine("AppendSpace - false:\n");
            EnumerateAll();

            ChalkerInstance.AppendSpace = true; // reset
        }
    }
}

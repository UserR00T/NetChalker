using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetChalker;
using static NetChalker_Samples.SampleBase;

namespace NetChalker_Samples
{
    public static class Sample_RightPadding
    {
        public static void Run()
        {
            Console.WriteLine("Default:\n");
            EnumerateAll();
            Console.WriteLine("\n\nPaddingRight = 20:\n");
            ChalkerInstance.PaddingRight = 20;
            EnumerateAll();

            ChalkerInstance.ResetPaddingRight(); // reset
        }
    }
}

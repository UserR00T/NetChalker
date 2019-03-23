using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetChalker;
using static NetChalker_Samples.SampleBase;

namespace NetChalker_Samples
{
    public static class Sample_Casing
    {
        public static void Run()
        {
            Console.WriteLine("Default:\n");
            EnumerateAll();
            Console.WriteLine("\n\nUppercase:\n");
            ChalkerInstance.Casing = TextCasing.Uppercase;
            EnumerateAll();
            Console.WriteLine("\n\nLowercase:\n");
            ChalkerInstance.Casing = TextCasing.Lowercase;
            EnumerateAll();
            Console.WriteLine("\n\nFirstLetterUpper:\n");
            ChalkerInstance.Casing = TextCasing.FirstLetterUpper;
            EnumerateAll();
            Console.WriteLine("\n\nTitlecase:\n");
            ChalkerInstance.Casing = TextCasing.Titlecase;
            EnumerateAll();

            ChalkerInstance.Casing = TextCasing.Default; // reset
        }
    }
}

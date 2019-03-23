using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetChalker;
using static NetChalker_Samples.SampleBase;

namespace NetChalker_Samples
{
    public static class Sample_CustomPrefix
    {
        public static void Run()
        {
            ChalkerInstance.WriteMessage(ConsoleColor.DarkMagenta, "UserR00T", "Hello World!");
            var type = new MessageTypeData(ConsoleColor.DarkMagenta, "UserR00T");
            ChalkerInstance.WriteMessage(type, "Hello World!");
            ChalkerInstance.MessageTypes.Add(6, type);
            ChalkerInstance.ResetPaddingRight(); // Fixes padding issue; only works when added to the internal list.
            ChalkerInstance.WriteMessage(6, "Hello World!");

            ChalkerInstance.MessageTypes.Remove(6); // reset
            ChalkerInstance.ResetPaddingRight(); // reset
        }
    }
}

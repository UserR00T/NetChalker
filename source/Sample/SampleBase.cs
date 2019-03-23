using NetChalker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChalker_Samples
{
    public static class SampleBase
    {
        public static Chalker ChalkerInstance { get; set; }
        public static void EnumerateAll(string text = "Hello World!")
        {
            foreach (var messageType in ChalkerInstance.MessageTypes)
                ChalkerInstance.WriteMessage(messageType.Value, text);
        }


        public static void Main()
        {
            ChalkerInstance = new Chalker();
            ChalkerInstance.WriteMessage("SAMPLE: Casing");
            Sample_Casing.Run();

            Console.WriteLine("\n");
            ChalkerInstance.WriteMessage("SAMPLE: RightPadding");
            Sample_RightPadding.Run();

            Console.WriteLine("\n");
            ChalkerInstance.WriteMessage("SAMPLE: AppendSpace");
            Sample_AppendSpace.Run();

            Console.WriteLine("\n");
            ChalkerInstance.WriteMessage("SAMPLE: CustomPrefix");
            Sample_CustomPrefix.Run();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DPatterns.Patterns.SOLID._1.SRP
{
    class SRPBadPracticeClient: IClient
    {
        public SRPBadPracticeClient()
        {
            Execute();
        }
        public void Execute()
        {
            var j = new Journal();
            j.AddEntry("Smth Name");
            j.AddEntry("Smth Name");

        }
        class Journal
        {
            private readonly List<string> entries = new List<string>();
            private static int count = 0;

            public void AddEntry(string text)
            {
                entries.Add($"{++count}: {text}");
            }

            public void RemoveEntry(int index)
            {
                entries.RemoveAt(index);
            }

            //      This approach is problematic.The journal’s responsibility is to keep
            //      journal entries, not to write them to disk.If you add the persistence
            //      functionality to Journal and similar classes, any change in the approach
            //      to persistence(say, you decide to write to the cloud instead of disk) would
            //      require lots of tiny changes in each of the affected classes.
            public void Save(string fileName, bool overwrite = false)
            {
                File.WriteAllText(fileName, ToString());
            }
        }
    }

    
}

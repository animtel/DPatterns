using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks.Dataflow;
using DPatterns.DI.Components;

namespace DPatterns.Patterns.SOLID._1.SRP
{
    class SRPGoodPracticeClient : IClient
    {
        public SRPGoodPracticeClient()
        {
            Execute();
        }
        public void Execute()
        {
            var journal = new Journal();
            journal.AddEntry("Test1");
            journal.AddEntry("Test2");
            Console.WriteLine(journal.ToString());
            var pm = new PersistenceManager();
            pm.SaveToFile(journal, nameof(journal));
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

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var entry in entries)
                    sb.Append(entry + "; ");

                return sb.ToString();
            }
        }
        //Now, in future, if u'll need to change or extend functionality for saving
        //you will just need to change it here, because it have only one responsibility;
        //If you think:"Why i cant to extend journal for saving and if i will need to change, i'll just change it here?"
        //For it, in programming languages are God Object anti-pattern...
        class PersistenceManager
        {
            public void SaveToFile(Journal journal, string fileName, bool overwrite = false)
            {
                if (overwrite || !File.Exists(fileName))
                    File.WriteAllText(fileName, journal.ToString());
            }
        }
    }


}

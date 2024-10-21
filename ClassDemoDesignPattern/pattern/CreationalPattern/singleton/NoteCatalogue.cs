using System;
using System.Collections.Generic;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.singleton
{
    class NoteCatalogue
    {
        /*
         * Singleton
         */
        // trin 1
        private NoteCatalogue()
        {
            this.notes = new List<string>()
            {
                "basic note1", "basic note2", "basic note3"
            };
        }

        // trin 2
        //private static NoteCatalogue _instance = new NoteCatalogue();  // eager
        private static NoteCatalogue _instance = null; // lazy

        // trin 3
        //public static NoteCatalogue Instance => _instance; // eager

        private static object _instanceLock = new object();
        public static NoteCatalogue Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)  // lazy
                    {
                        _instance = new NoteCatalogue();
                    }
                }

                return _instance;
            }
        }

        /*
         * Slut singleton
         */
        


        private List<String> notes;

        public List<string> Notes => new List<string>(notes);



        public void Add(string item)
        {
            notes.Add(item);
        }

        public void Clear()
        {
            notes.Clear();
        }


        public override string ToString()
        {
            String strNotes = String.Join("\n", notes);
            return $"Notes are :\n{strNotes}";
        }
    }
}

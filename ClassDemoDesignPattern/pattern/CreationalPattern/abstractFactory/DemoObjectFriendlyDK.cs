using System;
using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory
{
    class DemoObjectFriendlyDK : IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Hej {name}");
        }
    }
}

using System;
using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory
{
    class DemoObjectPoliteDK : IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Kære {name}");
        }
    }
}

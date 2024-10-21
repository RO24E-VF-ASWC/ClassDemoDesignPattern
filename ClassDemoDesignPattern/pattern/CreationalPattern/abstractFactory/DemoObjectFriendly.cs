using System;
using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory
{
    class DemoObjectFriendly:IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Hi {name}");
        }
    }
}

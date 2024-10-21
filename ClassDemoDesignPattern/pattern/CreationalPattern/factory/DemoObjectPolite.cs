using System;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.factory
{
    class DemoObjectPolite:IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Dear {name}");
        }
    }
}

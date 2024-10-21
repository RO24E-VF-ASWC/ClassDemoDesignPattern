using System;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.factory
{
    class DemoObjectFriendly:IDemoObject
    {
        public void Print(string name)
        {
            Console.WriteLine($"Hi {name}");
        }
    }
}

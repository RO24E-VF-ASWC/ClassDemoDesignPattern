namespace ClassDemoDesignPatterns.pattern.BehavioralPattern.strategy
{
    class ConcreteStrategy:IStrategy
    {
        public string MakeString(string s)
        {
            return s.ToUpper();
        }
    }
}

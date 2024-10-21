using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory
{
    class FactoryDK:IFactory
    {
        public IDemoObject GetClass(FactoryType typeOfClass)
        {
            switch (typeOfClass)
            {
                case FactoryType.Friendly: return new DemoObjectFriendlyDK();
                case FactoryType.Polite: return new DemoObjectPoliteDK();
            }

            return new DemoObjectPoliteDK();
        }
    }
}

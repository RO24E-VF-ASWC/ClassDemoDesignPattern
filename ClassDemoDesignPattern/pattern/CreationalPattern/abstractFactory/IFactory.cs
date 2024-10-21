using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;

namespace ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory
{
    interface IFactory
    {
        IDemoObject GetClass(FactoryType typeOfClass);
    }
}

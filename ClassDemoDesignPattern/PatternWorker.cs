using System.ComponentModel;
using ClassDemoDesignPatterns.pattern.BehavioralPattern.observer;
using ClassDemoDesignPatterns.pattern.BehavioralPattern.state;
using ClassDemoDesignPatterns.pattern.BehavioralPattern.strategy;
using ClassDemoDesignPatterns.pattern.BehavioralPattern.template;
using ClassDemoDesignPatterns.pattern.CreationalPattern.abstractFactory;
using ClassDemoDesignPatterns.pattern.CreationalPattern.factory;
using ClassDemoDesignPatterns.pattern.CreationalPattern.singleton;
using ClassDemoDesignPatterns.pattern.StructuralPattern.adaptor;
using ClassDemoDesignPatterns.pattern.StructuralPattern.composite;
using ClassDemoDesignPatterns.pattern.StructuralPattern.decorator;
using ClassDemoDesignPatterns.pattern.StructuralPattern.facade;
using ClassDemoDesignPatterns.pattern.StructuralPattern.proxy;
using IComponent = ClassDemoDesignPatterns.pattern.StructuralPattern.decorator.IComponent;
using IDemoObject = ClassDemoDesignPatterns.pattern.CreationalPattern.factory.IDemoObject;

namespace ClassDemoDesignPatterns
{
    class PatternWorker
    {
        public void Start()
        {
            /*
             * Demo Creational pattern
             */
            //DemoSingleton();
            DemoFactoryMethod();
            //DemoAbstractFactory();


            /*
             * Demo Structural pattern
             */
            //DemoAdaptor();
            //DemoFacade();
            //DemoProxy();
            //DemoDecorator();
            //DemoComposite();



            /*
             * Demo Behavioral pattern
             */
            //DemoObserver();
            //DemoTemplate();
            //DemoStrategy();
            //DemoState();

        }

        // make NoteCatalogue as singleton
        private void DemoSingleton()
        {
            
            //NoteCatalogue c1 = new NoteCatalogue();
            NoteCatalogue c1 = NoteCatalogue.Instance;
            c1.Add("New note");
            Console.WriteLine(c1);
            Console.WriteLine();

            //NoteCatalogue c2 = new NoteCatalogue();
            NoteCatalogue c2 = NoteCatalogue.Instance;
            c2.Add("yet another note");
            Console.WriteLine(c2);
        }

        private void DemoFactoryMethod()
        {
            IDemoObject obj = DemoFactory.GetClass(FactoryType.Polite);
            obj.Print("Peter");

            IDemoObject obj2 = DemoFactory.GetClass(FactoryType.Friendly);
            obj2.Print("Peter");

        }

        private void DemoAbstractFactory()
        {
            IFactory factory = AbstractFactory.GetFactory(AbstractFactoryType.Uk);
            IDemoObject obj = factory.GetClass(FactoryType.Polite);
            obj.Print("Peter");

            IFactory factory2 = AbstractFactory.GetFactory(AbstractFactoryType.Dk);
            IDemoObject obj2 = factory2.GetClass(FactoryType.Friendly);
            obj2.Print("Peter");

        }

        
        private void DemoAdaptor()
        {
            IAdaptor adap = new Adaptor1();
            string newstr = adap.Request("peter");
            Console.WriteLine(newstr);

            IAdaptor adap2 = new Adaptor2();
            string newstr2 = adap2.Request("anders");
            Console.WriteLine(newstr2);

        }

        private void DemoFacade()
        {
            Facade facade = new Facade();

            facade.InsertNote("Remember to Shop on the way home");
            facade.NewShopItem("Milk");

            Console.WriteLine("My shoping list \n" + string.Join("\n", facade.GetShoppingList()));


        }

        private void DemoProxy()
        {
            IDemoProxy proxy = new RealProxy();

            proxy.InsertString("Peter");
            proxy.InsertString("Anders");
            proxy.InsertString("Vibeke");
            proxy.InsertString("Michael C");

            foreach (string s in proxy.GetAll())
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("    AFTER PROXY ");
            IDemoProxy proxy2 = new ProxyClass("MyLogFile.txt");

            proxy2.InsertString("Peter");
            proxy2.InsertString("Anders");
            
            foreach (string s in proxy2.GetAll())
            {
                Console.WriteLine(s);
            }

        }

        private void DemoDecorator()
        {
            // Concrete
            IComponent component = new ConcreteComponent();
            Console.WriteLine(component.DoSomething("peter"));

            IComponent comp2 = new Decorator1(component);
            Console.WriteLine(comp2.DoSomething("peter"));

            IComponent comp3 = new Decorator1(comp2);
            Console.WriteLine(comp3.DoSomething("peter"));

        }


        private void DemoComposite()
        {
            // some leafs 
            LeafBox b1 = new LeafBox(100);

            Composite comp1 = new Composite();
            comp1.Add(b1);
            comp1.Add(new LeafBox(50));

            Composite comp2 = new Composite();
            comp2.Add(b1);
            comp2.Add(comp1);

            Console.WriteLine(comp2.TotalWeight());


        }

        // Make Observer
        private void DemoObserver()
        {
            
            // I am observer
            ObservableObject obj = new ObservableObject(3, "text");
            obj.Text = "Peter"; // nothing happen

            obj.PropertyChanged += (sender, args) =>
            {
                Console.WriteLine("Anonymuos Method " + args.PropertyName + " objekt værdier " + sender);
            };
            obj.Text = "Anders";


            Console.WriteLine("Named method added");
            obj.PropertyChanged += Update;
            obj.Id = 99;

            Console.WriteLine("Named method removed");
            obj.PropertyChanged -= Update;
            obj.Id = 222;

            
        }

        /*
         * Help to Observer
         */
        protected void Update(object obj, PropertyChangedEventArgs args)
        {
            Console.WriteLine($"This is a named method : the changed property is {args.PropertyName}");
            Console.WriteLine($"New values is \n{obj}");
        }



        private void DemoTemplate()
        {
            List<String> data = new List<string>()
            {
                "Peter",
                "Anders",
                "Vibeke",
                "Michael C"
            };

            AbstractTemplateClass temp = new MySubTemplate();
            temp.InsertTemplateMethod(data);

            Console.WriteLine(temp);

        }

        private void DemoStrategy()
        {
            List<String> data = new List<string>()
            {
                "Peter",
                "Anders",
                "Vibeke",
                "Michael C"
            };

            /*
             * Design Pattern like
             */
            ContextClass context = new ContextClass();
            context.InsertStrategyMethod(data, new ConcreteStrategy());
            Console.WriteLine(context);

            /*
             * More C# Like
             */
            ContextClassMoreCSharpLike context2 = new ContextClassMoreCSharpLike();
            context2.StrategyMethod = (s) => { return s.Substring(1); };
            context2.InsertStrategyMethod(data);
            Console.WriteLine(context2);

        }

        private void DemoState()
        {
            // low tax
            IState calc = new DemoStateLow();
            int price = calc.HandleCalculate(10000);
            Console.WriteLine($"Price with low tax is {price}");

            // high tax
            calc = new DemoStateHigh();
            price = calc.HandleCalculate(10000);
            Console.WriteLine($"Price with high tax is {price}");
        }
    }
}
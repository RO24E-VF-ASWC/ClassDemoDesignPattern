using System;
using System.Collections.Generic;

namespace ClassDemoDesignPatterns.pattern.StructuralPattern.proxy
{
    interface IDemoProxy
    {
        void InsertString(String str);
        List<String> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisplayOrderAttribute : Attribute
    {
        public int Order;

        public DisplayOrderAttribute(int order)
        {
            this.Order = order;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExecutionOrderAttribute : Attribute
    {
        public int Order;

        public ExecutionOrderAttribute(int order)
        {
            this.Order = order;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class IsNextSeparatorAttribute : Attribute
    {
        public bool Value;

        public IsNextSeparatorAttribute(bool value)
        {
            this.Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class RequiresPathAttribute : Attribute
    {
        public bool Value;

        public RequiresPathAttribute(bool value)
        {
            this.Value = value;
        }
    }
}

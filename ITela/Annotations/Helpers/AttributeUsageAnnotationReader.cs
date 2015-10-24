using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITela
{
    internal static class AttributeUsageAnnotationReader
    {
        internal static AttributeUsageAttribute Read<A>() where A : Attribute
        {
            var typeInfo = typeof(A).GetTypeInfo();
            var list = typeInfo.GetCustomAttributes<AttributeUsageAttribute>();
            if (list.Count() > 1) throw new InvalidOperationException("Should not even occur because AttributeUsage has an default AllowMultiple set to false.");
            if (list.Count() == 0)
            {
                return new AttributeUsageAttribute(AttributeTargets.All); // We return the default attribute usage.
            }
            else
            {
                return list.First();
            }
        }
    }
}

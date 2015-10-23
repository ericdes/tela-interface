using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ITela.Gc
{
    public static class AnnotationReader
    {

        public static A GetAttribute<T, A>(bool throwIfAttributeIsMissing = false) where A : Attribute
        {
            var attributeUsage = AttributeUsageAnnotationReader.Read<A>();
            if (attributeUsage.AllowMultiple) throw new InvalidOperationException(string.Format("Attribute {0} allows multiple annotations. Use GetAttributes<{1}, {0}>() instead.", typeof(A), typeof(T)));
            var typeInfo = typeof(T).GetTypeInfo();
            var list = typeInfo.GetCustomAttributes<A>();
            if (list.Count() > 1) throw new InvalidOperationException(string.Format("Attribute of type {0} on entity of type {1} must be used only once.", typeof(A), typeof(T)));
            if (throwIfAttributeIsMissing && list.Count() == 0) throw new Exception(string.Format("Missing attribute of type {0} on entity of type {1}.", typeof(A), typeof(T)));
            return list.First();
        }


        public static IEnumerable<A> GetAttributes<T, A>(bool throwIfAttributeIsMissing = false) where A : Attribute
        {
            var attributeUsage = AttributeUsageAnnotationReader.Read<A>();
            if (!attributeUsage.AllowMultiple) throw new InvalidOperationException(string.Format("Attribute {0} does not allow multiple annotations. Use GetAttribute<{1}, {0}>() instead.", typeof(A), typeof(T)));
            var typeInfo = typeof(T).GetTypeInfo();
            var list = typeInfo.GetCustomAttributes<A>();
            if (throwIfAttributeIsMissing && list.Count() == 0) throw new Exception(string.Format("Missing attribute of type {0} on entity of type {1}.", typeof(A), typeof(T)));
            return list;
        }


    }

}

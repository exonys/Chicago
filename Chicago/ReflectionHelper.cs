using System;
using System.Linq;
using System.Reflection;

namespace Chicago
{
    internal static class ReflectionHelper
    {
        public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
                assembly.GetTypes()
                        .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                        .ToArray();
        }
    }
}
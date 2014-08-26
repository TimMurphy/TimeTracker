using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace TimeTracker.Domain.Infrastructure.Mapping
{
    public static class Mapping
    {
        private static readonly ConcurrentDictionary<string, Func<object, object>> Mappers = new ConcurrentDictionary<string, Func<object, object>>();

        public static TTo MapTo<TTo>(this object obj)
            where TTo : class
        {
            var key = string.Format("{0} to {1}", obj.GetType(), typeof(TTo));
            var mapper = Mappers.GetOrAdd(key, CreateMapper(obj, typeof(TTo)));
            var toValue = mapper(obj);

            return (TTo)toValue;
        }

        private static Func<object, object> CreateMapper(object @from, Type toType)
        {
            var toConstructor = GetConstructor(toType);
            var fromProperties = @from.GetType().GetTypeInfo().DeclaredProperties.ToArray();

            return obj =>
            {
                var toParameters = toConstructor.GetParameters();
                var toParameterValues = toParameters.Select(p => GetParameterValue(toType, p, @obj, fromProperties)).ToArray();
                var toValue = toConstructor.Invoke(toParameterValues);

                return toValue;
            };
        }

        private static object GetParameterValue(Type toType, ParameterInfo toParameter, object @from, PropertyInfo[] fromProperties)
        {
            var fromProperty = GetPropertyInfo(toType, toParameter, fromProperties);
            var fromValue = fromProperty.GetValue(@from);

            return fromValue;
        }

        private static PropertyInfo GetPropertyInfo(Type toType, ParameterInfo toParameter, PropertyInfo[] fromProperties)
        {
            var propertyInfo = fromProperties.SingleOrDefault(p => p.Name.Equals(toParameter.Name, StringComparison.OrdinalIgnoreCase));

            if (propertyInfo == null)
            {
                throw new Exception(string.Format("Cannot {0} property that matches {1}'s constructor parameter {2}.", fromProperties.First().DeclaringType.FullName, toType, toParameter.Name));
            }

            return propertyInfo;
        }

        private static ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetTypeInfo().DeclaredConstructors.Where(c => c.IsPublic && c.GetParameters().Length > 0).ToArray();

            switch (constructors.Length)
            {
                case 0:
                    throw new Exception(string.Format("Cannot find public constructor with one or more parameters for {0}.", type));

                case 1:
                    return constructors[0];

                default:
                    throw new Exception(string.Format("Found multiple public constructors for {0}.", type));
            }
        }
    }
}

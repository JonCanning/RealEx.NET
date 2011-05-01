using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

namespace RealEx.Serialization
{
    static class Serializer
    {
        private static readonly KeyedByTypeCollection<ISerializer> SerializerCollection = new KeyedByTypeCollection<ISerializer>();

        static Serializer()
        {
            var serializers = Assembly.GetAssembly(typeof(Serializer)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(ISerializer)));
            foreach (var serializer in serializers)
            {
                SerializerCollection.Add(Activator.CreateInstance(serializer) as ISerializer);
            }
        }

        internal static ISerializer<T> For<T>() where T : RealExBaseRequest
        {
            return SerializerCollection.Find<ISerializer<T>>();
        }

        private static string PropertyName(this LambdaExpression expression)
        {
            return (expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression).Member.Name;
        }

        internal static XElement ToXElement<T, TProperty>(this T source, Expression<Func<T, TProperty>> expression, string elementName = null)
        {
            var serializer = SerializerCollection.Find<ISerializer<TProperty>>();
            if (serializer != null) return serializer.Serialize(expression.Compile().Invoke(source));
            var name = GetName(elementName, expression);
            var value = GetPropertyValue(expression, source);
            return string.IsNullOrWhiteSpace(value) ? null : new XElement(name, value);
        }

        internal static XAttribute ToXAttribute<T, TProperty>(this T source, Expression<Func<T, TProperty>> expression, string attributeName = null)
        {
            var name = GetName(attributeName, expression);
            var value = GetPropertyValue(expression, source);
            return string.IsNullOrWhiteSpace(value) ? null : new XAttribute(name, value);
        }

        private static string GetPropertyValue<T, TProperty>(Expression<Func<T, TProperty>> expression, T source)
        {
            var value = expression.Compile().Invoke(source);
            return value == null ? null : value.ToString();
        }

        private static string GetName<T, TProperty>(string elementName, Expression<Func<T, TProperty>> expression)
        {
            return elementName ?? expression.PropertyName().ToLower();
        }
    }
}
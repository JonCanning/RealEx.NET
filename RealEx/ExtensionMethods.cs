using System;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace RealEx
{
    internal static class ExtensionMethods
    {
        internal static string CurrencyName(this RealExCurrency realExCurrency)
        {
            return Enum.GetName(typeof(RealExCurrency), realExCurrency);
        }

        internal static string PropertyName(this LambdaExpression expression)
        {
            return (expression.Body as MemberExpression ?? ((UnaryExpression) expression.Body).Operand as MemberExpression).Member.Name;
        }

        internal static XElement ToXElement<T, TProperty>(this T source, Expression<Func<T, TProperty>> expression, string elementName = null)
        {
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using EasyUI.Mvc.Infrastructure;

namespace EasyUI.Mvc.UI
{
    public abstract class ComponentBuilderBase<TComponent, TBuilder>
        where TBuilder : class
        where TComponent : class
    {
        private static readonly Func<TComponent, TBuilder> creator = GetCreator();

        public static TBuilder Create(TComponent component)
        {
            return creator(component);
        }

        private static Func<TComponent, TBuilder> GetCreator()
        {
            var builderType = typeof(TBuilder);
            var componentType = typeof(TComponent);
            var htmlStringType = typeof(HttpContext).Assembly.GetType("System.Web.IHtmlString");
            var targetType = typeof(TBuilder);

            if (htmlStringType != null)
            {
                // For .NET 4 define a dynamic type which implements IHtmlString in order to support <%: %>
                targetType = DynamicTypeBuilder.GenerateType(builderType, new[] { htmlStringType });
            }

            var argumentExpression = Expression.Parameter(componentType, "component");
            var constructor = targetType.GetConstructor(new Type[] { componentType });
            var newExpression = Expression.New(constructor, argumentExpression);

            return Expression.Lambda<Func<TComponent, TBuilder>>(newExpression, argumentExpression).Compile();
        }
    }
}
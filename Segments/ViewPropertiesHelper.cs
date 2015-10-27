using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Segments
{
    public class ViewPropertiesHelper
    {
        private readonly List<BindableProperty> properties = new List<BindableProperty>();

        public ViewPropertiesHelper(Type sourceObjectType, Type targetObjectType)
        {
            Type type = sourceObjectType;
            var sourceObjectProperties = new List<BindableProperty>();
            while (type != typeof(View))
            {
                sourceObjectProperties.AddRange(type.GetRuntimeFields()
                    .Where(field => field.FieldType == typeof(BindableProperty))
                    .Select(field => field.GetValue(null))
                    .OfType<BindableProperty>());
                type = type.GetTypeInfo().BaseType;
            }

            List<PropertyInfo> targetProperties = targetObjectType.GetRuntimeProperties().ToList();
            foreach (var property in sourceObjectProperties)
            {
                if (targetProperties.Any(prop => prop.Name == property.PropertyName))
                {
                    properties.Add(property);
                }
            }
        }

        public void SetAllPropertyValues(object targetObject, object sourceObject)
        {
            foreach (var property in properties)
            {
                SetPropertyValue(property, targetObject, sourceObject);
            }
        }

        public void SetPropertyValue(string propertyName, object targetObject, object sourceObject)
        {
            if (targetObject != null && sourceObject != null)
            {
                var property = properties.FirstOrDefault(prop => prop.PropertyName == propertyName);
                if (property != null)
                {
                    SetPropertyValue(property, targetObject, sourceObject);
                }
            }
        }

        private void SetPropertyValue(BindableProperty bindableProperty, object targetObject, object sourceObject)
        {
            var value = GetProperty(bindableProperty, sourceObject).GetValue(sourceObject);
            GetProperty(bindableProperty, targetObject).SetValue(targetObject, value);
        }

        private PropertyInfo GetProperty(BindableProperty bindableProperty, object sourceObject)
        {
            return sourceObject.GetType().GetRuntimeProperty(bindableProperty.PropertyName);
        }
    }
}


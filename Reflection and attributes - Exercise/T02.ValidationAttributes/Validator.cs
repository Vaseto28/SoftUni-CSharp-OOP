namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using Attributes;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] props = objType
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAtribute)))
                .ToArray();

            foreach (var prop in props)
            {
                object propValue = prop.GetValue(obj);

                foreach (var customAttributeData in prop.CustomAttributes)
                {
                    Type customeAttributeType = customAttributeData.AttributeType;
                    object attributeInstance = prop.GetCustomAttribute(customeAttributeType);

                    MethodInfo methodInfo = customeAttributeType.GetMethods().First(m => m.Name == "IsValid");
                    bool result = (bool)methodInfo.Invoke(attributeInstance, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}


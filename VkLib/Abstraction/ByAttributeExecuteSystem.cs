using System;
using System.Collections.Generic;
using System.Reflection;

namespace VkLib.Abstraction
{
    public abstract class ByAttributeExecuteSystem<T> : BaseExecuteSystem<T>
    {
        protected ByAttributeExecuteSystem(IAuthenticationProvider provider = null) : base(provider)
        {
        }

        private static String GetBoolValue(Boolean value)
        {
            if (value)
            {
                return "1";
            }
            return "0";
        }

        private static String GetStringList(List<String> value)
        {
            var result = String.Empty;
            value.ForEach(x => result = result + x + ",");
            return result;
        }

        private static String GetInt32(Int32 value, IFormatProvider culture)
        {
            return value.ToString(culture);
        }

        private static String GetUInt32(UInt32 value, IFormatProvider culture)
        {
            return value.ToString(culture);
        }

        private static String GetDateTime(DateTime value, IFormatProvider culture)
        {
            return value.ToUnixTime().ToString(culture);
        }

        private static String GetGuid(Guid value, IFormatProvider culture)
        {
            return value.ToString();
        }

        private static String GetDouble(Double value, IFormatProvider culture)
        {
            return value.ToString(culture);
        }

        protected override Dictionary<String, String> PrepareRequestParameters(IVkMethod method, ExecuteEnvironment environment)
        {
            var properties = method.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var parameters = new Dictionary<String, String>();

            foreach (var propertyInfo in properties)
            {
                var attr = propertyInfo.GetCustomAttributes(typeof(VkParamAttribute), true);
                if (attr.Length <= 0) continue;

                var mpa = (VkParamAttribute)attr[0];

                if (propertyInfo.PropertyType == typeof(Boolean?))
                {

                    var boolValue = (bool?)propertyInfo.GetValue(method, null);
                    if (boolValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetBoolValue(boolValue.Value));
                    }
                }
                if (propertyInfo.PropertyType == typeof(String))
                {
                    var stringValue = (String)propertyInfo.GetValue(method, null);
                    if (stringValue != null)
                    {
                        parameters.Add(mpa.Name, stringValue);
                    }
                }
                if (propertyInfo.PropertyType == typeof(List<String>))
                {
                    var listValue = (List<String>)propertyInfo.GetValue(method, null);
                    if (listValue != null && listValue.Count > 0)
                    {
                        parameters.Add(mpa.Name, GetStringList(listValue));
                    }
                }
                if (propertyInfo.PropertyType == typeof(Int32?))
                {
                    var intValue = (Int32?)propertyInfo.GetValue(method, null);
                    if (intValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetInt32(intValue.Value, environment.Culture));
                    }
                }
                if (propertyInfo.PropertyType == typeof (UInt32?))
                {
                    var intValue = (UInt32?)propertyInfo.GetValue(method, null);
                    if (intValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetUInt32(intValue.Value, environment.Culture));
                    }
                }
                if (propertyInfo.PropertyType == typeof(DateTime?))
                {
                    var dateTimeValue = (DateTime?)propertyInfo.GetValue(method, null);
                    if (dateTimeValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetDateTime(dateTimeValue.Value, environment.Culture));
                    }
                }
                if (propertyInfo.PropertyType == typeof (Guid?))
                {
                    var guidValue = (Guid?)propertyInfo.GetValue(method, null);
                    if (guidValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetGuid(guidValue.Value, environment.Culture));
                    }
                }
                if (propertyInfo.PropertyType == typeof (Double?))
                {
                    var doubleValue = (Double?) propertyInfo.GetValue(method, null);
                    if (doubleValue.HasValue)
                    {
                        parameters.Add(mpa.Name, GetDouble(doubleValue.Value, environment.Culture));
                    }
                }
            }

            if (environment.PrepareParametersExtension != null)
            {
                environment.PrepareParametersExtension(parameters);
                environment.PrepareParametersExtension = null;
            }

            return parameters;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TwitterBootstrapMVC.TypeExtensions
{
    public static class TypeExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IDictionary<string, object> ToDictionary(this object data)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            if (data == null) return dictionary; // Or throw an ArgumentNullException if you want

            BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;

            foreach (PropertyInfo property in
                     data.GetType().GetProperties(publicAttributes))
            {
                if (property.CanRead)
                {
                    dictionary.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Adds a new attribute. In case such attribute exists, it will merge them.
        /// </summary>
        public static TagBuilder AddOrMergeCssClass(this TagBuilder tb, string attrValue)
        {
            if (tb.Attributes.ContainsKey("class"))
            {
                if (!tb.Attributes["class"].Contains(attrValue)) tb.Attributes["class"] += " " + attrValue;
            }
            else
            {
                tb.Attributes.Add("class", attrValue);
            }

            return tb;
        }

        /// <summary>
        /// Adds a new attribute. In case such attribute exists, it will merge them.
        /// </summary>
        public static TagBuilder AddOrMergeAttribute(this TagBuilder tb, string attrName, string attrValue)
        {
            if (tb.Attributes.ContainsKey(attrName))
            {
                if(!tb.Attributes[attrName].Contains(attrValue)) tb.Attributes[attrName] += " " + attrValue;
            }
            else
            {
                tb.Attributes.Add(attrName, attrValue);
            }

            return tb;
        }

        public static IDictionary<string, object> AddOrReplace(this IDictionary<string, object> data, string key, string value)
        {
            if (data.ContainsKey(key))
                data[key] = value;
            else
                data.Add(key, value);

            return data;
        }

        public static IDictionary<string, object> AddOrMergeCssClass(this IDictionary<string, object> data, string key, string value)
        {
            if (data.ContainsKey(key))
            {
                if (data[key].GetType() == typeof(string) && !data[key].ToString().Contains(value))
                    data[key] += " " + value;
            }
            else if (!string.IsNullOrEmpty(value))
            {
                data.Add(key, value);
            }

            return data;
        }

        public static IDictionary<string, object> AddIfNotExist(this IDictionary<string, object> data, string key, string value)
        {
            if (!data.ContainsKey(key))
                data.Add(key, value);

            return data;
        }

        public static void AddRange<T, S>(this IDictionary<T, S> source, IDictionary<T, S> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
                else
                {
                    // handle duplicate key issue here
                }
            }
        }

        public static IDictionary<string, object> FormatHtmlAttributes(this IDictionary<string, object> htmlAttributes)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            foreach (var key in htmlAttributes.Keys)
            {
                result.Add(key.Replace('_', '-'), htmlAttributes[key]);
            }
            return result;
        }

        /// <summary>
        /// Adds Css style to a TagBuilder element
        /// </summary>
        public static TagBuilder AddCssStyle(this TagBuilder tb, string styleName, string styleValue)
        {
            if (tb.Attributes.ContainsKey("style"))
            {
                tb.Attributes["style"] += styleName + ":" + styleValue + ";";
            }
            else
            {
                tb.Attributes.Add("style", styleName + ":" + styleValue + ";");
            }

            return tb;
        }

        public static string SplitByUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            Regex r = new Regex(@"(?!^)(?=[A-Z])");
            return r.Replace(s, " ");
        }

        public static string FormatForMvcInputId(this string s)
        {
            return s.Replace(".", "_").Replace('[', '_').Replace(']', '_');
        }

        /// <summary>
        /// Gets Description of an Enum
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="enumerationValue">Enum</param>
        public static string GetEnumDescription(this Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrsDesc = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                object[] attrsDisp = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attrsDesc != null && attrsDesc.Length > 0) return ((DescriptionAttribute)attrsDesc[0]).Description;
                if (attrsDisp != null && attrsDisp.Length > 0) return ((DisplayAttribute)attrsDisp[0]).Name;
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}

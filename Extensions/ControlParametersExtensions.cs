using System;
using System.Reflection;
using System.Collections.Generic;
using FoundryRulesAndUnits.Extensions;

using IoBTMessage.Models;

// Allow nullable reference types   

namespace IoBTMessage.Extensions;

public static class ControlParametersExtension
{

    public static List<ControlParameterCSV> ControlParametersToCSV(this DT_Base source)
    {
        if (source.metadata == null) return null;

        var result = new List<ControlParameterCSV>();
        foreach (var item in source.metadata.lookup)
        {
            var record = new ControlParameterCSV()
            {
                guid = source.guid,
                name = source.name,
                type = source.type,
                field = item.Key,
                value = item.Value.ToString() ?? "",
            };
            result.Add(record);
        }
        return result;
    }

    public static ControlParameters EstablishMetaData(this DT_Base source, string field, string value)
    {

        source.AddMetaData(field, value);
        var result = source.metadata;

        return result;
    }

    public static double GetDouble(this ControlParameters cn, string field)
    {
        var value = double.Parse((string)cn.Find(field));
        return value;
    }

    public static double SetDouble(this ControlParameters cn, string field, double value)
    {
        cn.Establish(field, value);
        return value;
    }

    public static bool GetBoolean(this ControlParameters cn, string field)
    {
        var value = bool.Parse((string)cn.Find(field));
        return value;
    }

    public static bool SetBoolean(this ControlParameters cn, string field, bool value)
    {
        cn.Establish(field, value);
        return value;
    }

    public static T SetObject<T>(this ControlParameters cn, string field, T value) where T : class
    {
        var result = CodingExtensions.Dehydrate<T>(value, true);
        cn.Establish(field, result);
        return value;
    }

    public static T GetObject<T>(this ControlParameters cn, string field) where T : class
    {
        var value = cn.Find(field).ToString();
        var result = CodingExtensions.Hydrate<T>(value, true);
        return result;
    }

    public static string SetValue(this ControlParameters cn, string field, string value)
    {
        cn.Establish(field, value);
        return value;
    }

    public static string GetValue(this ControlParameters cn, string field)
    {
        var value1 = cn.Find(field);
        if (value1 != null)
            return value1.ToString();

        var source = field.ToLower();
        var value2 = cn.Find(source);
        if (value2 != null)
            return value2.ToString();

        return $"Value Not Found for [{field}] or [{source}]";
    }

    public static ControlParameters Write<T>(this ControlParameters cn, T source)
    {
        var spec = BindingFlags.Instance | BindingFlags.Public;
        var properties = source.GetType().GetProperties(spec);
        foreach (var property in properties)
        {
            var field = property.Name;
            var value = property.GetValue(source);
            if (value != null)
                cn.Establish(field, value.ToString());
        }
        return cn;
    }

    public static T Read<T>(this ControlParameters cn)
    {
        var spec = BindingFlags.Instance | BindingFlags.Public;
        var source = Activator.CreateInstance<T>();
        var properties = source.GetType().GetProperties(spec);
        foreach (var property in properties)
        {
            var field = property.Name;
            var value = cn.Find(field);
            property.SetValue(source, value);
        }
        return source;
    }

}

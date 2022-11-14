using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace IoBTMessage.Models
{

	public static class CodingExtensions
	{

		public static String RemoveExtension(this String str)
		{
			return Path.GetFileNameWithoutExtension(str);
		}
		public static String RemoveVersion(this String str)
		{
			if (!str.Contains('_'))
			{
				return str;
			}
			var parts = str.Split('_');
			var allButLast = parts.SkipLast(1).ToList();
			var retVal = String.Join("_", allButLast);
			return retVal;
		}

		public static IEnumerable<T> DistinctUsing<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
		{
			return items.GroupBy(property).Select(x => x.First());
		}
		public static bool IsImage(this DT_Document doc)
		{
			var filename = doc.filename.ToLower();
			if (filename.EndsWith("jpg"))
				return true;
			if (filename.EndsWith("png"))
				return true;
			return false;
		}

		public static bool IsModel(this DT_Document doc)
		{
			var filename = doc.filename.ToLower();
			if (filename.EndsWith("fbx"))
				return true;
			if (filename.EndsWith("glb"))
				return true;
			if (filename.EndsWith("obj"))
				return true;
			return false;
		}

		public static bool IsVideo(this DT_Document doc)
		{
			var filename = doc.filename.ToLower();
			if (filename.EndsWith("mp4"))
				return true;
			if (filename.EndsWith("mp3"))
				return true;
			return false;
		}

		public static void WriteTrace(this String str)
		{
			$"... {str}".WriteLine(ConsoleColor.DarkMagenta);
		}

		public static String UrlEncode(this String str)
		{
			return HttpUtility.UrlEncode(str);
		}

		public static String UrlEncode(this String str, Encoding e)
		{
			return HttpUtility.UrlEncode(str, e);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (T element in source)
				action(element);
		}

		public static void CopyNonNullProperties<T>(this T source, T dest)
		{
			var plist = from prop in typeof(T).GetProperties() where prop.CanRead && prop.CanWrite select prop;

			foreach (PropertyInfo prop in plist)
			{
				var value = prop.GetValue(source, null);
				if (value != null && !string.IsNullOrEmpty(value.ToString()))
					prop.SetValue(dest, value, null);
			}
		}

		public static void CopyFields<T>(this T source, T dest)
		{
			var plist = from prop in typeof(T).GetFields() select prop;

			foreach (FieldInfo prop in plist)
			{
				var value = prop.GetValue(source);
				prop.SetValue(dest, value);
			}
		}

		public static void CopyProperties<T>(this T source, T dest)
		{
			var plist = from prop in typeof(T).GetProperties() where prop.CanRead && prop.CanWrite select prop;

			foreach (PropertyInfo prop in plist)
			{
				var value = prop.GetValue(source, null);
				prop.SetValue(dest, value, null);
			}
		}

		public static void CopyPropertiesTo<T, U>(this T source, U dest)
		{
			var plistsource = from prop1 in typeof(T).GetProperties() where prop1.CanRead select prop1;
			var plistdest = from prop2 in typeof(U).GetProperties() where prop2.CanWrite select prop2;

			foreach (PropertyInfo destprop in plistdest)
			{
				var sourceprops = plistsource.Where((p) => p.Name == destprop.Name &&
				  destprop.PropertyType.IsAssignableFrom(p.GetType()));
				foreach (PropertyInfo sourceprop in sourceprops)
				{ // should only be one
					var value = sourceprop.GetValue(source, null);
					destprop.SetValue(dest, value, null);
				}
			}
		}
	}
}

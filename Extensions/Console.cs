using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IoBTMessage.Models
{
	public static class ConsoleHelpers
	{


		public static string WriteLine<T>(this T entity, ConsoleColor? color = null)
		{
			if (color.HasValue)
				Console.ForegroundColor = color.Value;
			var message = entity != null ? JsonConvert.SerializeObject(entity, Formatting.Indented) : "null";

			Console.WriteLine(message);
			Console.ResetColor();
			return message;
		}

		public static string WriteLine(this string message, ConsoleColor? color = null)
		{
			if (color.HasValue)
				Console.ForegroundColor = color.Value;
			Console.WriteLine(message);
			Console.ResetColor();
			return message;
		}

		public static string Write(this string message, ConsoleColor? color = null)
		{
			if (color.HasValue)
				Console.ForegroundColor = color.Value;
			Console.Write(message);
			Console.ResetColor();
			return message;
		}

		public static string WriteInLine(this string message, ConsoleColor? color = null)
		{
			if (color.HasValue)
				Console.ForegroundColor = color.Value;
			Console.Write(message.Trim() + " "); //make sure there's a space at the end of the message since it's inline.
			Console.ResetColor();
			return message;
		}

	}

}

﻿
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IoBTMessage.Models
{
	public static class ConsoleHelpers
	{


		// public static string WriteLine<T>(this T entity, ConsoleColor? color = null)
		// {
		// 	if (color.HasValue)
		// 		Console.ForegroundColor = color.Value;
		// 	var message = entity != null ? JsonConvert.SerializeObject(entity, Formatting.Indented) : "null";

		// 	Console.WriteLine(message);
		// 	Console.ResetColor();
		// 	return message;
		// }

    // public static string WriteLine<T>(this T entity, ConsoleColor? color = null)
    // {
    //     if (color.HasValue)
    //         Console.ForegroundColor = color.Value;

    //     var options = new JsonSerializerOptions()
    //     {
    //         IncludeFields = false,
    //         IgnoreReadOnlyFields = true,
    //         DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    //     };

    //     var message = entity != null ? JsonSerializer.Serialize(entity, options) : "null";

    //     Console.WriteLine(message);
    //     Console.ResetColor();
    //     return message;
    // }
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

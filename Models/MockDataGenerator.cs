using System;
using System.Collections.Generic;

namespace IoBTMessage.Models
{

	/// <summary>
	/// RandomName class, used to generate a random name.
	/// </summary>
	public class MockDataGenerator
	{
		class NameList
		{
			public string[] first { get; set; }
			public string[] last { get; set; }

			public NameList()
			{
				first = new string[] {
					"Thomas", "Casen", "Eric","Steve","Greg", "Sherman","Jason","Nathan","Matt","Mark","JB"
				};
				last = new string[] {
					"North", "South", "East","West","Earth","Wind","Fire","Water"
				};
			}
		}

		readonly Random rand;
		readonly List<string> firstNames;
		readonly List<string> lastnames;

		public MockDataGenerator()
		{
			this.rand = new Random();
			var list = new NameList();

			firstNames = new List<string>(list.first);
			lastnames = new List<string>(list.last);
		}

		public string GenerateName()
		{
			string first = firstNames[rand.Next(firstNames.Count)];
			string last = lastnames[rand.Next(lastnames.Count)];

			return $"{first}_{last}";
		}

		public double GenerateDouble(double min=0.0, double max=1.0)
		{
			return min + (max - min) * rand.NextDouble();
		}
		public int GenerateInt(int min=0, int max=1)
		{
			return rand.Next(min,max);
		}
	}
}
